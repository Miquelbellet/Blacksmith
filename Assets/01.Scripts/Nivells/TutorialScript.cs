using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialScript : MonoBehaviour {
    public GameObject players, panelTutorial;
    GameObject player;
    public Text tutorialText;
    bool doTutorial, doneMove, doneJump, doneAttack;
    float temps;

	void Start () {
        BuscarPlayerActive();
        if (PlayerPrefs.GetString("cinematicLevel1", "true") == "true")
        {
            doTutorial = true;
            panelTutorial.SetActive(true);
        }
        else
        {
            doTutorial = false;
            panelTutorial.SetActive(false);
        }
        doneMove = false;
        doneJump = false;
        doneAttack = false;
    }
	
	void Update () {
        if (doTutorial)
        {
            if (!doneMove && !doneJump && !doneAttack)
            {
                if (PlayerPrefs.GetString("idioma", "english") == "castellano") tutorialText.text = "Mueve el dedo por las dos flechas para mover tu personaje.";
                else if (PlayerPrefs.GetString("idioma", "english") == "catala") tutorialText.text = "Mou el dit per les dues fletxes per moure el teu personatge.";
                else if (PlayerPrefs.GetString("idioma", "english") == "english") tutorialText.text = "Move your finger by the two arrows to move your character.";
                if (Input.touchCount > 0)
                {
                    Touch myTouch = Input.GetTouch(0);
                    if (myTouch.phase == TouchPhase.Stationary || myTouch.phase == TouchPhase.Moved)
                    {
                        if (myTouch.position.x >= 0 && myTouch.position.x <= GetComponent<NivellsScript>().movementBtnWidth && myTouch.position.y <= GetComponent<NivellsScript>().movementBtnHeight)
                        {
                            doneMove = true;
                        }
                    }
                }
                else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
                {
                    doneMove = true;
                }
            }
            else if (doneMove && !doneJump && !doneAttack)
            {
                if (PlayerPrefs.GetString("idioma", "english") == "castellano") tutorialText.text = "Muy bien, ahora aprieta el botón de la izquierda para saltar.";
                else if (PlayerPrefs.GetString("idioma", "english") == "catala") tutorialText.text = "Molt bé, ara prem el botó de l'esquerra per saltar.";
                else if (PlayerPrefs.GetString("idioma", "english") == "english") tutorialText.text = "Alright, now press the button on the left to jump.";
                if (player.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Main-Jump")) doneJump = true;
            }
            else if (doneMove && doneJump && !doneAttack)
            {
                if (PlayerPrefs.GetString("idioma", "english") == "castellano") tutorialText.text = "Para acabar, aprieta el botón de la derecha para atacar.";
                else if (PlayerPrefs.GetString("idioma", "english") == "catala") tutorialText.text = "Per acabar, prem el botó de la dreta per atacar.";
                else if (PlayerPrefs.GetString("idioma", "english") == "english") tutorialText.text = "To finish, press the button on the right to attack.";
                if (player.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Main-Attack")) doneAttack = true;
            }
            else if (doneMove && doneJump && doneAttack)
            {
                if (PlayerPrefs.GetString("idioma", "english") == "castellano") tutorialText.text = "¡Perfecto! Ya puedes empezar a derrotar enemigos, buena suerte.";
                else if (PlayerPrefs.GetString("idioma", "english") == "catala") tutorialText.text = "Perfecte! Ja pots començar a derrotar enemics, bona sort.";
                else if (PlayerPrefs.GetString("idioma", "english") == "english") tutorialText.text = "Perfect! Now you can start to defeat the enemies, good luck.";
                temps += Time.deltaTime;
                if (temps >= 4)
                {
                    panelTutorial.SetActive(false);
                    PlayerPrefs.SetString("cinematicLevel1", "false");
                }
            }
        }
    }

    void BuscarPlayerActive()
    {
        for (int i = 0; i < players.transform.childCount; i++)
        {
            if (players.transform.GetChild(i).gameObject.activeInHierarchy)
            {
                player = players.transform.GetChild(i).gameObject;
            }
        }
    }
}
