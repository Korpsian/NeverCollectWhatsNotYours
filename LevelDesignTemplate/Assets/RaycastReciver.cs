using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RaycastReciver : MonoBehaviour
{
    public bool triggerd = false;
    public UnityEvent triggerEvents;

    //// Start is called before the first frame update
    //void Start()
    //{
        
    //}

    public void Trigger()
    {
        if(!triggerd)
        {
            triggerd = true;
            Debug.Log("LOOKED AT ME");
            triggerEvents.Invoke();
        }
    }

}
