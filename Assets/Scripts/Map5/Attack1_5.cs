using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack1_5 : MonoBehaviour
{
    PlayerController player;
    public int damageToGive = 5;

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
            EnemyHealthManagement enemyHealth;
            enemyHealth = collision.GetComponent<EnemyHealthManagement>();
            enemyHealth.HurtEnemy(damageToGive);
        }
    }
}
