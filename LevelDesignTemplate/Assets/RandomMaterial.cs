using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMaterial : MonoBehaviour
{
    public List<Material> materials;
    public MeshRenderer meshRenderer;

    void Awake()
    {
        SetRandomMaterial();
    }

    void SetRandomMaterial()
    {
        if(meshRenderer != null)
        {
            Material randomMat = GetRandomMaterial(materials);
            if(randomMat != null)
            {
                meshRenderer.material = randomMat;
            }
        }
    }

    Material GetRandomMaterial(List<Material> mats)
    {
        if(mats.Count > 0)
        {
            int rand = Random.Range(0, mats.Count - 1);
            return mats[rand];
        }
        return null;
    }

}
