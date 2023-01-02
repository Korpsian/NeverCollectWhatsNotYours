using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DelayedEvent : MonoBehaviour
{
    [SerializeField] private bool triggerOnce = false;
    [SerializeField] private float delay = 0f;
    [SerializeField] private UnityEvent onTriggerEvent;

    private bool hasBeenTriggered = false;
    private Coroutine delayRoutine = null;
    public void Trigger() {
        if(triggerOnce == false || hasBeenTriggered == false) {

            if(delayRoutine != null) {
                StopCoroutine(delayRoutine);
                Debug.LogWarning("DelayedEvent delay routine has been interrupted: " + name, gameObject);
            }

            delayRoutine = StartCoroutine(TriggerDelayedEventsRoutine());
            hasBeenTriggered = true;
        }
    }

    private IEnumerator TriggerDelayedEventsRoutine() {
        yield return new WaitForSeconds(delay);
        onTriggerEvent.Invoke();
    }
}
