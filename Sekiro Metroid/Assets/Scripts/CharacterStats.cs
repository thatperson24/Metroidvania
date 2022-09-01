using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterStats : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    [SerializeField] private float maxStance;

    public Image healthBar;
    public float health, stance;
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        HealthBarFiller();
    }

    private void HealthBarFiller()
    {
        healthBar.fillAmount = health / maxHealth;
    }

    public void Damage(float damageVal)
    {
        health -= damageVal;
        if(health <= 0)
        {
            health = 0;
        }
    }
}
