using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cinematica2Script : MonoBehaviour {
    public GameObject mainImg, vellImg, loadMenu;
    public AudioClip buttonSound;
    public Animator animCinematic;
    public Text dialogText, buttonText;
    string[] dialog = new string[7];
    int numDialog = 0;
    bool waitCinematic;
    float music, efects;

    void Start()
    {
        loadMenu.SetActive(false);
        dialogText.gameObject.SetActive(true);
        waitCinematic = true;
        efects = PlayerPrefs.GetFloat("efectsVol", 70.0f);
        transform.GetChild(0).GetComponent<AudioSource>().volume = efects * 0.01f;
        music = PlayerPrefs.GetFloat("musicVol", 50.0f);
        GetComponent<AudioSource>().volume = music * 0.01f;
        if (PlayerPrefs.GetString("idioma", "english") == "castellano")
        {
            buttonText.text = "Saltar";
            dialog[0] = "¡Maewin! ¡Lo has conseguido! Has salvado a la tierra de la destrucción.";
            dialog[1] = "Supongo que si, ha valido la pena hacer este viaje.";
            dialog[2] = "Ahora ya puedes volver con tu familia y reposar tranquilamente.";
            dialog[3] = "Me merezco un descanso después de todo esto.";
            dialog[4] = "Muchas gracias por acabar el trabajo que yo no pude hacer.";
            dialog[5] = "Gracias a ti por enseñarme tantas cosas.";
            dialog[6] = "Ya se ha acabado todo.";
        }
        else if (PlayerPrefs.GetString("idioma", "english") == "catala")
        {
            buttonText.text = "Saltar";
            dialog[0] = "¡Maewin! Ho has aconseguit! Has salvat a la terra de la destrucció.";
            dialog[1] = "Suposo que si, ha valgut la pena fer aquest viatge.";
            dialog[2] = "Ara ja pots tornar amb la família i reposar tranquil·lament.";
            dialog[3] = "Em mereixo un descans després de tot això.";
            dialog[4] = "Moltes gràcies per acabar la feina que jo no vaig poder fer.";
            dialog[5] = "Gràcies a tu per ensenyar-me tantes coses.";
            dialog[6] = "Ja s'ha acabat tot.";
        }
        else if (PlayerPrefs.GetString("idioma", "english") == "english")
        {
            buttonText.text = "Skip";
            dialog[0] = "Maewin! You've got it! You have saved the earth from destruction.";
            dialog[1] = "I guess so, it was worth doing this trip.";
            dialog[2] = "Now you can go back to your family and rest quietly.";
            dialog[3] = "I deserve a break after all this.";
            dialog[4] = "Thank you very much for finishing the work that I could not do.";
            dialog[5] = "Thanks to you for teaching me so many things.";
            dialog[6] = "Everything is over.";
        }
    }

    void Update()
    {
        ChangeFocus();
        dialogText.text = dialog[numDialog];

#if UNITY_EDITOR || UNITY_STANDALONE || UNITY_WEBGL
        if (!waitCinematic && (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1)))
        {
            if (numDialog >= dialog.Length - 1)
            {
                animCinematic.SetBool("endCinematic", true);
                waitCinematic = true;
            }
            else numDialog++;
        }
        if (animCinematic.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1) waitCinematic = false;
        else waitCinematic = true;
#endif
#if UNITY_ANDROID || UNITY_IOS
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 pos = touch.position;
            if (!waitCinematic && touch.phase == TouchPhase.Began)
            {
                if (numDialog >= dialog.Length - 1)
                {
                    animCinematic.SetBool("endCinematic", true);
                    waitCinematic = true;
                }
                else numDialog++;
            }
            if (animCinematic.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1) waitCinematic = false;
            else waitCinematic = true;
        }
#endif
        if (animCinematic.GetCurrentAnimatorStateInfo(0).IsName("end-scene") && animCinematic.GetCurrentAnimatorStateInfo(0).normalizedTime >= animCinematic.GetCurrentAnimatorStateInfo(0).length)
        {
            loadMenu.SetActive(true);
        }
    }

    void ChangeFocus()
    {
        if (numDialog % 2 == 0)
        {
            mainImg.GetComponent<Image>().color = new Color32(100, 100, 100, 255);
            vellImg.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        }
        else if (numDialog % 2 != 0)
        {
            vellImg.GetComponent<Image>().color = new Color32(100, 100, 100, 255);
            mainImg.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        }
    }

    public void SkipCinematic()
    {
        transform.GetChild(0).GetComponent<AudioSource>().PlayOneShot(buttonSound);
        loadMenu.SetActive(true);

    }
}
