using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Feedbacks;

public class RandomizeInitialDelay : MonoBehaviour
{
    public MMF_Player player;
    public float minRandom = 1;
    public float maxRandom = 10;


    // Start is called before the first frame update
    void Start()
    {
        SetInitialDelay(player);
    }

    void SetInitialDelay(MMF_Player p)
    {
        if(p != null)
        {
            p.InitialDelay = Random.Range(minRandom, maxRandom);
        }
    }


}
