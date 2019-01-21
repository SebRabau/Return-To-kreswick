using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyV2 : MonoBehaviour {

    public GameObject Target;

    public int curHP;
    public int maxHP;

    //Attack
    public float AttackDistance;
    public int AttackDamage;
    [HideInInspector]
    public bool Follow = false;


    //
    private NavMeshAgent navMeshAgent;
    private Animator anim;
    private CapsuleCollider capsule;


    // Use this for initialization
    void Awake () {
        navMeshAgent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        capsule = GetComponent<CapsuleCollider>();
	}

    // Update is called once per frame
    //void Update () {
    //       if (!isDead)
    //       {
    //           if (Target ==)
    //       }

    //}

    void Update()
    {
        if (navMeshAgent.enabled)
        {
            FollowTarget();
        }


    }

    //void SearchForTarget()
    //{
    //    Vector3 center = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
    //    Collider[] hitColliders = Physics.OverlapSphere(center, 100);
    //    int i = 0;
    //    while (i < hitColliders.Length)
    //    {
    //        if (hitColliders[i].transform.tag =="Player")
    //        {
    //            Target = hitColliders[i].transform.gameObject;
    //        }
    //    }
    //}

    void FollowTarget()
    {
        FaceTarget();

        float distance = Vector3.Distance(Target.transform.position, this.transform.position);

        if (distance < AttackDistance)
        {
            navMeshAgent.SetDestination(Target.transform.position);
            anim.SetBool("Attack", false);
            anim.SetBool("Follow", true);
        }
        else
        {
            anim.SetBool("Attack", false);
            anim.SetBool("Follow", false);
            navMeshAgent.SetDestination(transform.position);
        }

        if (distance < 5.0f)
        {
            FaceTarget();

            AttackTarget();
        }
        

    }
    void FaceTarget()
    {
        Vector3 direction = (Target.transform.position - transform.position).normalized;
        Quaternion lookrotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookrotation, Time.deltaTime * 5f);

    }
    
    void AttackTarget ()
    {        
        anim.SetBool("Attack", true);
        anim.SetBool("Follow", false);       
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.tag == "Player")
    //    {
    //        Target.transform.GetComponent<PlayerHealth>().DoDamage(AttackDamage);
    //    }
    //}

    public void DoDamage (int dmg)
    {
        curHP -= dmg;

        print("damage done = " + dmg);
        print("enemy hp = " + dmg);

    }

    public void TakeDamage(int dmg)
    {
        curHP -= dmg;
        if (curHP <= 0)
        {
            Dead();
        }
    }

    public int getHealth()
    {
        return curHP;
    }

    void Dead()
    {
        capsule.enabled = !capsule.enabled;
        navMeshAgent.enabled = !navMeshAgent.enabled;

        anim.Play("Dead");
        //destroys the object, but waits 0.30 to let the animation play
        GameObject.Destroy(gameObject, 8f);
    }

    

}
