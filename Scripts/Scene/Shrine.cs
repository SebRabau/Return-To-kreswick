using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shrine : MonoBehaviour {

    private bool collected = false;
    private bool timing = false;
    private bool inside = false;

    public Text picking;
    public Text collectLP;
    public Text LPT;
    public AudioClip rise;
    public GameObject player;
	
	// Update is called once per frame
	void FixedUpdate () {
        if(!inside)
        {
            collectLP.gameObject.SetActive(false);
        }        
    }

    void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            collectLP.gameObject.SetActive(true);
            inside = true;

            if (Input.GetKey(KeyCode.E))
            {       
                if (!timing)
                {
                    IEnumerator timer = HoldTime(2f);
                    StartCoroutine(timer);
                    timing = true;

                    Debug.Log("Trying");

                    collected = false;

                    player.GetComponent<AudioSource>().PlayOneShot(rise, 0.3f);

                    picking.gameObject.SetActive(true);
                }
            }
        }
        inside = false;
    }

    void Collect()
    {
        FindObjectOfType<Movement>().UpdateLP();
        LPT.gameObject.SetActive(true);
        IEnumerator add = Movement.HoldTimeText(LPT);
        StartCoroutine(add);
        Destroy(gameObject, 3f);
    }

    private IEnumerator HoldTime(float a)
    {
        yield return new WaitForSeconds(a);
        collectLP.gameObject.SetActive(false);
        timing = false;
        Collect();
        picking.gameObject.SetActive(false);
        player.GetComponent<AudioSource>().Stop();
    }
}
