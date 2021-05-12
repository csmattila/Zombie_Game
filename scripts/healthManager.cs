using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class healthManager : MonoBehaviour
{
    private int health;
    public TextMeshProUGUI healthText;
    AudioSource source;
    public AudioClip hitSound;
    public GameObject deathMenu;
    public GunManager gunScript;
    public TextMeshProUGUI deathScoreText;

    // Start is called before the first frame update
    void Start()
    {
        health = 100;
        source = GetComponent<AudioSource>();


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.collider.tag);
        if(collision.collider.tag == "Zombie"){
            updateHealthText();
        }
    }

    public void updateHealthText()
    {
        health -= 25;
        if(health < 0)
        {
            playerDied();
        }
        healthText.text = "Health: " + health;
        source.PlayOneShot(hitSound);
        
    }

    public void playerDied()
    {
        Time.timeScale = 0f;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;


        deathMenu.SetActive(true);
        deathScoreText.text = "Your score is: " + gunScript.getScore();
    }
}
