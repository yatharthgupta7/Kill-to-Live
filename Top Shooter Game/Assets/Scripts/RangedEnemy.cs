using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemy : EnemyLogic
{
    public float stopDistance;
    private float atackTime = 0;

    public Animator anim;
    public Transform shotPoint;

    public GameObject enemyBullet;
    public override void Start()
    {
        base.Start();
        anim.GetComponent<Animator>();
    }
    void Update()
    {
        if(player!=null)
        {
            if(Vector2.Distance(transform.position,player.position) > stopDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);

            }
        }

        if(Time.time>=atackTime)
        {
            atackTime = Time.time + timeBetweenAttack;
            anim.SetTrigger("Attack");
        }
    }

    public void RangedAttack()
    {

        Vector2 direction = player.position - shotPoint.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        shotPoint.rotation = rotation;

        Instantiate(enemyBullet, shotPoint.position, shotPoint.rotation);
    }
}
