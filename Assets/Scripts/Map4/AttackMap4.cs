using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackMap4 : MonoBehaviour
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
            EnemyHealthManager enemyHealth;
            enemyHealth = collision.GetComponent<EnemyHealthManager>();
            enemyHealth.HurtEnemy(damageToGive);
        }
        if (collision.CompareTag("Clone") && player.isAttack1())
        {
            CloneHealthManager cloneHealth;
            cloneHealth = collision.GetComponent<CloneHealthManager>();
            cloneHealth.HurtEnemy(damageToGive);
        }
    }
}
