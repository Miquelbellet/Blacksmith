using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformMovingScript : MonoBehaviour {
    float time;
    Vector2 platformPos;
    public float timeMove;
    public bool beguinRight;

	void Start () {
        platformPos = transform.position;
	}
	
	void Update () {
        time += Time.deltaTime;
        if (beguinRight)
        {
            if (time <= timeMove)
            {
                platformPos.x += 4f * Time.deltaTime;
                transform.position = platformPos;
            }
            else
            {
                time = 0;
                beguinRight = false;
            }
        }
        else if (!beguinRight)
        {
            if (time <= timeMove)
            {
                platformPos.x -= 4f * Time.deltaTime;
                transform.position = platformPos;
            }
            else
            {
                time = 0;
                beguinRight = true;
            }
        }
	}
}
