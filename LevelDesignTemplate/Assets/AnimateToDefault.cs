using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Feedbacks;
using System;

public class AnimateToDefault : MonoBehaviour
{
    Vector3 defaultRotation;
    Vector3 defaultScale;
    Vector3 defaultPosition;
    MeshRenderer meshRenderer;
    Material defaultMaterial;

    public Material untriggerdMaterial;
    public Transform targetTransform;
    [Space]
    public MMF_Player playerToStop;
    [Space]
    public MMF_Player animationPlayer;

    private void Awake()
    {
        Setup();
    }

    public void Setup()
    {
        defaultRotation = targetTransform.eulerAngles;
        defaultScale = targetTransform.localScale;
        defaultPosition = targetTransform.position;
        
        if(targetTransform.TryGetComponent<MeshRenderer>(out meshRenderer)) {
            defaultMaterial = meshRenderer.material;
            meshRenderer.material = untriggerdMaterial;
        }
    }

    public void Trigger()
    {
        StopActivAnimation();
        SetupDefaultAnimation(animationPlayer);
        PlayDefaultAnimation();
        StartCoroutine(SetDefaultMaterial(1));
    }

    IEnumerator SetDefaultMaterial(float delay)
    {
        yield return new WaitForSecondsRealtime(delay);
        if(meshRenderer != null)
        {
            meshRenderer.material = defaultMaterial;
        }
    }

    private void PlayDefaultAnimation()
    {
        if(animationPlayer != null)
        {
            animationPlayer.PlayFeedbacks();
        }
    }

    private void SetupDefaultAnimation(MMF_Player animationPlayer)
    {
        if(animationPlayer != null)
        {
            //MMF_Position p = animationPlayer.GetFeedbackOfType<MMF_Position>();
            //if (p != null)
            //{
            //    p.DestinationPosition = defaultPosition;
            //}
            MMF_Rotation r = animationPlayer.GetFeedbackOfType<MMF_Rotation>();
            if(r != null)
            {
                r.DestinationAngles = defaultRotation;
            }
            MMF_Scale s = animationPlayer.GetFeedbackOfType<MMF_Scale>();
            if(s != null)
            {
                s.DestinationScale = defaultScale;
            }
        }
    }

    private void StopActivAnimation()
    {
        if(playerToStop != null)
        {
            playerToStop.StopFeedbacks();
        }
    }
}
