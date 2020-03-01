using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour {
    public GameObject admob;
    public GameObject configPanel, personatgesPanel, armesPanel, videsPanel, loadCinematca1, loadNivell1, loadNivell2, loadNivell3, loadNivell4, loadNivell5;
    public GameObject[] menuButtons;
    AudioSource MenuAS;
    public AudioClip buttonSound;
    public Scrollbar persScrollBar, armesScrollBar;
    public Text orTxt, ferroTxt, fustaTxt;
    [HideInInspector]
    public int or, ferro, fusta;
    public GameObject level1Img, level2Img, level3Img, level4Img, level5Img, level2FImg, level3FImg, level4FImg, level5FImg;
    string cinematicLevel1, level2FActive, level3FActive, level4FActive, level5FActive;
    public Transform nuvolsEmpty;
    public GameObject[] nuvolsPrefab;
    public GameObject ocellPrefab;
    public Button flexaDreta, flexaEsq;

    private void Awake()
    {
        if (PlayerPrefs.GetString("menuTutorial") == "false") admob.SetActive(true);
        ActiveButtons();
        ActiveLevels();
    }

    void Start () {
        Social.localUser.Authenticate((bool success) => {
            Debug.Log("Result: "+success);
        });

        GetMaterials();
        ResizeContPanels();
        MenuAS = transform.GetChild(0).GetComponent<AudioSource>();
        InvokeRepeating("Nuvols", 1, 5);
        InvokeRepeating("Ocell", 1, 7);
    }
	
	void Update () {
        AmagarFlexesPersonatges();
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
    void ActiveLevels()
    {
        level2FActive = PlayerPrefs.GetString("level2FActive", "false");
        level3FActive = PlayerPrefs.GetString("level3FActive", "false");
        level4FActive = PlayerPrefs.GetString("level4FActive", "false");
        level5FActive = PlayerPrefs.GetString("level5FActive", "false");

        if (level2FActive == "true") level2FImg.SetActive(false);
        else if(level2FActive == "false") level2FImg.SetActive(true);

        if (level3FActive == "true") level3FImg.SetActive(false);
        else if (level3FActive == "false") level3FImg.SetActive(true);

        if (level4FActive == "true") level4FImg.SetActive(false);
        else if (level4FActive == "false") level4FImg.SetActive(true);

        if (level5FActive == "true") level5FImg.SetActive(false);
        else if (level5FActive == "false") level5FImg.SetActive(true);

        if(level2FActive == "false")
        {
            level1Img.GetComponent<Animator>().SetBool("levelActive", true);
            level2Img.GetComponent<Animator>().SetBool("levelActive", false);
            level3Img.GetComponent<Animator>().SetBool("levelActive", false);
            level4Img.GetComponent<Animator>().SetBool("levelActive", false);
            level5Img.GetComponent<Animator>().SetBool("levelActive", false);
        }
        else if (level2FActive == "true" && level3FActive == "false" && level4FActive == "false" && level5FActive == "false")
        {
            level1Img.GetComponent<Animator>().SetBool("levelActive", false);
            level2Img.GetComponent<Animator>().SetBool("levelActive", true);
            level3Img.GetComponent<Animator>().SetBool("levelActive", false);
            level4Img.GetComponent<Animator>().SetBool("levelActive", false);
            level5Img.GetComponent<Animator>().SetBool("levelActive", false);
        }
        else if (level2FActive == "true" && level3FActive == "true" && level4FActive == "false" && level5FActive == "false")
        {
            level1Img.GetComponent<Animator>().SetBool("levelActive", false);
            level2Img.GetComponent<Animator>().SetBool("levelActive", false);
            level3Img.GetComponent<Animator>().SetBool("levelActive", true);
            level4Img.GetComponent<Animator>().SetBool("levelActive", false);
            level5Img.GetComponent<Animator>().SetBool("levelActive", false);
        }
        else if (level2FActive == "true" && level3FActive == "true" && level4FActive == "true" && level5FActive == "false")
        {
            level1Img.GetComponent<Animator>().SetBool("levelActive", false);
            level2Img.GetComponent<Animator>().SetBool("levelActive", false);
            level3Img.GetComponent<Animator>().SetBool("levelActive", false);
            level4Img.GetComponent<Animator>().SetBool("levelActive", true);
            level5Img.GetComponent<Animator>().SetBool("levelActive", false);
        }
        else if (level2FActive == "true" && level3FActive == "true" && level4FActive == "true" && level5FActive == "true")
        {
            level1Img.GetComponent<Animator>().SetBool("levelActive", false);
            level2Img.GetComponent<Animator>().SetBool("levelActive", false);
            level3Img.GetComponent<Animator>().SetBool("levelActive", false);
            level4Img.GetComponent<Animator>().SetBool("levelActive", false);
            level5Img.GetComponent<Animator>().SetBool("levelActive", true);
        }
    }
    void ActiveButtons()
    {
        foreach (GameObject btn in menuButtons) btn.SetActive(true);
        configPanel.SetActive(false);
        personatgesPanel.SetActive(false);
        armesPanel.SetActive(false);
        videsPanel.SetActive(false);
        loadCinematca1.SetActive(false);
        loadNivell1.SetActive(false);
        loadNivell2.SetActive(false);
        loadNivell3.SetActive(false);
        loadNivell4.SetActive(false);
        loadNivell5.SetActive(false);
    }
    void Nuvols()
    {
        Instantiate(nuvolsPrefab[UnityEngine.Random.Range(0, 5)], nuvolsEmpty);
    }
    void Ocell()
    {
        Instantiate(ocellPrefab, nuvolsEmpty);
    }

    void ResizeContPanels()
    {
        float WidthPersonPanel = personatgesPanel.GetComponent<RectTransform>().rect.width;
        float HeightPersonPanel = personatgesPanel.GetComponent<RectTransform>().rect.height;
        Transform contPesons = personatgesPanel.transform.GetChild(2);
        contPesons.GetComponent<RectTransform>().sizeDelta = new Vector2(WidthPersonPanel - 92, HeightPersonPanel - 92);

        float WidthArmesPanel = armesPanel.GetComponent<RectTransform>().rect.width;
        float HeightArmesPanel = armesPanel.GetComponent<RectTransform>().rect.height;
        Transform contArmes = armesPanel.transform.GetChild(2);
        contArmes.GetComponent<RectTransform>().sizeDelta = new Vector2(WidthArmesPanel - 92, HeightArmesPanel - 100);
    }
    void AmagarFlexesPersonatges()
    {
        if (persScrollBar.value >= 1)
        {
            flexaDreta.gameObject.SetActive(false);
            flexaEsq.gameObject.SetActive(true);
        }
        else if (persScrollBar.value <= 0)
        {
            flexaDreta.gameObject.SetActive(true);
            flexaEsq.gameObject.SetActive(false);
        }
        else
        {
            flexaDreta.gameObject.SetActive(true);
            flexaEsq.gameObject.SetActive(true);
        }
    }
    public void FlexaDretaPersonatges()
    {
        persScrollBar.value += 0.2f;
    }
    public void FlexaEsqPersonatges()
    {
        persScrollBar.value -= 0.2f;
    }

    public void ShowConfigPanel() {
        MenuAS.PlayOneShot(buttonSound);
        configPanel.SetActive(true);
    }
    public void HideConfigPanel(){
        configPanel.SetActive(false);
    }
    public void ShowArmesPanel()
    {
        MenuAS.PlayOneShot(buttonSound);
        armesPanel.SetActive(true);
        armesScrollBar.value = 0;
    }
    public void HideArmesPanel()
    {
        armesPanel.SetActive(false);
    }
    public void ShowPersonatgesPanel()
    {
        MenuAS.PlayOneShot(buttonSound);
        personatgesPanel.SetActive(true);
        persScrollBar.value = 0;
    }
    public void HidePersonatgesPanel()
    {
        personatgesPanel.SetActive(false);
    }
    public void ShowVidesPanel()
    {
        MenuAS.PlayOneShot(buttonSound);
        videsPanel.SetActive(true);
    }
    public void HideVidesPanel()
    {
        videsPanel.SetActive(false);
    }
    public void VerCinematica()
    {
        loadCinematca1.SetActive(true);
    }

    public void Level1()
    {
        MenuAS.PlayOneShot(buttonSound);
        cinematicLevel1 = PlayerPrefs.GetString("cinematicLevel1", "true");
        if (cinematicLevel1 == "true")
        {
            PlayerPrefs.SetString("CinemConfig", "false");
            loadCinematca1.SetActive(true);
        }
        else if (cinematicLevel1 == "false") loadNivell1.SetActive(true);
    }
    public void Level2()
    {
        MenuAS.PlayOneShot(buttonSound);
        loadNivell2.SetActive(true);
    }
    public void Level3()
    {
        MenuAS.PlayOneShot(buttonSound);
        loadNivell3.SetActive(true);
    }
    public void Level4()
    {
        MenuAS.PlayOneShot(buttonSound);
        loadNivell4.SetActive(true);
    }
    public void Level5()
    {
        MenuAS.PlayOneShot(buttonSound);
        loadNivell5.SetActive(true);
    }
}
