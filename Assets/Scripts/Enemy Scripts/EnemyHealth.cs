using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    private float health = 100;

    private Enemy enemyScript;

    [SerializeField]
    private Slider enemyHealthSlider;

    private void Awake()
    {
        enemyScript = GetComponent<Enemy>();
    }

    public void TakeDamage(float damageAmount)
    {
        if (health <= 0)
            return;

        health -= damageAmount;

        if(health <= 0)
        {
            health = 0;

            //kill the enemy
            enemyScript.EnemyDied();
        }

        enemyHealthSlider.value = health;
    }
}
