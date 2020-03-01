using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CofreScript : MonoBehaviour {
    GameObject[] materials = new GameObject[3];

	void Start () {
        for (int i=0; i<transform.childCount; i++)
        {
            materials[i] = transform.GetChild(i).gameObject;
            materials[i].SetActive(false);
        }
    }
	
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "PlayerCollider" && other != null)
        {
            GetComponent<Animator>().SetTrigger("activateCofre");
            for (int i = 0; i < transform.childCount; i++)
            {
                if (materials[i] != null)
                {
                    materials[i].SetActive(true);
                    if (materials[i].tag == "Or") materials[i].GetComponent<Animator>().SetTrigger("activateOr");
                    else if (materials[i].tag == "Ferro") materials[i].GetComponent<Animator>().SetTrigger("activateFerro");
                    else if (materials[i].tag == "Fusta") materials[i].GetComponent<Animator>().SetTrigger("activateFusta");
                }
            }
        }
    }
}
