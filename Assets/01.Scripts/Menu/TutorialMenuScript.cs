using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialMenuScript : MonoBehaviour {
    public GameObject panelNegre, panelPers, panelArmes, panelVides, panelNivells, flexaPers, flexaArmes, flexaVides, panelText, vellImg, canvasTutorial;
    public GameObject[] flexesNivells;
    public Text tutorialText;
    bool doTutorial, donePresentation, donePersonatges, doneArmes, doneVides, doneNivells;
    float temps;

	void Start () {

        if (PlayerPrefs.GetString("menuTutorial", "true") == "true")
        {
            doTutorial = true;
            canvasTutorial.SetActive(true);
            FirstPanels();
        }
        else if(PlayerPrefs.GetString("menuTutorial", "true") == "false")
        {
            doTutorial = false;
            canvasTutorial.SetActive(false);
        }
        donePresentation = false;
        donePersonatges = false;
        doneArmes = false;
        doneVides = false;
        doneNivells = false;
    }
	
	void Update () {
        if (PlayerPrefs.GetString("menuTutorial", "true") == "true")
        {
            if (doTutorial)
            {
                if (!donePresentation && !donePersonatges && !doneArmes && !doneVides && !doneNivells)
                {
                    if (PlayerPrefs.GetString("idioma", "none") == "castellano") tutorialText.text = "¡Hola! Soy tu ayudnate Jondun. Ahora te enseñaré como funciona el menu.";
                    else if(PlayerPrefs.GetString("idioma", "none") == "catala") tutorialText.text = "Hola! Sóc el teu ajudant Jondun. Ara t'ensenyaré com funciona el menu.";
                    else if(PlayerPrefs.GetString("idioma", "none") == "english") tutorialText.text = "Hello! I'm your assistant Jondun. Now I will show you how the menu works.";
                    if (Input.touchCount > 0)
                    {
                        Touch touch = Input.GetTouch(0);
                        if(touch.phase == TouchPhase.Began) donePresentation = true;
                    }
                    else if (Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Mouse1))
                    {
                        donePresentation = true;
                    }
                }
                else if (donePresentation && !donePersonatges && !doneArmes && !doneVides && !doneNivells)
                {
                    panelNegre.SetActive(false);
                    panelPers.SetActive(true);
                    flexaPers.SetActive(true);
                    if (PlayerPrefs.GetString("idioma", "none") == "castellano") tutorialText.text = "Este és el botón de 'Personajes' para ver todos los personajes que hay en el juego. Aunque tu siempre jugarás con el mismo!";
                    else if (PlayerPrefs.GetString("idioma", "none") == "catala") tutorialText.text = "Aquest és el botó de 'Personatges' per veure tots els personatges que hi ha al joc. Encara que tu sempre jugaràs amb el mateix!";
                    else if (PlayerPrefs.GetString("idioma", "none") == "english") tutorialText.text = "This is the 'Characters' button to see all the characters that are in the game. Although you will always play with the same one!";
                    if (Input.touchCount > 0)
                    {
                        Touch touch = Input.GetTouch(0);
                        if (touch.phase == TouchPhase.Began) donePersonatges = true;
                    }
                    else if (Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Mouse1))
                    {
                        donePersonatges = true;
                    }
                }
                else if (donePresentation && donePersonatges && !doneArmes && !doneVides && !doneNivells)
                {
                    panelPers.SetActive(false);
                    panelArmes.SetActive(true);
                    flexaPers.SetActive(false);
                    flexaArmes.SetActive(true);
                    if (PlayerPrefs.GetString("idioma", "none") == "castellano") tutorialText.text = "Este és el botón de 'Armas' donde puedes fabricar nuevas espadas para superar los niveles más fácilmente.";
                    else if (PlayerPrefs.GetString("idioma", "none") == "catala") tutorialText.text = "Aquest és el botó de 'Armes' on pots fabricar noves espases per superar els nivells més fàcilment.";
                    else if (PlayerPrefs.GetString("idioma", "none") == "english") tutorialText.text = "This is the 'Weapons' button where you can make new swords to overcome the levels more easily.";
                    if (Input.touchCount > 0)
                    {
                        Touch touch = Input.GetTouch(0);
                        if (touch.phase == TouchPhase.Began) doneArmes = true;
                    }
                    else if (Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Mouse1))
                    {
                        doneArmes = true;
                    }
                }
                else if (donePresentation && donePersonatges && doneArmes && !doneVides && !doneNivells)
                {
                    panelArmes.SetActive(false);
                    panelVides.SetActive(true);
                    flexaArmes.SetActive(false);
                    flexaVides.SetActive(true);
                    if (PlayerPrefs.GetString("idioma", "none") == "castellano") tutorialText.text = "Este és el botón de 'Vidas' donde puedes comprar más vidas para tu jugador.";
                    else if (PlayerPrefs.GetString("idioma", "none") == "catala") tutorialText.text = "Aquest és el botó de 'Vides' on pots comprar més vides per el teu jugador.";
                    else if (PlayerPrefs.GetString("idioma", "none") == "english") tutorialText.text = "This is the 'Lives' button where you can buy more lives for your player.";
                    if (Input.touchCount > 0)
                    {
                        Touch touch = Input.GetTouch(0);
                        if (touch.phase == TouchPhase.Began) doneVides = true;
                    }
                    else if (Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Mouse1))
                    {
                        doneVides = true;
                    }
                }
                else if (donePresentation && donePersonatges && doneArmes && doneVides && !doneNivells)
                {
                    panelVides.SetActive(false);
                    panelNivells.SetActive(true);
                    flexaVides.SetActive(false);
                    foreach (GameObject flxNivells in flexesNivells) flxNivells.SetActive(true);
                    if (PlayerPrefs.GetString("idioma", "none") == "castellano") tutorialText.text = "Estos són todos los niveles que tendrás que superar para salvar la tierra.";
                    else if (PlayerPrefs.GetString("idioma", "none") == "catala") tutorialText.text = "Aquests són tots els nivells que hauràs de superar per salvar la terra.";
                    else if (PlayerPrefs.GetString("idioma", "none") == "english") tutorialText.text = "These are all the levels that you will have to overcome to save the earth.";
                    if (Input.touchCount > 0)
                    {
                        Touch touch = Input.GetTouch(0);
                        if (touch.phase == TouchPhase.Began) doneNivells = true;
                    }
                    else if (Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Mouse1))
                    {
                        doneNivells = true;
                    }
                }
                else if (donePresentation && donePersonatges && doneArmes && doneVides && doneNivells)
                {
                    FirstPanels();
                    if (PlayerPrefs.GetString("idioma", "none") == "castellano") tutorialText.text = "Ahora empieza a juegar y disfruta del desafio y la história.";
                    else if (PlayerPrefs.GetString("idioma", "none") == "catala") tutorialText.text = "Ara comença a jugar i gaudeix del desafiament i la història.";
                    else if (PlayerPrefs.GetString("idioma", "none") == "english") tutorialText.text = "Now start playing and enjoy the challenge and the history.";
                    temps += Time.deltaTime;
                    if (temps >= 3)
                    {
                        canvasTutorial.SetActive(false);
                        PlayerPrefs.SetString("menuTutorial", "false");
                    }
                }
            }
        }
        else if (PlayerPrefs.GetString("menuTutorial", "true") == "false") canvasTutorial.SetActive(false);

    }

    void FirstPanels()
    {
        panelText.SetActive(true);
        vellImg.SetActive(true);
        tutorialText.gameObject.SetActive(true);
        panelNegre.SetActive(true);
        panelPers.SetActive(false);
        panelArmes.SetActive(false);
        panelVides.SetActive(false);
        panelNivells.SetActive(false);
        flexaPers.SetActive(false);
        flexaArmes.SetActive(false);
        flexaVides.SetActive(false);
        foreach (GameObject flxNivells in flexesNivells) flxNivells.SetActive(false);
    }
}
