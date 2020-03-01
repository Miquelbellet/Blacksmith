using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbBossScript : MonoBehaviour {
    Vector2 pos;
    Rigidbody2D rbOrb;
    float time, forceOrb;
    bool prefabDreta, attDreta;

	void Start () {
        forceOrb = 50f;
        pos = transform.position;
        rbOrb = transform.GetComponent<Rigidbody2D>();
        attDreta = transform.parent.parent.GetComponent<Boss4Script>().attackDreta;
        if (transform.parent.name == "MultiOrbs1") prefabDreta = false;
        else if(transform.parent.name == "MultiOrbs2") prefabDreta = true;
        if (attDreta)
        {
            if (prefabDreta) rbOrb.AddForce(new Vector2(-forceOrb, forceOrb), ForceMode2D.Impulse);
            else rbOrb.AddForce(new Vector2(forceOrb, forceOrb), ForceMode2D.Impulse);
        }
        else if (!attDreta)
        {
            if (prefabDreta) rbOrb.AddForce(new Vector2(forceOrb, forceOrb), ForceMode2D.Impulse);
            else rbOrb.AddForce(new Vector2(-forceOrb, forceOrb), ForceMode2D.Impulse);

        }
    }
	
	void Update () {
        time += Time.deltaTime;
        if (time >= 3) Destroy(gameObject);
	}
}
