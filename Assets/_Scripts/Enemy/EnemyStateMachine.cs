using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine : MonoBehaviour
{
    public enum State { Idle, Run };
    public State state = State.Idle;

    public void SetState(object _newState)
    {
        state = (State)_newState;
    }
}
