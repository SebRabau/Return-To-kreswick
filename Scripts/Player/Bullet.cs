using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public ParticleSystem expPrefab;

    void OnCollisionEnter(Collision Object)
    {
        if (Object.gameObject.CompareTag("Enemy"))
        {
            GameObject hit = Object.gameObject;
            int health = hit.GetComponent<Enemy>().getHealth();

            if (health > 0)
            {

                hit.GetComponent<Enemy>().TakeDamage(Movement.dps + (Movement.DP * 5));
                hit.SendMessage("Hit",4.0f, SendMessageOptions.DontRequireReceiver);
            }

            var exp = (ParticleSystem)Instantiate(
            expPrefab,
            gameObject.transform.position,
            gameObject.transform.rotation);

            Destroy(gameObject);
            exp.Play();            
        }
        else
        {
            
            var exp = (ParticleSystem)Instantiate(
            expPrefab,
            gameObject.transform.position,
            gameObject.transform.rotation);

            Destroy(gameObject);
            exp.Play();            
        }
    }
}
