using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerPlayer : MonoBehaviour
{
    [SerializeField] private bool triggerOnce;
    [SerializeField] private UnityEvent onPlayerEnter;
    [SerializeField] private UnityEvent onPlayerExit;

    private bool hasTriggered;

    private void OnTriggerEnter(Collider other) {
        if(triggerOnce == false || hasTriggered == false) {
            onPlayerEnter.Invoke();
            hasTriggered = true;
        }

    }

    private void OnTriggerExit(Collider other) {
        if (triggerOnce == false || hasTriggered == false) {
            onPlayerExit.Invoke();
            hasTriggered = true;
        }
    }
}
