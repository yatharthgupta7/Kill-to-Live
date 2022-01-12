using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerLogic : MonoBehaviour
{

    public float speed;
    public int health;
    private Rigidbody2D rb;

    private Vector2 moveAmount;

    public Animator anim;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    public GameObject deathMenu;

    public WeaponLogic weapon;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector2 moveInput = new Vector2(SimpleInput.GetAxis("Horizontal"), SimpleInput.GetAxis("Vertical"));
        moveAmount = moveInput.normalized * speed;
        if(moveInput.Equals(Vector2.zero))
        {
            anim.SetBool("Walk",false);
            weapon.canShoot = true;
        }
        else
        {
            anim.SetBool("Walk", true);
            weapon.canShoot = false;
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveAmount * Time.fixedDeltaTime);
    }


    public void TakeDamage(int damage)
    {
        health -= damage;
        UpdateHealthUI(health);
        if (health <= 0)
        {
            Destroy(gameObject);
            deathMenu.SetActive(true);
        }
    }

    void UpdateHealthUI(int currenHealth)
    {
        for(int i=0;i<hearts.Length;i++)
        {
            if(i<currenHealth)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }
        }
    }

    public void Heal(int healAmount)
    {
        if(health+healAmount>5)
        {
            health = 5;
        }
        else
        {
            health += healAmount;
        }
        UpdateHealthUI(health);
    }

    public void Play()
    {
        SceneManager.LoadScene("Game");
        Time.timeScale = 1;
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1;
    }

    public void Quit()
    {
        Application.Quit();
    }
}
