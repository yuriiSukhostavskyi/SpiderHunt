using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class StartMoveEnvironment : MonoBehaviour
{
    private float _randomTime;
    private Vector3 _startPosition;

    private void OnEnable()
    {
        _randomTime = Random.Range(0.2f, 1.36f);

        _startPosition = transform.localPosition;

        transform.localPosition = _startPosition - Vector3.up * 5;

        transform.DOLocalJump(_startPosition, 6f, 1, _randomTime);

        FinishAction.OnFinished += FinishMove;
    }

    private void FinishMove()
    {
        Invoke(nameof(FinishMoveAction), 1f);
    }

    private void FinishMoveAction()
    {
        transform.DOLocalMoveY(_startPosition.y - 5, _randomTime);
    }

    private void OnDisable()
    {
        FinishAction.OnFinished -= FinishMove;
    }
}
