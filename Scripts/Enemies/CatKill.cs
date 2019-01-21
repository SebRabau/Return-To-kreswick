using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CatKill : MonoBehaviour
{
    public Text DPT;
    public AudioClip cat;
    public AudioClip catdie;

    private AudioSource audioSource;
    
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision a)
    {
        

        if (a.gameObject.CompareTag("Bullet"))
        {
            audioSource.PlayOneShot(catdie);
            FindObjectOfType<Movement>().UpdateDP();
            //Movement.DP++;
            DPT.gameObject.SetActive(true);
            IEnumerator add = HoldTimeTextc(DPT);
            StartCoroutine(add);
            gameObject.GetComponentInChildren<SkinnedMeshRenderer>().gameObject.SetActive(false);
            gameObject.GetComponent<BoxCollider>().enabled = false;
            Destroy(gameObject, 3f);

            Movement.dps += 2;
        } else
        {
            audioSource.PlayOneShot(cat);
        }
    }

    public IEnumerator HoldTimeTextc(Text a)
    {
        Debug.Log(a.gameObject.name);
        yield return new WaitForSeconds(2);
        a.gameObject.SetActive(false);        
    }
}
