using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shard : MonoBehaviour
{
 
    [SerializeField] private AnimationCurve explosionCurve = AnimationCurve.Linear(0f, 0f, 1f, 1f);
    [SerializeField] private Vector2 animationSpeedRange = new Vector2(2f, 4f);
    [SerializeField] private Vector2 startSize = new Vector2(0.1f, 0.3f);

    private Collectible collectible;
    private Player player;

    public void Initialize(Player player, Collectible collectible) {
        this.player = player;

        this.collectible = collectible;
        collectible.onCollected.AddListener(Explode);
        transform.localScale = Vector3.one * Random.Range(startSize.x, startSize.y);
    }

    public void Explode() {
        StartCoroutine(ExplosionRoutine());
    }

    private IEnumerator ExplosionRoutine() {
        Vector3 startPos = transform.position;
        Vector3 randomPosition = startPos + Random.onUnitSphere * Random.Range(0.8f, 3f);
        float progress = 0f;
        float progressSpeed = Random.Range(animationSpeedRange.x, animationSpeedRange.y);


        while(progress < 1f) {

            progress = Mathf.Clamp01(progress + Time.deltaTime * progressSpeed);
            transform.position = Vector3.Lerp(startPos, randomPosition, progress);
            yield return null;
        }

        yield return new WaitForSeconds(0.5f);

        progress = 0f;
        while (progress < 1f) {
            progress = Mathf.Clamp01(progress + Time.deltaTime * 0.1f);
            transform.position = Vector3.Lerp(transform.position, player.transform.position, progress);
            yield return null;
        }

        Destroy(gameObject);
    }

}
