using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderBossSrcript : MonoBehaviour {

    void Start () {
        transform.parent.GetComponent<BoxCollider2D>().isTrigger = true;
    }
	
	void Update () {
		
	}


    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player") transform.parent.GetComponent<BoxCollider2D>().isTrigger = false;
    }
}
