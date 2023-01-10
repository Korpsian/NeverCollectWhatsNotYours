using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycaster : MonoBehaviour
{
    public LayerMask layerMask;


    private void Update()
    {
        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        Debug.DrawRay(transform.position + Vector3.up, transform.TransformDirection(Vector3.forward), Color.white);
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask))
        {
            if(hit.transform.TryGetComponent<RaycastReciver>(out RaycastReciver r))
            {
                r.Trigger();
            }
        }
    }
}
