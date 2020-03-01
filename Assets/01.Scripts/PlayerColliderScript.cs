using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColliderScript : MonoBehaviour {
    public NivellsScript nivellsScript;
    public AudioSource efectesAS;
    public AudioClip magHit, mainHit;
    string[] enemics = new string[10];
    [HideInInspector]
    public bool oneHit, bossAttacking;
    string enemic;

    void Start () {
        enemics[0] = "Esq1";
        enemics[1] = "Esq2";
        enemics[2] = "Esq3";
        enemics[3] = "Mag1";
        enemics[4] = "Mag2";
        enemics[5] = "Boss1";
        enemics[6] = "Boss2";
        enemics[7] = "Boss3";
        enemics[8] = "Boss4";
        enemics[9] = "Boss5";
        oneHit = true;
        bossAttacking = false;
    }
	
	void Update () {
		
	}

    void OnTriggerStay2D(Collider2D other)
    {
        enemic = other.tag;
        if (other != null && !transform.parent.GetComponent<PlayerMainScript>().isDead)
        {
            if (other.tag == "Caiguda") nivellsScript.MainDead();
            else if (other.tag == "Esq1" || other.tag == "Esq2" || other.tag == "Esq3")
            {
                if (other.GetComponent<EsqueletScript>().isAttacking && oneHit)
                {
                    oneHit = false;
                    efectesAS.PlayOneShot(mainHit);
                    transform.parent.GetComponent<Animator>().SetTrigger("doHit");
                    if (PlayerPrefs.GetString("vibration", "true") == "true") Handheld.Vibrate();
                    nivellsScript.RestarVida(enemic);
                }
            }
            else if (other.tag == "Boss1" || other.tag == "Boss2" || other.tag == "Boss3" || other.tag == "Boss4" || other.tag == "Boss5")
            {
                if (bossAttacking && oneHit)
                {
                    oneHit = false;
                    efectesAS.PlayOneShot(mainHit);
                    transform.parent.GetComponent<Animator>().SetTrigger("doHit");
                    if (PlayerPrefs.GetString("vibration", "true") == "true") Handheld.Vibrate();
                    nivellsScript.RestarVida(enemic);
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        enemic = other.tag;
        if (other != null && !transform.parent.GetComponent<PlayerMainScript>().isDead)
        {
            if (other.tag == "Mag1" || other.tag == "Mag2")
            {
                efectesAS.PlayOneShot(magHit);
                transform.parent.GetComponent<Animator>().SetTrigger("doHit");
                if (PlayerPrefs.GetString("vibration", "true") == "true") Handheld.Vibrate();
                nivellsScript.RestarVida(enemic);
            }
        }  
    }
}
