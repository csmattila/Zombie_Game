using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GunManager : MonoBehaviour
{
    // Start is called before the first frame update
    private float gunDamage;
    public Camera cam;
    public ParticleSystem flash;
    private AudioSource shootingSound;
    private float timeDelay;
    float timePassed;
    private int score;
    public TextMeshProUGUI scoreText;

    public GameObject ak47;
    public GameObject m4a1;
    public GameObject ump45;

    public float ak47timeDelay;
    public float m4a1timeDelay;
    public float ump45timeDelay;

    public AudioClip ak47Sound;
    public AudioClip m4a1Sound;
    public AudioClip ump45Sound;

    public float ak47Damage;
    public float m4a1Damage;
    public float ump45Damage;


    void Start()
    {
    
        shootingSound = GetComponent<AudioSource>();
        //timeDelay = 0.1f;
        timePassed = 0f;
        score = 0;
        //setWeapon("m4a1");
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetButton("Fire1"))
        {
            shoot();
        }
    }

    public int getScore()
    {
        return score;
    }


    void shoot()
    {
        timePassed += Time.deltaTime;

        if (timePassed >= timeDelay)
        {
            shootingSound.Play();
            flash.Play();
            timePassed = 0;
        
            RaycastHit hit;
            if(Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, 500))
            {
                Debug.Log(hit.transform.name);
                if(hit.transform.gameObject.tag  == "Zombie")
                {
                    hit.transform.gameObject.GetComponent<ZombieManager>().takeDamage(gunDamage);
                }
            }
        
        }

        
    }

    public void setWeapon(string name)
    {
        shootingSound = GetComponent<AudioSource>();
        Debug.Log("Gun name received in setWeapon is " + name);
        if (name == "ump45")
        {
            ump45.SetActive(true);
            ak47.SetActive(false);
            m4a1.SetActive(false);

            
            timeDelay = ump45timeDelay;
            gunDamage = ump45Damage;
            shootingSound.clip = ump45Sound;
            

        }
        else if (name == "ak47")
        {
            ump45.SetActive(false);
            ak47.SetActive(true);
            m4a1.SetActive(false);

            shootingSound.clip = ak47Sound;
            timeDelay = ak47timeDelay;
            gunDamage = ak47Damage;
            
        }
        else
        {
            ump45.SetActive(false);
            ak47.SetActive(false);
            m4a1.SetActive(true);

            shootingSound.clip = m4a1Sound;
            timeDelay = m4a1timeDelay;
            gunDamage = m4a1Damage;
            

        }
    }


    public void incrementScore()
    {
        
        score += 1;
        scoreText.text = "Score: " + score;

    }
}
