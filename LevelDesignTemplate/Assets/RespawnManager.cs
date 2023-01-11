using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RespawnManager : MonoBehaviour
{
    public Vector3 spawnPosition;
    [Space]
    public FirstPersonController controller;
    public Image blackPanel;
    public AudioSource respawnSFXSource;
    public List<AudioClip> respawnSounds;

    // Start is called before the first frame update
    void Start()
    {
        SetCheckpoint();
        StartCoroutine(SetImageAlpha(blackPanel, 0f));
        PlayRespawnSound();
    }

    void SetCheckpoint()
    {
        Debug.Log("SET checkpoint");
        spawnPosition = transform.position + Vector3.up;
    }

    IEnumerator MoveToCheckpoint()
    {
        Debug.Log("RESPAWN");
        controller.enabled = false;
        StartCoroutine(SetImageAlpha(blackPanel, 1f));
        PlayRespawnSound();

        yield return new WaitForSecondsRealtime(2f);
        transform.position = spawnPosition;
        StartCoroutine(SetImageAlpha(blackPanel, 0f));
        controller.enabled = true;
    }

    IEnumerator SetImageAlpha(Image panel, float alpha)
    {
        float lerp = 0f;
        Color startColor = panel.color;
        Color endColor = startColor;
        endColor.a = alpha;

        while(lerp < 1f)
        {
            panel.color = Color.Lerp(startColor, endColor, lerp);
            lerp += 0.1f;
            yield return new WaitForSeconds(0.01f);
        }
        panel.color = Color.Lerp(startColor, endColor, 1);

        yield break;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("HIT detected");
        if(other.tag == "SetCheckpoint")
        {
            SetCheckpoint();
        }

        if(other.tag == "Respawn")
        {
            StartCoroutine(MoveToCheckpoint());
        }
    }

    void PlayRespawnSound()
    {
        AudioClip clip = GetRandomClip(respawnSounds);

        if(respawnSFXSource != null && clip != null)
        {
            respawnSFXSource.PlayOneShot(clip);
        }
    }

    AudioClip GetRandomClip(List<AudioClip> clips)
    {
        if (clips.Count > 0)
        {
            int rand = Random.Range(0, clips.Count - 1);
            return clips[rand];
        }

        return null;
    }
}
