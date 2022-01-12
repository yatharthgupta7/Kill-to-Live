using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public Animator anim;
    public float timer=5.0f; int n = 0;
    void Start()
    {
            
    }
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer<=0)
        {
            if (n == 1) n = 0;
            else if (n == 0) n =1;
            switch(n)
            {
                case 0:anim.SetTrigger("attack");
                    break;
                case 1:anim.SetTrigger("attack02");
                    break;
                default:anim.SetTrigger("attack02");
                    break;
            }
            timer = 5.0f;
        }
    }

    public void Play()
    {
        SceneManager.LoadScene("Game");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
