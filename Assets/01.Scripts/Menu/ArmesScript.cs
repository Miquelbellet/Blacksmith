using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArmesScript : MonoBehaviour {
    public GameObject[] seleccionBtn;
    public GameObject[] obtenerBtn;
    public GameObject armesPanel;
    AudioSource MenuAS;
    public AudioClip buttonSound;
    string espasa1Obtenida, espasa2Obtenida, espasa3Obtenida, espasa4Obtenida, espasa5Obtenida;
    int espasaSelect, or, ferro, fusta;
    public Text orEsp1txt, ferroEsp1txt, fustaEsp1txt, orEsp2txt, ferroEsp2txt, fustaEsp2txt, orEsp3txt, ferroEsp3txt, fustaEsp3txt, orEsp4txt, ferroEsp4txt, fustaEsp4txt, orEsp5txt, ferroEsp5txt, fustaEsp5txt;
    int orEsp1, ferroEsp1, fustaEsp1, orEsp2, ferroEsp2, fustaEsp2, orEsp3, ferroEsp3, fustaEsp3, orEsp4, ferroEsp4, fustaEsp4, orEsp5, ferroEsp5, fustaEsp5;

	void Start () {
        GetMaterials();
        ConfigPanel();
        MenuAS = transform.GetChild(0).GetComponent<AudioSource>();
    }
	
	void Update () {
		
	}

    public void ConfigPanel()
    {
        BtnsObtener();
        BtnsObtenerActive();
        SelectEspasa();
    }
    void SelectEspasa()
    {
        espasaSelect = PlayerPrefs.GetInt("espasaSelec", 1);
        for (int i = 1; i <= seleccionBtn.Length; i++)
        {
            if (espasaSelect == i)
            {
                seleccionBtn[i - 1].GetComponent<Image>().color = new Color32(160, 255, 0, 255);
                Text[] btnTxt = seleccionBtn[i - 1].GetComponentsInChildren<Text>();
                if (PlayerPrefs.GetString("idioma", "none") == "castellano") btnTxt[0].text = "Listo";
                else if (PlayerPrefs.GetString("idioma", "none") == "catala") btnTxt[0].text = "Llest";
                else if (PlayerPrefs.GetString("idioma", "none") == "english") btnTxt[0].text = "Ready";
            }
            else {
                Text[] btnTxt = seleccionBtn[i - 1].GetComponentsInChildren<Text>();
                if (PlayerPrefs.GetString("idioma", "none") == "castellano") btnTxt[0].text = "Seleccionar";
                else if (PlayerPrefs.GetString("idioma", "none") == "catala") btnTxt[0].text = "Seleccionar";
                else if (PlayerPrefs.GetString("idioma", "none") == "english") btnTxt[0].text = "Select";
            }
        }
    }
    void BtnsObtener()
    {
        espasa1Obtenida = PlayerPrefs.GetString("espasa1Obtenida", "true");
        espasa2Obtenida = PlayerPrefs.GetString("espasa2Obtenida", "false");
        espasa3Obtenida = PlayerPrefs.GetString("espasa3Obtenida", "false");
        espasa4Obtenida = PlayerPrefs.GetString("espasa4Obtenida", "false");
        espasa5Obtenida = PlayerPrefs.GetString("espasa5Obtenida", "false");

        if (espasa1Obtenida == "true")
        {
            obtenerBtn[0].GetComponent<Image>().color = new Color32(160, 255, 0, 255);
            Text[] btnTxt = obtenerBtn[0].GetComponentsInChildren<Text>();
            if (PlayerPrefs.GetString("idioma", "none") == "castellano") btnTxt[0].text = "Hecha";
            else if (PlayerPrefs.GetString("idioma", "none") == "catala") btnTxt[0].text = "Feta";
            else if (PlayerPrefs.GetString("idioma", "none") == "english") btnTxt[0].text = "Done";
            seleccionBtn[0].GetComponent<Button>().interactable = true;
            seleccionBtn[0].GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        }
        else if (espasa1Obtenida == "false")
        {
            obtenerBtn[0].GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            Text[] btnTxt = obtenerBtn[0].GetComponentsInChildren<Text>();
            if (PlayerPrefs.GetString("idioma", "none") == "castellano") btnTxt[0].text = "Fabricar";
            else if (PlayerPrefs.GetString("idioma", "none") == "catala") btnTxt[0].text = "Fabricar";
            else if (PlayerPrefs.GetString("idioma", "none") == "english") btnTxt[0].text = "Fabricate";
            seleccionBtn[0].GetComponent<Button>().interactable = false;
            seleccionBtn[0].GetComponent<Image>().color = new Color32(255, 0, 0, 255);
        }

        if (espasa2Obtenida == "true")
        {
            obtenerBtn[1].GetComponent<Image>().color = new Color32(160, 255, 0, 255);
            Text[] btnTxt = obtenerBtn[1].GetComponentsInChildren<Text>();
            if (PlayerPrefs.GetString("idioma", "none") == "castellano") btnTxt[0].text = "Hecha";
            else if (PlayerPrefs.GetString("idioma", "none") == "catala") btnTxt[0].text = "Feta";
            else if (PlayerPrefs.GetString("idioma", "none") == "english") btnTxt[0].text = "Done";
            seleccionBtn[1].GetComponent<Button>().interactable = true;
            seleccionBtn[1].GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        }
        else if (espasa2Obtenida == "false")
        {
            obtenerBtn[1].GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            Text[] btnTxt = obtenerBtn[1].GetComponentsInChildren<Text>();
            if (PlayerPrefs.GetString("idioma", "none") == "castellano") btnTxt[0].text = "Fabricar";
            else if (PlayerPrefs.GetString("idioma", "none") == "catala") btnTxt[0].text = "Fabricar";
            else if (PlayerPrefs.GetString("idioma", "none") == "english") btnTxt[0].text = "Fabricate";
            seleccionBtn[1].GetComponent<Button>().interactable = false;
            seleccionBtn[1].GetComponent<Image>().color = new Color32(255, 0, 0, 255);
        }

        if (espasa3Obtenida == "true")
        {
            obtenerBtn[2].GetComponent<Image>().color = new Color32(160, 255, 0, 255);
            Text[] btnTxt = obtenerBtn[2].GetComponentsInChildren<Text>();
            if (PlayerPrefs.GetString("idioma", "none") == "castellano") btnTxt[0].text = "Hecha";
            else if (PlayerPrefs.GetString("idioma", "none") == "catala") btnTxt[0].text = "Feta";
            else if (PlayerPrefs.GetString("idioma", "none") == "english") btnTxt[0].text = "Done";
            seleccionBtn[2].GetComponent<Button>().interactable = true;
            seleccionBtn[2].GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        }
        else if (espasa3Obtenida == "false")
        {
            obtenerBtn[2].GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            Text[] btnTxt = obtenerBtn[2].GetComponentsInChildren<Text>();
            if (PlayerPrefs.GetString("idioma", "none") == "castellano") btnTxt[0].text = "Fabricar";
            else if (PlayerPrefs.GetString("idioma", "none") == "catala") btnTxt[0].text = "Fabricar";
            else if (PlayerPrefs.GetString("idioma", "none") == "english") btnTxt[0].text = "Fabricate";
            seleccionBtn[2].GetComponent<Button>().interactable = false;
            seleccionBtn[2].GetComponent<Image>().color = new Color32(255, 0, 0, 255);
        }

        if (espasa4Obtenida == "true")
        {
            obtenerBtn[3].GetComponent<Image>().color = new Color32(160, 255, 0, 255);
            Text[] btnTxt = obtenerBtn[3].GetComponentsInChildren<Text>();
            if (PlayerPrefs.GetString("idioma", "none") == "castellano") btnTxt[0].text = "Hecha";
            else if (PlayerPrefs.GetString("idioma", "none") == "catala") btnTxt[0].text = "Feta";
            else if (PlayerPrefs.GetString("idioma", "none") == "english") btnTxt[0].text = "Done";
            seleccionBtn[3].GetComponent<Button>().interactable = true;
            seleccionBtn[3].GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        }
        else if (espasa4Obtenida == "false")
        {
            obtenerBtn[3].GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            Text[] btnTxt = obtenerBtn[3].GetComponentsInChildren<Text>();
            if (PlayerPrefs.GetString("idioma", "none") == "castellano") btnTxt[0].text = "Fabricar";
            else if (PlayerPrefs.GetString("idioma", "none") == "catala") btnTxt[0].text = "Fabricar";
            else if (PlayerPrefs.GetString("idioma", "none") == "english") btnTxt[0].text = "Fabricate";
            seleccionBtn[3].GetComponent<Button>().interactable = false;
            seleccionBtn[3].GetComponent<Image>().color = new Color32(255, 0, 0, 255);
        }

        if (espasa5Obtenida == "true")
        {
            obtenerBtn[4].GetComponent<Image>().color = new Color32(160, 255, 0, 255);
            Text[] btnTxt = obtenerBtn[4].GetComponentsInChildren<Text>();
            if (PlayerPrefs.GetString("idioma", "none") == "castellano") btnTxt[0].text = "Hecha";
            else if (PlayerPrefs.GetString("idioma", "none") == "catala") btnTxt[0].text = "Feta";
            else if (PlayerPrefs.GetString("idioma", "none") == "english") btnTxt[0].text = "Done";
            seleccionBtn[4].GetComponent<Button>().interactable = true;
            seleccionBtn[4].GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        }
        else if (espasa5Obtenida == "false")
        {
            obtenerBtn[4].GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            Text[] btnTxt = obtenerBtn[4].GetComponentsInChildren<Text>();
            if (PlayerPrefs.GetString("idioma", "none") == "castellano") btnTxt[0].text = "Fabricar";
            else if (PlayerPrefs.GetString("idioma", "none") == "catala") btnTxt[0].text = "Fabricar";
            else if (PlayerPrefs.GetString("idioma", "none") == "english") btnTxt[0].text = "Fabricate";
            seleccionBtn[4].GetComponent<Button>().interactable = false;
            seleccionBtn[4].GetComponent<Image>().color = new Color32(255, 0, 0, 255);
        }
    }
    void BtnsObtenerActive()
    {
        if (or >= orEsp1 && ferro >= ferroEsp1 && fusta >= fustaEsp1 || espasa1Obtenida == "true")
        {
            obtenerBtn[0].GetComponent<Button>().interactable = true;
        }
        else
        {
            obtenerBtn[0].GetComponent<Button>().interactable = false;
            obtenerBtn[0].GetComponent<Image>().color = new Color32(255, 0, 0, 255);
        }
        if (or >= orEsp2 && ferro >= ferroEsp2 && fusta >= fustaEsp2 || espasa2Obtenida == "true")
        {
            obtenerBtn[1].GetComponent<Button>().interactable = true;
        }
        else
        {
            obtenerBtn[1].GetComponent<Button>().interactable = false;
            obtenerBtn[1].GetComponent<Image>().color = new Color32(255, 0, 0, 255);
        }
        if (or >= orEsp3 && ferro >= ferroEsp3 && fusta >= fustaEsp3 || espasa3Obtenida == "true")
        {
            obtenerBtn[2].GetComponent<Button>().interactable = true;
        }
        else
        {
            obtenerBtn[2].GetComponent<Button>().interactable = false;
            obtenerBtn[2].GetComponent<Image>().color = new Color32(255, 0, 0, 255);
        }
        if (or >= orEsp4 && ferro >= ferroEsp4 && fusta >= fustaEsp4 || espasa4Obtenida == "true")
        {
            obtenerBtn[3].GetComponent<Button>().interactable = true;
        }
        else
        {
            obtenerBtn[3].GetComponent<Button>().interactable = false;
            obtenerBtn[3].GetComponent<Image>().color = new Color32(255, 0, 0, 255);
        }
        if (or >= orEsp5 && ferro >= ferroEsp5 && fusta >= fustaEsp5 || espasa5Obtenida == "true")
        {
            obtenerBtn[4].GetComponent<Button>().interactable = true;
        }
        else
        {
            obtenerBtn[4].GetComponent<Button>().interactable = false;
            obtenerBtn[4].GetComponent<Image>().color = new Color32(255, 0, 0, 255);
        }
    }
    void GetMaterials()
    {
        or = PlayerPrefs.GetInt("or", 0);
        ferro = PlayerPrefs.GetInt("ferro", 0);
        fusta = PlayerPrefs.GetInt("fusta", 0);

        orEsp1 = 0;
        ferroEsp1 = 0;
        fustaEsp1 = 0;

        orEsp2 = 40;
        ferroEsp2 = 30;
        fustaEsp2 = 30;

        orEsp3 = 70;
        ferroEsp3 = 50;
        fustaEsp3 = 50;

        orEsp4 = 90;
        ferroEsp4 = 70;
        fustaEsp4 = 70;

        orEsp5 = 120;
        ferroEsp5 = 90;
        fustaEsp5 = 90;

        orEsp1txt.text = orEsp1+"";
        ferroEsp1txt.text = ferroEsp1+"";
        fustaEsp1txt.text = fustaEsp1 + "";

        orEsp2txt.text = orEsp2 + "";
        ferroEsp2txt.text = ferroEsp2 + "";
        fustaEsp2txt.text = fustaEsp2 + "";

        orEsp3txt.text = orEsp3 + "";
        ferroEsp3txt.text = ferroEsp3 + "";
        fustaEsp3txt.text = fustaEsp3 + "";

        orEsp4txt.text = orEsp4 + "";
        ferroEsp4txt.text = ferroEsp4 + "";
        fustaEsp4txt.text = fustaEsp4 + "";

        orEsp5txt.text = orEsp5 + "";
        ferroEsp5txt.text = ferroEsp5 + "";
        fustaEsp5txt.text = fustaEsp5 + "";
    }

    public void Espasa1Select()
    {
        MenuAS.PlayOneShot(buttonSound);
        espasaSelect = PlayerPrefs.GetInt("espasaSelec", 1);
        if (espasaSelect != 1)
        {
            seleccionBtn[espasaSelect - 1].GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            Text[] btnTxt = seleccionBtn[espasaSelect - 1].GetComponentsInChildren<Text>();
            if (PlayerPrefs.GetString("idioma", "none") == "castellano") btnTxt[0].text = "Seleccionar";
            else if (PlayerPrefs.GetString("idioma", "none") == "catala") btnTxt[0].text = "Seleccionar";
            else if (PlayerPrefs.GetString("idioma", "none") == "english") btnTxt[0].text = "Select";

            seleccionBtn[0].GetComponent<Image>().color = new Color32(160, 255, 0, 255);
            Text[] btnTxt2 = seleccionBtn[0].GetComponentsInChildren<Text>();
            if (PlayerPrefs.GetString("idioma", "none") == "castellano") btnTxt2[0].text = "Listo";
            else if (PlayerPrefs.GetString("idioma", "none") == "catala") btnTxt2[0].text = "Llest";
            else if (PlayerPrefs.GetString("idioma", "none") == "english") btnTxt2[0].text = "Ready";
        }
        PlayerPrefs.SetInt("espasaSelec", 1);
        armesPanel.SetActive(false);
    }
    public void Espasa2Select()
    {
        MenuAS.PlayOneShot(buttonSound);
        espasaSelect = PlayerPrefs.GetInt("espasaSelec", 1);
        if (espasaSelect != 2)
        {
            seleccionBtn[espasaSelect - 1].GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            Text[] btnTxt = seleccionBtn[espasaSelect - 1].GetComponentsInChildren<Text>();
            if (PlayerPrefs.GetString("idioma", "none") == "castellano") btnTxt[0].text = "Seleccionar";
            else if (PlayerPrefs.GetString("idioma", "none") == "catala") btnTxt[0].text = "Seleccionar";
            else if (PlayerPrefs.GetString("idioma", "none") == "english") btnTxt[0].text = "Select";

            seleccionBtn[1].GetComponent<Image>().color = new Color32(160, 255, 0, 255);
            Text[] btnTxt2 = seleccionBtn[1].GetComponentsInChildren<Text>();
            if (PlayerPrefs.GetString("idioma", "none") == "castellano") btnTxt2[0].text = "Listo";
            else if (PlayerPrefs.GetString("idioma", "none") == "catala") btnTxt2[0].text = "Llest";
            else if (PlayerPrefs.GetString("idioma", "none") == "english") btnTxt2[0].text = "Ready";
        }
        PlayerPrefs.SetInt("espasaSelec", 2);
        armesPanel.SetActive(false);

    }
    public void Espasa3Select()
    {
        MenuAS.PlayOneShot(buttonSound);
        espasaSelect = PlayerPrefs.GetInt("espasaSelec", 1);
        if (espasaSelect != 3)
        {
            seleccionBtn[espasaSelect - 1].GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            Text[] btnTxt = seleccionBtn[espasaSelect - 1].GetComponentsInChildren<Text>();
            if (PlayerPrefs.GetString("idioma", "none") == "castellano") btnTxt[0].text = "Seleccionar";
            else if (PlayerPrefs.GetString("idioma", "none") == "catala") btnTxt[0].text = "Seleccionar";
            else if (PlayerPrefs.GetString("idioma", "none") == "english") btnTxt[0].text = "Select";

            seleccionBtn[2].GetComponent<Image>().color = new Color32(160, 255, 0, 255);
            Text[] btnTxt2 = seleccionBtn[2].GetComponentsInChildren<Text>();
            if (PlayerPrefs.GetString("idioma", "none") == "castellano") btnTxt2[0].text = "Listo";
            else if (PlayerPrefs.GetString("idioma", "none") == "catala") btnTxt2[0].text = "Llest";
            else if (PlayerPrefs.GetString("idioma", "none") == "english") btnTxt2[0].text = "Ready";
        }
        PlayerPrefs.SetInt("espasaSelec", 3);
        armesPanel.SetActive(false);
    }
    public void Espasa4Select()
    {
        MenuAS.PlayOneShot(buttonSound);
        espasaSelect = PlayerPrefs.GetInt("espasaSelec", 1);
        if (espasaSelect != 4)
        {
            seleccionBtn[espasaSelect - 1].GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            Text[] btnTxt = seleccionBtn[espasaSelect - 1].GetComponentsInChildren<Text>();
            if (PlayerPrefs.GetString("idioma", "none") == "castellano") btnTxt[0].text = "Seleccionar";
            else if (PlayerPrefs.GetString("idioma", "none") == "catala") btnTxt[0].text = "Seleccionar";
            else if (PlayerPrefs.GetString("idioma", "none") == "english") btnTxt[0].text = "Select";

            seleccionBtn[3].GetComponent<Image>().color = new Color32(160, 255, 0, 255);
            Text[] btnTxt2 = seleccionBtn[3].GetComponentsInChildren<Text>();
            if (PlayerPrefs.GetString("idioma", "none") == "castellano") btnTxt2[0].text = "Listo";
            else if (PlayerPrefs.GetString("idioma", "none") == "catala") btnTxt2[0].text = "Llest";
            else if (PlayerPrefs.GetString("idioma", "none") == "english") btnTxt2[0].text = "Ready";
        }
        PlayerPrefs.SetInt("espasaSelec", 4);
        armesPanel.SetActive(false);
    }
    public void Espasa5Select()
    {
        MenuAS.PlayOneShot(buttonSound);
        espasaSelect = PlayerPrefs.GetInt("espasaSelec", 1);
        if (espasaSelect != 5)
        {
            seleccionBtn[espasaSelect - 1].GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            Text[] btnTxt = seleccionBtn[espasaSelect - 1].GetComponentsInChildren<Text>();
            if (PlayerPrefs.GetString("idioma", "none") == "castellano") btnTxt[0].text = "Seleccionar";
            else if (PlayerPrefs.GetString("idioma", "none") == "catala") btnTxt[0].text = "Seleccionar";
            else if (PlayerPrefs.GetString("idioma", "none") == "english") btnTxt[0].text = "Select";

            seleccionBtn[4].GetComponent<Image>().color = new Color32(160, 255, 0, 255);
            Text[] btnTxt2 = seleccionBtn[4].GetComponentsInChildren<Text>();
            if (PlayerPrefs.GetString("idioma", "none") == "castellano") btnTxt2[0].text = "Listo";
            else if (PlayerPrefs.GetString("idioma", "none") == "catala") btnTxt2[0].text = "Llest";
            else if (PlayerPrefs.GetString("idioma", "none") == "english") btnTxt2[0].text = "Ready";
        }
        PlayerPrefs.SetInt("espasaSelec", 5);
        armesPanel.SetActive(false);
    }

    public void Espasa1Obtener()
    {
        MenuAS.PlayOneShot(buttonSound);
        espasa1Obtenida = PlayerPrefs.GetString("espasa1Obtenida", "true");
        if (espasa1Obtenida == "false")
        {
            PlayerPrefs.SetString("espasa1Obtenida", "true");
            obtenerBtn[0].GetComponent<Image>().color = new Color32(160, 255, 0, 255);
            if (PlayerPrefs.GetString("idioma", "none") == "castellano") obtenerBtn[0].transform.GetChild(0).GetComponent<Text>().text = "Hecha";
            else if (PlayerPrefs.GetString("idioma", "none") == "catala") obtenerBtn[0].transform.GetChild(0).GetComponent<Text>().text = "Feta";
            else if (PlayerPrefs.GetString("idioma", "none") == "english") obtenerBtn[0].transform.GetChild(0).GetComponent<Text>().text = "Done";
            seleccionBtn[0].GetComponent<Button>().interactable = true;
            seleccionBtn[0].GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        }
    }
    public void Espasa2Obtener()
    {
        MenuAS.PlayOneShot(buttonSound);
        espasa2Obtenida = PlayerPrefs.GetString("espasa2Obtenida", "false");
        if (espasa2Obtenida == "false")
        {
            PlayerPrefs.SetString("espasa2Obtenida", "true");
            obtenerBtn[1].GetComponent<Image>().color = new Color32(160, 255, 0, 255);
            if (PlayerPrefs.GetString("idioma", "none") == "castellano") obtenerBtn[1].transform.GetChild(0).GetComponent<Text>().text = "Hecha";
            else if (PlayerPrefs.GetString("idioma", "none") == "catala") obtenerBtn[1].transform.GetChild(0).GetComponent<Text>().text = "Feta";
            else if (PlayerPrefs.GetString("idioma", "none") == "english") obtenerBtn[1].transform.GetChild(0).GetComponent<Text>().text = "Done";
            seleccionBtn[1].GetComponent<Button>().interactable = true;
            seleccionBtn[1].GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            ActualizarMaterials(orEsp2, ferroEsp2, fustaEsp2);
        }
    }
    public void Espasa3Obtener()
    {
        MenuAS.PlayOneShot(buttonSound);
        espasa3Obtenida = PlayerPrefs.GetString("espasa3Obtenida", "false");
        if (espasa3Obtenida == "false")
        {
            PlayerPrefs.SetString("espasa3Obtenida", "true");
            obtenerBtn[2].GetComponent<Image>().color = new Color32(160, 255, 0, 255);
            if (PlayerPrefs.GetString("idioma", "none") == "castellano") obtenerBtn[2].transform.GetChild(0).GetComponent<Text>().text = "Hecha";
            else if (PlayerPrefs.GetString("idioma", "none") == "catala") obtenerBtn[2].transform.GetChild(0).GetComponent<Text>().text = "Feta";
            else if (PlayerPrefs.GetString("idioma", "none") == "english") obtenerBtn[2].transform.GetChild(0).GetComponent<Text>().text = "Done";
            seleccionBtn[2].GetComponent<Button>().interactable = true;
            seleccionBtn[2].GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            ActualizarMaterials(orEsp3, ferroEsp3, fustaEsp3);
        }
    }
    public void Espasa4Obtener()
    {
        MenuAS.PlayOneShot(buttonSound);
        espasa4Obtenida = PlayerPrefs.GetString("espasa4Obtenida", "false");
        if (espasa4Obtenida == "false")
        {
            PlayerPrefs.SetString("espasa4Obtenida", "true");
            obtenerBtn[3].GetComponent<Image>().color = new Color32(160, 255, 0, 255);
            if (PlayerPrefs.GetString("idioma", "none") == "castellano") obtenerBtn[3].transform.GetChild(0).GetComponent<Text>().text = "Hecha";
            else if (PlayerPrefs.GetString("idioma", "none") == "catala") obtenerBtn[3].transform.GetChild(0).GetComponent<Text>().text = "Feta";
            else if (PlayerPrefs.GetString("idioma", "none") == "english") obtenerBtn[3].transform.GetChild(0).GetComponent<Text>().text = "Done";
            seleccionBtn[3].GetComponent<Button>().interactable = true;
            seleccionBtn[3].GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            ActualizarMaterials(orEsp4, ferroEsp4, fustaEsp4);
        }
    }
    public void Espasa5Obtener()
    {
        MenuAS.PlayOneShot(buttonSound);
        espasa5Obtenida = PlayerPrefs.GetString("espasa5Obtenida", "false");
        if (espasa5Obtenida == "false")
        {
            PlayerPrefs.SetString("espasa5Obtenida", "true");
            obtenerBtn[4].GetComponent<Image>().color = new Color32(160, 255, 0, 255);
            if (PlayerPrefs.GetString("idioma", "none") == "castellano") obtenerBtn[4].transform.GetChild(0).GetComponent<Text>().text = "Hecha";
            else if (PlayerPrefs.GetString("idioma", "none") == "catala") obtenerBtn[4].transform.GetChild(0).GetComponent<Text>().text = "Feta";
            else if (PlayerPrefs.GetString("idioma", "none") == "english") obtenerBtn[4].transform.GetChild(0).GetComponent<Text>().text = "Done";
            seleccionBtn[4].GetComponent<Button>().interactable = true;
            seleccionBtn[4].GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            ActualizarMaterials(orEsp5, ferroEsp5, fustaEsp5);
        }
    }
    void ActualizarMaterials(int orEsp, int ferroEsp, int fustaEsp)
    {
        or = PlayerPrefs.GetInt("or", 0);
        or -= orEsp;
        PlayerPrefs.SetInt("or", or);
        ferro = PlayerPrefs.GetInt("ferro", 0);
        ferro -= ferroEsp;
        PlayerPrefs.SetInt("ferro", ferro);
        fusta = PlayerPrefs.GetInt("fusta", 0);
        fusta -= fustaEsp;
        PlayerPrefs.SetInt("fusta", fusta);
        GetComponent<MenuScript>().GetMaterials();
    }
}
