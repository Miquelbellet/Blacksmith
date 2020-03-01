using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VidesScript : MonoBehaviour {
    public GameObject videsPanel;
    AudioSource MenuAS;
    public AudioClip buttonSound;
    public Text orVida1, orVida2;
    public Button obtenerVida1, obtenerVida2;
    int vides, costVida1, costVida2, or;

	void Start () {
        or = PlayerPrefs.GetInt("or", 0);
        if (or < costVida1) {
            obtenerVida1.interactable = false;
        } else if (or >= costVida1) {
            obtenerVida1.interactable = true;
        }

        if (or < costVida2) {
            obtenerVida2.interactable = false;
        } else if (or >= costVida2)
        {
            obtenerVida2.interactable = true;
        }
        MenuAS = transform.GetChild(0).GetComponent<AudioSource>();
        costVida1 = 50;
        costVida2 = 90;
        comprobarVides();
        SetTextGold();
    }
	
	void Update () {
        
    }

    void SetTextGold()
    {
        orVida1.text = costVida1 + "";
        orVida2.text = costVida2 + "";
    }

    public void ObtenerMitadVida()
    {
        MenuAS.PlayOneShot(buttonSound);
        if (or >= costVida1)
        {
            or -= costVida1;
            PlayerPrefs.SetInt("or", or);
            GetComponent<MenuScript>().GetMaterials();

            vides = PlayerPrefs.GetInt("vides", 8);
            vides++;
            PlayerPrefs.SetInt("vides", vides);
            videsPanel.SetActive(false);
            comprobarVides();
        }
    }

    public void ObtenerUnaVida()
    {
        MenuAS.PlayOneShot(buttonSound);
        if (or >= costVida2)
        {
            or -= costVida2;
            PlayerPrefs.SetInt("or", or);
            GetComponent<MenuScript>().GetMaterials();

            vides = PlayerPrefs.GetInt("vides", 8);
            vides += 2;
            PlayerPrefs.SetInt("vides", vides);
            videsPanel.SetActive(false);
            comprobarVides();
        }
    }

    void comprobarVides()
    {
        vides = PlayerPrefs.GetInt("vides", 8);
        if (vides >= 16 || or < costVida1) obtenerVida1.interactable = false;
        if (vides >= 15 || or < costVida2) obtenerVida2.interactable = false;
    }
}
