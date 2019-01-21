using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OneWayGate : MonoBehaviour {

    public GameObject target;
    public GameObject checker;
    public Text ww;

    public bool condition = false; //Change in editor

    void Update()
    {
        if(condition)
        {
            if(!target.GetComponent<BoxCollider>().isTrigger)
            {
                //If target path blocked, block this path too
                gameObject.GetComponent<BoxCollider>().isTrigger = false; 
            }
        }

        //If checker is triggered, block path
        if(checker.gameObject.name.Equals("Triggered")) {
            checker.gameObject.name = "Path Blocked";
            gameObject.GetComponent<BoxCollider>().isTrigger = false;
        }
    }

    //Older code, possible bug being player can get locked out
    /*
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //Block path
            Debug.Log("Blocking");
            StartCoroutine("Block");
        }
    }
    */

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //Wrong Way popup
            ww.gameObject.SetActive(true);
            IEnumerator add = Movement.HoldTimeText(ww);
            StartCoroutine(add); 
        }
    }

    private IEnumerator Block()
    {
        yield return new WaitForSeconds(1);
        gameObject.GetComponent<BoxCollider>().isTrigger = false;
    }
}
