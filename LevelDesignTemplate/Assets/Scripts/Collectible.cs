using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Collectible : MonoBehaviour
{
    [SerializeField] Player player;

    [SerializeField] MeshRenderer mesh;
    [SerializeField] Light light;

    [Header("Movement")]
    [SerializeField] private Vector3 movement;
    [SerializeField] private float movementSpeed = 1f;

    [Header("Rotation")]
    [SerializeField, Tooltip("Rotation in axis per second")] private Vector3 rotation;

    [Header("Splash")]
    [SerializeField] private List<Shard> shards = new List<Shard>();

    public UnityEvent onCollected;

    private bool hasExploded = false;

    private Vector3 startPos;

    private void Start() {
        startPos = transform.position;
        foreach(Shard shard in shards) {
            shard.Initialize(player, this);
        }
    }

    private void Update() {
        if(hasExploded == false) {
            transform.position = startPos + Mathf.Sin(Time.time * movementSpeed) * movement;
            transform.Rotate(rotation * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (hasExploded == false) {
            mesh.enabled = false;
            light.enabled = false;
            onCollected.Invoke();
            hasExploded = true;
            player.NotifyCOllectedCollectible(transform.position);
        }

    }
}
