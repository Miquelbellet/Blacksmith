using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeuScript : MonoBehaviour {
    Camera cam;

    void Start () {
        cam = Camera.main;
        transform.position = new Vector2(Random.Range(cam.transform.position.x-9, cam.transform.position.x+16), cam.transform.position.y+5);
	}
	
	void Update () {
        transform.position = new Vector2(transform.position.x-(3f*Time.deltaTime), transform.position.y-(Random.Range(5f, 6f)*Time.deltaTime));
        if (transform.position.y <= cam.transform.position.y - 6) Destroy(gameObject);
	}
}
