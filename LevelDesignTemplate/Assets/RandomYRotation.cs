using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomYRotation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        float rand = Random.Range(0, 360);
        Vector3 rot = transform.eulerAngles;
        rot.y = rand;
        transform.eulerAngles = rot;
    }

}
