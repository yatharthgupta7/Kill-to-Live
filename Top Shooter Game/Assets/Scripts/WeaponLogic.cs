using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponLogic : MonoBehaviour
{
    public GameObject bullet;
    public Transform shotPoint;
    public float timeBtwShots;

    private float shotTime;

    Animator cameraAnim;

    public bool canShoot=true;
    void Start()
    {
        cameraAnim = Camera.main.GetComponent<Animator>();
    }

    void Update()
    {
        if(canShoot)
        {
            Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
            transform.rotation = rotation;



            if (Input.GetMouseButton(0))
            {
                if (Time.time >= shotTime)
                {
                    Shoot();
                    //cameraAnim.SetTrigger("Shake");
                }
            }
        }
        else
        {
            Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
            transform.rotation = rotation;



            if (Input.GetMouseButton(0))
            {
                if (Time.time >= shotTime)
                {
                    Shoot();
                    //cameraAnim.SetTrigger("Shake");
                }
            }

        }
    }

    public void Shoot()
    {
        GameObject b=Instantiate(bullet, shotPoint.position, transform.rotation);
        //b.transform.eulerAngles = new Vector3(0, 0, -90);
        shotTime = Time.time + timeBtwShots;
    }
}
