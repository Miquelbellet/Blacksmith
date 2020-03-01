using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ConfiguraNivellScript : MonoBehaviour {
    public GameObject configPanel, loadMenu;
    public Slider efectsTogg, musicTogg;
    public Text efectsTxt, musicTxt, efectesText, musicaText, vibracioText, menuText, panelDeadText;
    float efects, music;
    public Toggle vibrationTogg;
    string vibration;
    public AudioClip buttonSound;

    void Start () {
        SetConfig();
        configPanel.SetActive(false);
    }
	
	void Update () {
		
	}

    void SetConfig()
    {
        efects = PlayerPrefs.GetFloat("efectsVol", 70.0f);
        efectsTogg.value = efects;
        efectsTxt.text = (int)efects + "%";
        transform.GetChild(0).GetComponent<AudioSource>().volume = efects * 0.01f;

        music = PlayerPrefs.GetFloat("musicVol", 50.0f);
        musicTogg.value = music;
        musicTxt.text = (int)music + "%";
        GetComponent<AudioSource>().volume = music * 0.01f;

        vibration = PlayerPrefs.GetString("vibration", vibration);
        if (vibration == "true") vibrationTogg.isOn = true;
        else if (vibration == "false") vibrationTogg.isOn = false;

        if (PlayerPrefs.GetString("idioma", "english") == "castellano")
        {
            efectesText.text = "Efectos";
            musicaText.text = "Música";
            vibracioText.text = "Vibración";
            menuText.text = "Volver al Menú";
            panelDeadText.text = "¡Has Muerto!";
        }
        else if (PlayerPrefs.GetString("idioma", "english") == "catala")
        {
            efectesText.text = "Efectes";
            musicaText.text = "Música";
            vibracioText.text = "Vibració";
            menuText.text = "Tornar al Menú";
            panelDeadText.text = "Has Mort!";
        }
        else if (PlayerPrefs.GetString("idioma", "english") == "english")
        {
            efectesText.text = "Efects";
            musicaText.text = "Music";
            vibracioText.text = "Vibration";
            menuText.text = "Back to Menu";
            panelDeadText.text = "You Died!";
        }
    }

    public void EfectsChanged()
    {
        efects = efectsTogg.value;
        PlayerPrefs.SetFloat("efectsVol", efects);
        efectsTxt.text = (int)efects + "%";
        transform.GetChild(0).GetComponent<AudioSource>().volume = efects * 0.01f;
    }
    public void MusicChanged()
    {
        music = musicTogg.value;
        PlayerPrefs.SetFloat("musicVol", music);
        musicTxt.text = (int)music + "%";
        GetComponent<AudioSource>().volume = music * 0.01f;
    }
    public void VibrationChanged()
    {
        transform.GetChild(0).GetComponent<AudioSource>().PlayOneShot(buttonSound);
        if (vibrationTogg.isOn) PlayerPrefs.SetString("vibration", "true");
        else if (!vibrationTogg.isOn) PlayerPrefs.SetString("vibration", "false");
    }

    public void BackToMenu()
    {
        transform.GetChild(0).GetComponent<AudioSource>().PlayOneShot(buttonSound);
        loadMenu.SetActive(true);
    }
    public void ShowConfigPanel()
    {
        transform.GetChild(0).GetComponent<AudioSource>().PlayOneShot(buttonSound);
        configPanel.SetActive(true);
    }
    public void HideConfigPanel()
    {
        configPanel.SetActive(false);
    }
}
