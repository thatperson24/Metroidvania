using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    [SerializeField] private int maxStamina;
    [SerializeField] private int health;
    [SerializeField] private int stamina;

    [SerializeField] private float attackRange;
    [SerializeField] private Transform attackPoint;
    [SerializeField] private LayerMask playerLayer;

    [SerializeField] private float attackDelay;
    [SerializeField] private Collider2D highHB;
    [SerializeField] private SpriteRenderer highSR; //Temporary, will be replaced with animation later
    [SerializeField] private Collider2D lowHB;
    [SerializeField] private SpriteRenderer lowSR; //Temporary, will be replaced with animation later

    private CharacterStats character;
    private bool isAttacking;
    private bool isAggroed;
    private float attackValue = 10f;
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        stamina = maxStamina;
        isAggroed = false;
        isAttacking = false;

        highHB.enabled = false;
        highSR.enabled = false;
        lowHB.enabled = false;
        lowSR.enabled = false;

        character = GameObject.Find("Character").GetComponent<CharacterStats>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Physics2D.OverlapCircle(attackPoint.position, attackRange, playerLayer) && isAttacking == false)
        {
            Debug.Log("ahh");
            StartCoroutine(AttackDelay());
            
        }
    }

    public void StartAggro()
    {
        isAggroed = true;
    }

    public void Attack()
    {
        int attackOption = Random.Range(0, 2); //0 is high, 1 is low
        Debug.Log("attack value: " + attackOption);
        isAttacking = true;
        if(attackOption == 0)
        {
            highHB.enabled = true;
            highSR.enabled = true;
        } 
        else
        {
            lowHB.enabled = true;
            lowSR.enabled = true;
        }
        character.Damage(attackValue);
    }

    public void ResetAttack()
    {
        highHB.enabled = false;
        highSR.enabled = false;
        lowHB.enabled = false;
        lowSR.enabled = false;
        isAttacking = false;
    }

    public IEnumerator AttackDelay()
    {
        Attack();
        yield return new WaitForSeconds(attackDelay);
        ResetAttack();
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
