using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectesFonsScript : MonoBehaviour {
    Camera cam;
    Vector3 initPos;
    float initPosX;
    float initPosY;
    public float velocitat;

	void Start () {
        cam = Camera.main;
        initPosX = cam.transform.position.x + 20;
        initPosY = Random.Range(2.0f, 4.0f);
    }
	
	void Update () {
        initPos = new Vector2(initPosX, initPosY);
        gameObject.transform.position = initPos;
        initPosX -= (velocitat*Time.deltaTime);
        float camPosDelete = cam.transform.position.x - 20;
        if (initPosX < camPosDelete)
        {
            Destroy(gameObject);
        }
    }
}
