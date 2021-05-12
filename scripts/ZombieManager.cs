using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieManager : MonoBehaviour
{
    
    private int deathHash;
    public float attackRange;
    public NavMeshAgent agent;
    private Transform tf;
    public Transform player;
    public float timeBetweenAttacks;
    public LayerMask whatIsPlayer;
    bool playerInAttackRange;
    private float timeFromLastAttack;
    private Animator anim;
    private float health;
    bool dead;
    public GunManager gunScript;



    // Start is called before the first frame update
    void Start()
    {
       //anim = GetComponent<Animator>();
        deathHash = Animator.StringToHash("Z_FallingBack");
        agent = GetComponent<NavMeshAgent>();
        tf = GetComponent<Transform>();
        timeFromLastAttack = 10f;
        agent.SetDestination(player.position);
        anim = GetComponent<Animator>();
        health = 100;
        dead = false;
        //gunScript = GameObject.Find("Gun").GetComponent<GunManager>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timeFromLastAttack += Time.deltaTime;
        playerInAttackRange = (Vector3.Distance(tf.position, player.position)) < attackRange;
        Debug.Log("Player in attack range: " + playerInAttackRange);

        if(playerInAttackRange)
        {
            attack();
        }
        else
        {
            if (!dead )
            {
                Debug.Log("Chase entered");
                chase();
            }
            
        }
    }

    public void takeDamage(float dmg)
    {
        agent.SetDestination(tf.position);
        health -= dmg;
        if(health <= 0)
        {
            die();
        }

    }

    public void chase()
    {
        
        anim.ResetTrigger("attack");
        anim.ResetTrigger("idle");
        anim.SetTrigger("run");
        
        agent.SetDestination(player.position);
    }

    public void die()
    {
        if (!dead)
        {
            agent.SetDestination(tf.position);
            anim.SetTrigger("die");
            dead = true;
            gunScript.incrementScore();
            Invoke("despawn", 0.75f);
            

        }
        

        
    }

    public void attack()
    {
        

        
        Debug.Log("Attacking..");
        agent.SetDestination(tf.position);

        faceTarget();
        anim.ResetTrigger("run");
        anim.ResetTrigger("idle");
        anim.SetTrigger("attack");
        timeFromLastAttack = 0;
        
     
    }

    public void faceTarget()
    {
        Vector3 direction = (player.position - tf.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5);

    }

    public void despawn()
    {
        Destroy(gameObject);
    }

}
