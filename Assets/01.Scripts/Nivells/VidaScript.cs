using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VidaScript : MonoBehaviour {
    float time;

	void Start () {
        transform.GetChild(0).gameObject.SetActive(true);
	}
	
	void Update () {
        time += Time.deltaTime;
        if (time >= 1) gameObject.SetActive(false);
	}
}
