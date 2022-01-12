using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletLogic : MonoBehaviour
{

    public float speed;
    public float lifeTime;
    public GameObject explosion;

    private Vector2 velocity;

    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Invoke("DestroyBullet", lifeTime);
        velocity = new Vector2(1.75f, 1.1f);
    }

    void DestroyBullet()
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        rb.MovePosition(transform.position + transform.up * speed * Time.fixedDeltaTime);
        //transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Enemy")
        {
            collision.gameObject.GetComponent<EnemyLogic>().TakeDamage(1);
            DestroyBullet();
        }
    }
}
