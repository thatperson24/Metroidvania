using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAttacks : MonoBehaviour
{
    enum Attacks
    {
        HIGH = 1,
        LOW = 2,
    }
    private Attacks attackType;
    [SerializeField] private float attackValue;

    [SerializeField] private float attackRange;
    [SerializeField] private Transform attackPoint;
    [SerializeField] private LayerMask enemyLayer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.A))
        {
            Debug.Log("Low Attack");
        }
        else if (Input.GetKey(KeyCode.A))
        {
            Debug.Log("Attacking");
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
