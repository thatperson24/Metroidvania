using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    [SerializeField] private int maxStamina;
    [SerializeField] private int health;
    [SerializeField] private int stamina;

    //---All attack Stuff
    [SerializeField] private float attackRange;
    [SerializeField] private Transform attackPoint;
    [SerializeField] private LayerMask playerLayer;

    [SerializeField] private float attackDelay;
    [SerializeField] private Collider2D highHB; //hitbox for high attacks
    [SerializeField] private SpriteRenderer highSR; //Temporary, will be replaced with animation later
    [SerializeField] private Collider2D lowHB; //hitbox for low attacks
    [SerializeField] private SpriteRenderer lowSR; //Temporary, will be replaced with animation later

    private CharacterStats character;
    private bool isAttacking;
    private bool isAggroed;
    private float attackValue = 10f;
    //-----
    
    void Start()
    {
        health = maxHealth;
        stamina = maxStamina;
        isAggroed = false;
        isAttacking = false;

        // disabling the attack hitboxes and sprites
        highHB.enabled = false;
        highSR.enabled = false;
        lowHB.enabled = false;
        lowSR.enabled = false;

        character = GameObject.Find("Character").GetComponent<CharacterStats>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Checking if player is in range and if enemy is already attacking to prevent multiple attacks
        if (Physics2D.OverlapCircle(attackPoint.position, attackRange, playerLayer) && isAttacking == false)
        {
            StartCoroutine(AttackDelay());   
        }
    }

    //Not used yet but gets aggro'd if player enters trigger
    public void StartAggro()
    {
        isAggroed = true;
    }

    //randomly selects attack options and activates hitbox accordingly
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

    //Reset all attack hitboxes and isAttacking boolean so enemy can attack again
    public void ResetAttack()
    {
        highHB.enabled = false;
        highSR.enabled = false;
        lowHB.enabled = false;
        lowSR.enabled = false;
        isAttacking = false;
    }

    //Attack once every delay length
    public IEnumerator AttackDelay()
    {
        Attack();
        yield return new WaitForSeconds(attackDelay);
        ResetAttack();
    }

    //Draws where the attack point is and the radius of it.
    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
