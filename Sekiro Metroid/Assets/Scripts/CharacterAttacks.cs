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
    [SerializeField] private float attackDelay;
    private bool isAttacking;

    [SerializeField] private float attackRange;
    [SerializeField] private Transform attackPoint;
    [SerializeField] private LayerMask enemyLayer;


    // Start is called before the first frame update
    void Start()
    {
        isAttacking = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isAttacking == false)
        {
            if (Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.A))
            {
                Debug.Log("Low Attack");
                isAttacking = true;
                StartCoroutine(AttackDelay());
            }
            else if (Input.GetKey(KeyCode.A))
            {
                Debug.Log("Attacking");
                isAttacking = true;
                StartCoroutine(AttackDelay());
            }
        }
    }

    private void Attack()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);

        foreach(Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<CharacterStats>().Damage(attackValue);
        }
    }

    //Attack once every delay length
    public IEnumerator AttackDelay()
    {
        Attack();
        yield return new WaitForSeconds(attackDelay);
        isAttacking = false;
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
