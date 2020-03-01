using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MaterialScript : MonoBehaviour {
    public AudioSource efectesAS;
    public Text orTxt, ferroTxt, fustaTxt;
    public AudioClip materialSound;
    int rand, or, ferro, fusta;
    bool esquelet;

	void Start () {
        esquelet = true;
        if (transform.parent.tag == "Esq1") rand = Random.Range(2, 5);
        else if (transform.parent.tag == "Esq2" || transform.parent.tag == "Mag1") rand = Random.Range(4, 7);
        else if (transform.parent.tag == "Esq3" || transform.parent.tag == "Mag2") rand = Random.Range(6, 10);
        else esquelet = false;
        GetComponent<BoxCollider2D>().enabled = false;
    }
	
	void Update () {
		if(GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime >= GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length)
        {
            GetComponent<BoxCollider2D>().enabled = true;
        }
    }

    void ObtenirMaterial()
    {
        if (transform.tag == "Or")
        {
            or = PlayerPrefs.GetInt("or", 0);
            rand = Random.Range(4, 7);
            or += rand;
            PlayerPrefs.SetInt("or", or);
        }
        else if (transform.tag == "Ferro")
        {
            ferro = PlayerPrefs.GetInt("ferro", 0);
            rand = Random.Range(4, 7);
            ferro += rand;
            PlayerPrefs.SetInt("ferro", ferro);
        }
        else if (transform.tag == "Fusta")
        {
            fusta = PlayerPrefs.GetInt("fusta", 0);
            rand = Random.Range(4, 7);
            fusta += rand;
            PlayerPrefs.SetInt("fusta", fusta);
        }
    }

    public void GetMaterials()
    {
        or = PlayerPrefs.GetInt("or", 0);
        orTxt.text = or + "";
        ferro = PlayerPrefs.GetInt("ferro", 0);
        ferroTxt.text = ferro + "";
        fusta = PlayerPrefs.GetInt("fusta", 0);
        fustaTxt.text = fusta + "";
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "PlayerCollider")
        {
            if(!esquelet) ObtenirMaterial();
            else
            {
                or = PlayerPrefs.GetInt("or", 0);
                or += rand;
                PlayerPrefs.SetInt("or", or);
            }
            GetMaterials();
            efectesAS.PlayOneShot(materialSound);
            Destroy(gameObject);
        }
    }
}
