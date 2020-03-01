using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbMagScript : MonoBehaviour {
    Vector2 pos;
    float time, velocity;
    bool attDreta;

	void Start () {
        velocity = 4f;
        pos = transform.position;
        if(transform.parent.parent.tag == "Mag1Collider" || transform.parent.parent.tag == "Mag2Collider") attDreta = transform.parent.parent.GetComponent<MagsScript>().attackDreta;
        else if(transform.parent.parent.tag == "Boss4Collider") attDreta = transform.parent.parent.GetComponent<Boss4Script>().attackDreta;
        else if(transform.parent.parent.tag == "Boss5") attDreta = transform.parent.parent.GetComponent<Boss5Script>().attackDreta;
    }
	
	void Update () {
        time += Time.deltaTime;
        if (attDreta)
        {
            pos.x += velocity*Time.deltaTime;
            transform.position = pos;
        }
        else
        {
            pos.x -= velocity*Time.deltaTime;
            transform.position = pos;
        }
        if (time >= 3) Destroy(gameObject);
	}
}
