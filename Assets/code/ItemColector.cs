using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemColector : MonoBehaviour
{
    [SerializeField] private AudioSource colectSoundEffect;
    [SerializeField] private Text bananasText;
    public static int banana;

    private void Start()
    {
        banana = PlayerPrefs.GetInt("Score");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Fruit"))
        {
           
            colectSoundEffect.Play();
            Destroy(collision.gameObject);
            banana++;
            

            bananasText.text = ("Bananas:" + banana);
        }

    }
}
