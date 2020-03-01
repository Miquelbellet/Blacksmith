using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonScript : MonoBehaviour {
    public GameObject players;
    GameObject player;
    Vector2 playerPos, initMoonPos, moonPos;
    float temps;

    void Start () {
        BuscarPlayerActive();
        //transform.position = initMoonPos = new Vector2(8, 4);
    }
	
	void Update () {
        playerPos = player.transform.position;
        if (playerPos.x >= 0 && playerPos.x <= 245)
        {
            transform.position = new Vector2(playerPos.x - 4, 3.3f);
        }
    }

    void BuscarPlayerActive()
    {
        for (int i = 0; i < players.transform.childCount; i++)
        {
            if (players.transform.GetChild(i).gameObject.activeInHierarchy)
            {
                player = players.transform.GetChild(i).gameObject;
            }
        }
    }
}
