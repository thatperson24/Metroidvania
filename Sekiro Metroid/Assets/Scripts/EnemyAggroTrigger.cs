using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAggroTrigger : MonoBehaviour
{
    [SerializeField] private EnemyController ec;

    private void OnTriggerEnter2D(Collider2D other)
    {
        ec.StartAggro();
    }
}
