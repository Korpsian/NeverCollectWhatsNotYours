using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector3 lastSavepoint;
    private Vector3 startPosition;


    private void Start() {
        lastSavepoint = transform.position;
    }


    public void Kill() {
        transform.position = lastSavepoint;
    }

    public void NotifyCOllectedCollectible(Vector3 position) {
        lastSavepoint = position;
    }
}
