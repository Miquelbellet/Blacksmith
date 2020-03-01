using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConfigScript : MonoBehaviour {
    public Slider efectsTogg, musicTogg;
    public Text efectsTxt, musicTxt, efectesText, musicaText, vivracionText, cinematicaText, configText, nomEsq1, nomEsq2, nomEsq3, nomMag1, nomMag2, videsObtener1, videsObtener2, maxvides;
    float efects, music;
    public Toggle vibrationTogg;
    string vibration, idioma;
    public GameObject catalanButt, castButt, engButt;
    public AudioClip buttonSound;

    private void Awake()
    {
        if (PlayerPrefs.GetString("idioma", "none") == "none")
        {
            if (Application.systemLanguage == SystemLanguage.English) PlayerPrefs.SetString("idioma", "english");
            else if (Application.systemLanguage == SystemLanguage.Spanish) PlayerPrefs.SetString("idioma", "castellano");
            else if (Application.systemLanguage == SystemLanguage.Catalan) PlayerPrefs.SetString("idioma", "catala");
        }
    }

    void Start () {
        SetConfig();
        SetLenguage();
    }
	
	void Update () {
		
	}

    void SetConfig()
    {
        efects = PlayerPrefs.GetFloat("efectsVol", 70.0f);
        efectsTogg.value = efects;
        efectsTxt.text = (int)efects + "%";
        transform.GetChild(0).GetComponent<AudioSource>().volume = efects*0.01f;

        music = PlayerPrefs.GetFloat("musicVol", 50);
        musicTogg.value = music;
        musicTxt.text = (int)music + "%";
        GetComponent<AudioSource>().volume = music*0.01f;

        vibration = PlayerPrefs.GetString("vibration", "true");
        if(vibration == "true") vibrationTogg.isOn = true;
        else if(vibration == "false") vibrationTogg.isOn = false;

        idioma = PlayerPrefs.GetString("idioma", "none");
        if (idioma == "catala") CatalanButtPress();
        else if (idioma == "castellano") CastButtPress();
        else if (idioma == "english") EngButtPress();
    }
    void SetLenguage()
    {
        if (PlayerPrefs.GetString("idioma", "none") == "castellano")
        {
            configText.text = "Configuración";
            efectesText.text = "Efectos";
            musicaText.text = "Música";
            vivracionText.text = "Vibración";
            cinematicaText.text = "Ver Cinemática";
            nomEsq1.text = "Esqueleto Nivel 1";
            nomEsq2.text = "Esqueleto Nivel 2";
            nomEsq3.text = "Esqueleto Nivel 3";
            nomMag1.text = "Mago Nivel 1";
            nomMag2.text = "Mago Nivel 2";
            videsObtener1.text = "Obtener";
            videsObtener2.text = "Obtener";
            maxvides.text = "*Número máximo de vidas 8.";
        }
        else if (PlayerPrefs.GetString("idioma", "none") == "catala")
        {
            configText.text = "Configuració";
            efectesText.text = "Efectes";
            musicaText.text = "Música";
            vivracionText.text = "Vibració";
            cinematicaText.text = "Veure Cinemàtica";
            nomEsq1.text = "Esquelet Nivell 1";
            nomEsq2.text = "Esquelet Nivell 2";
            nomEsq3.text = "Esquelet Nivell 3";
            nomMag1.text = "Mag Nivell 1";
            nomMag2.text = "Mag Nivell 2";
            videsObtener1.text = "Obtenir";
            videsObtener2.text = "Obtenir";
            maxvides.text = "*Número màxim de vides 8.";
        }
        else if (PlayerPrefs.GetString("idioma", "none") == "english")
        {
            configText.text = "Configuration";
            efectesText.text = "Efects";
            musicaText.text = "Music";
            vivracionText.text = "Vibration";
            cinematicaText.text = "See Cinematic";
            nomEsq1.text = "Skeleton Level 1";
            nomEsq2.text = "Skeleton Level 2";
            nomEsq3.text = "Skeleton Level 3";
            nomMag1.text = "Wizard Level 1";
            nomMag2.text = "Wizard Level 2";
            videsObtener1.text = "Obtain";
            videsObtener2.text = "Obtain";
            maxvides.text = "*Maximum number of lives 8.";
        }
    }
    public void EfectsChanged()
    {
        efects = efectsTogg.value;
        PlayerPrefs.SetFloat("efectsVol", efects);
        efectsTxt.text = (int)efects + "%";
        transform.GetChild(0).GetComponent<AudioSource>().volume = efects*0.01f;
    }
    public void MusicChanged()
    {
        music = musicTogg.value;
        PlayerPrefs.SetFloat("musicVol", music);
        musicTxt.text = (int)music + "%";
        GetComponent<AudioSource>().volume = music*0.01f;
    }
    public void VibrationChanged()
    {
        transform.GetChild(0).GetComponent<AudioSource>().PlayOneShot(buttonSound);
        if (vibrationTogg.isOn) PlayerPrefs.SetString("vibration", "true");
        else if(!vibrationTogg.isOn) PlayerPrefs.SetString("vibration", "false");
    }

    public void CatalanButtPress()
    {
        transform.GetChild(0).GetComponent<AudioSource>().PlayOneShot(buttonSound);
        PlayerPrefs.SetString("idioma", "catala");
        castButt.GetComponent<Image>().color = new Color32(255, 255, 255, 200);
        catalanButt.GetComponent<Image>().color = new Color32(200, 100, 0, 200);
        engButt.GetComponent<Image>().color = new Color32(255, 255, 255, 200);
        SetLenguage();
        GetComponent<ArmesScript>().ConfigPanel();
    }
    public void CastButtPress()
    {
        transform.GetChild(0).GetComponent<AudioSource>().PlayOneShot(buttonSound);
        PlayerPrefs.SetString("idioma", "castellano");
        castButt.GetComponent<Image>().color = new Color32(200, 100, 0, 200);
        catalanButt.GetComponent<Image>().color = new Color32(255, 255, 255, 200);
        engButt.GetComponent<Image>().color = new Color32(255, 255, 255, 200);
        SetLenguage();
        GetComponent<ArmesScript>().ConfigPanel();
    }
    public void EngButtPress()
    {
        transform.GetChild(0).GetComponent<AudioSource>().PlayOneShot(buttonSound);
        PlayerPrefs.SetString("idioma", "english");
        castButt.GetComponent<Image>().color = new Color32(255, 255, 255, 200);
        catalanButt.GetComponent<Image>().color = new Color32(255, 255, 255, 200);
        engButt.GetComponent<Image>().color = new Color32(200, 100, 0, 200);
        SetLenguage();
        GetComponent<ArmesScript>().ConfigPanel();
    }
    public void VerCinem()
    {
        PlayerPrefs.SetString("CinemConfig", "true");
        GetComponent<MenuScript>().VerCinematica();
    }
}
