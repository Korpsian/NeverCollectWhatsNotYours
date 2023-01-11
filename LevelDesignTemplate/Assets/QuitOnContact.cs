using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitOnContact : MonoBehaviour
{


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Quit();
        }
    }

    void Quit()
    {
        Debug.Log("QUIT application");
        Application.Quit();
    }
}
