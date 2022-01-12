using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLogic : MonoBehaviour
{
    public int health;
    public int damage;

    public float speed;
    public float timeBetweenAttack;

    public Transform player;

    public int healthPickupChance;
    public GameObject playerHealth;

    public GameObject explosion;
    public virtual void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }


    public void TakeDamage(int damage)
    {
        health -= damage;
        if(health<=0)
        {
            Destroy(gameObject);
            Instantiate(explosion, transform.position, transform.rotation);

            int randomHealth = Random.Range(0, 101);
            if (randomHealth < healthPickupChance)
            {
                Instantiate(playerHealth, transform.position, Quaternion.identity);
            }
        }
    }
}
