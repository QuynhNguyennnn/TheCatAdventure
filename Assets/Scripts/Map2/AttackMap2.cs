using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackMap2 : MonoBehaviour
{
    PlayerController player;
    public int damageToGive = 2;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") && player.isAttack1())
        {
            SkeletonHealManagement enemyHealth;
            enemyHealth = collision.GetComponent<SkeletonHealManagement>();
            enemyHealth.HurtEnemy(damageToGive);
        }

        if (collision.CompareTag("SkeletonBoss") && player.isAttack1())
        {
            SkeletonBossHealthManagement enemyHealth;
            enemyHealth = collision.GetComponent<SkeletonBossHealthManagement>();
            enemyHealth.HurtEnemy(damageToGive);
        }


    }
}
