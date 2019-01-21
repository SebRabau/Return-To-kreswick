using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enable : MonoBehaviour {

    public AudioClip fight;
    public AudioClip calm;
    public GameObject music;

    public GameObject monsters;

    private bool check = false;

    // Use this for initialization
    //void Start () {
    //    monsters.SetActive(false);
    //}

    // Update is called once per frame
    void Update () {
        CapsuleCollider[] group = monsters.GetComponentsInChildren<CapsuleCollider>();

        if(group.Length == 0 && !check)
        {
            music.GetComponent<AudioSource>().Stop();
            music.GetComponent<AudioSource>().PlayOneShot(calm, 0.3f);
            check = true;
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            music.GetComponent<AudioSource>().Stop();            
            music.GetComponent<AudioSource>().PlayOneShot(fight, 0.3f);
            //monsters.SetActive(true);
        }
    }
}
