using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DelayedTrigger : MonoBehaviour
{
    public float Delay;

    public UnityEvent OnCall;

    private Coroutine _coroutine;

    public void Call()
    {
        Cancel();

        _coroutine = StartCoroutine(CoCall());
    }

    public void Cancel()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
            _coroutine = null;
        }
    }

    private IEnumerator CoCall()
    {
        yield return new WaitForSeconds(Delay);

        OnCall.Invoke();
    }
}
