using System;
using System.Threading;
using UnityEngine;

namespace HomaGames.HomaBelly
{
    public class PendingEvent
    {
        public string Id { get; }
        public string EventName { get; }
        public string Json { get; }
        
        /// <summary>
        /// How many times we have tried to send this event.
        /// </summary>
        public int PostRetries { get; set; }
        

        private CancellationTokenSource m_tokenSource;
        private DateTime m_timeStamp = DateTime.MinValue;
        private Action<PendingEvent> m_dispatchedCallback = null;
        
        public PendingEvent(string eventName,string eventId, string eventJson)
        {
            EventName = eventName;
            Id = eventId;
            Json = eventJson;
        }

        public void CancelAndDispose()
        {
            if (m_tokenSource == null)
            {
                return;
            }
            
            m_tokenSource.Cancel();
            Dispose();
        }

        public float GetElapsedTime()
        {
            return (float)(DateTime.UtcNow - m_timeStamp).TotalSeconds;
        }

        public CancellationToken PrepareToSend(int requestTimeoutSeconds)
        {
            m_tokenSource = new CancellationTokenSource(requestTimeoutSeconds * 1000);
            m_timeStamp = DateTime.UtcNow;
            return m_tokenSource.Token;
        }

        public void Dispose()
        {
            if (m_tokenSource != null)
            {
                m_tokenSource.Dispose();
                m_tokenSource = null;
            }
        }

        /// <summary>
        /// Subscribe to know when the event has been dispatched. True if the dispatch was successful, false otherwise.
        /// </summary>
        public void NotifyOnDispatch(Action<PendingEvent> dispatched)
        {
            if (m_dispatchedCallback != null)
            {
                HomaGamesLog.Error("[ERROR] Subscribing twice to a pending event isn't supported. "+ EventName);
                return;
            }
            
            m_dispatchedCallback = dispatched;
        }

        public void Dispatched()
        {
            m_dispatchedCallback?.Invoke(this);
        }

        public override string ToString()
        {
            return !string.IsNullOrEmpty(Json) ? Json : $"{EventName} {Id}";
        }
    }
}