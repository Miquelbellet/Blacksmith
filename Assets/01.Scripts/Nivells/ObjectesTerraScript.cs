using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectesTerraScript : MonoBehaviour {
    public GameObject players;
    PlayerMainScript player;
    Vector3 objectPos;
    public float velocity;

    void Start()
    {
        BuscarPlayerActive();
    }

    void Update()
    {
        if (player.moveMontains)
        {
            objectPos = transform.position;
            if (player.playerMove == "Right")
            {
                objectPos.x -= velocity * (player.velocity * Time.deltaTime);
                transform.position = objectPos;
            }
            else if (player.playerMove == "Left")
            {
                objectPos.x += velocity * (player.velocity * Time.deltaTime);
                transform.position = objectPos;
            }
        }
    }

    void BuscarPlayerActive()
    {
        for (int i = 0; i < players.transform.childCount; i++)
        {
            if (players.transform.GetChild(i).gameObject.activeInHierarchy)
            {
                player = players.transform.GetChild(i).gameObject.GetComponent<PlayerMainScript>();
            }
        }
    }
}
