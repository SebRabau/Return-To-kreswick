using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public GameObject Player;
    public GameObject FloatingText;
    
    private int health;
    private int maxhealth; //Could be used to health boss in future
    private int dps;

    [HideInInspector]
    //public bool isDead = false;
    public bool Follow = false;
    //private Animator anim;
    private CapsuleCollider capsule;
    private NavMeshAgent navMeshAgent;
    

    public float AttackDistance = 10f;


    public void InitStats(int a, int b)
    {
        health = a;
        maxhealth = a;
        dps = b;      

    }

    public void Awake()
    {
        //anim = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        capsule = GetComponent <CapsuleCollider>();
    }

    public void FixedUpdate()
    {
        if (navMeshAgent.enabled)
        {
            float dist = Vector3.Distance(Player.transform.position, this.transform.position);

            if (dist < AttackDistance)
            {
                FaceTarget();
                navMeshAgent.SetDestination(Player.transform.position);
                //anim.SetBool("Attack", false);
                //anim.SetBool("Follow", true);
            }
            else
            {
                //anim.SetBool("Attack", false);
                //anim.SetBool("Follow", false);
                navMeshAgent.SetDestination(transform.position);
            }

            if (dist < 5.0f)
            {
                FaceTarget();

                //anim.SetBool("Attack", true);
                //anim.SetBool("Follow", false);
            }
        }

    }

    void FaceTarget ()
    {
        Vector3 direction = (Player.transform.position - transform.position).normalized;
        Quaternion lookrotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookrotation, Time.deltaTime * 5f);

    }

    public void EndAttack()
    {
        float dist = Vector3.Distance(Player.transform.position, this.transform.position);
        if (dist < 3.0f)
        {
            Player.SendMessage("Damage", 4.0f, SendMessageOptions.DontRequireReceiver);
        }
    }
    
    public void TakeDamage(int dmg)
    {
        health -= dmg;

        //Trigger floating text
        if (FloatingText && health > 0)
        {
            ShowFloatingText();
        }

        if (health <= 0)
        {
            Dead();           
        }
    }

    void ShowFloatingText()
    {
        var go = Instantiate(FloatingText, transform.position, Quaternion.identity, transform);
        go.GetComponent<TextMesh>().text = health.ToString();
    }


    public int getHealth()
    {
        return health;
    }

    void Dead()
    {
        capsule.enabled = !capsule.enabled;
        navMeshAgent.enabled = !navMeshAgent.enabled;

        //anim.Play("Dead");
        //destroys the object, but waits 0.30 to let the animation play
        GameObject.Destroy(gameObject, 3f);
    }
}


    