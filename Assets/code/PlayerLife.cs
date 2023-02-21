using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour
{
    public static int death;
    [SerializeField] private AudioSource deathSoundEffect;
    private Animator anim;
    [SerializeField] private Text deathText;
    private void Start()
    {
        anim = GetComponent<Animator>();
        transform.parent = null;
        death = PlayerPrefs.GetInt("DeathScore");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
           
            Die();

        }
        if (collision.gameObject.CompareTag("Platform") && transform.position.y > collision.gameObject.transform.position.y)
        {
            transform.parent = collision.gameObject.transform;
        }
        else
        {
            transform.parent = null;
        }
        
    }



    private void Die()
    {

        deathSoundEffect.Play();
        GetComponent<PlayerMove>().state = PlayerMove.MovementState.death;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}