using System;
using UnityEngine;

public class HitboxManager : MonoBehaviour
{

    [SerializeField]
    public float instantHitboxRadius = 10;
    [SerializeField]
    public LayerMask layer;

    public void SpawnHitbox(GameObject hitbox, Transform transform)
    {

    }

    public Collider[] SpawnInstantHitbox(Transform transform)
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, instantHitboxRadius, layer, QueryTriggerInteraction.Ignore);
        return colliders;
    }
}
