using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Cinematica1Script : MonoBehaviour {
    public GameObject mainImg, vellImg, loadNivell1, loadMenu;
    public AudioClip buttonSound;
    public Animator animCinematic;
    public Text dialogText, buttonText;
    int numPerCanviarScenari;
    string[] dialog = new string[20];
    int numDialog = 0;
    bool waitCinematic;
    float music, efects;

    void Start () {
        loadNivell1.SetActive(false);
        loadMenu.SetActive(false);
        dialogText.gameObject.SetActive(true);
        waitCinematic = true;
        efects = PlayerPrefs.GetFloat("efectsVol", 70.0f);
        transform.GetChild(0).GetComponent<AudioSource>().volume = efects * 0.01f;
        music = PlayerPrefs.GetFloat("musicVol", 50.0f);
        GetComponent<AudioSource>().volume = music * 0.01f;
        numPerCanviarScenari = 6;
        if (PlayerPrefs.GetString("idioma", "english") == "castellano")
        {
            buttonText.text = "Saltar";
            dialog[0] = "Buenos días, ¿qué estás buscando?";
            dialog[1] = "Buenos días, estoy buscando madera para fabricar una empuñadura.";
            dialog[2] = "Así que eres herrero. Eres el indicado.";
            dialog[3] = "¿El indicado?";
            dialog[4] = "Necesito tu ayuda joven, te he estado observando y eres perfecto para seguir con mi trabajo.";
            dialog[5] = "¿Mi ayuda? ¿Qué trabajo?";
            dialog[6] = "Ven a mi cabaña y te lo explicaré todo.";
            dialog[7] = "¡Vaya! Está muy bien escondida.";
            dialog[8] = "Escúchame atentamente y no te pierdas ningún detalle.";
            dialog[9] = "De acuerdo.";
            dialog[10] = "Llevo años luchando contra un mago malvado en otra isla.";
            dialog[11] = "¿Un mago malvado?";
            dialog[12] = "Ahora ya soy muy viejo para luchar y necesito que tú lo hagas. Yo te enseñaré a luchar.";
            dialog[13] = "¿Cómo? ¿Yo...? Yo no puedo.";
            dialog[14] = "Por favor, cuando más tardemos más fuerte se hará.";
            dialog[15] = "¿Y qué pasará con mi familia?";
            dialog[16] = "No te preocupes, si derrotas al malvado estarán a salvo. Si no vienes, todos estaréis en peligro.";
            dialog[17] = "Vaya, supongo que no tengo elección. ¿Cuándo partimos?";
            dialog[18] = "Mañana por la mañana. Tienes esta noche para despedirte de tu familia.";
            dialog[19] = "Perfecto, seguro que me espera una aventura increíble.";
        }
        else if (PlayerPrefs.GetString("idioma", "english") == "catala")
        {
            buttonText.text = "Saltar";
            dialog[0] = "Bon dia, què estàs buscant?";
            dialog[1] = "Bon dia, estic buscant fusta per fabricar una empunyadura.";
            dialog[2] = "Així que ets ferrer. Ets el indicat.";
            dialog[3] = "L'indicat?";
            dialog[4] = "Necessito la teva ajuda jove, t'he estat observant i ets perfecte per seguir amb la meva feina.";
            dialog[5] = "La meva ajuda? Quina feina?";
            dialog[6] = "Vine a la meva cabana i t'ho explicaré tot.";
            dialog[7] = "Vaja! Està molt ben amagada.";
            dialog[8] = "Escolta'm atentament i no et perdis cap detall.";
            dialog[9] = "D'acord.";
            dialog[10] = "Porto anys lluitant contra un mag malvat en una altra illa.";
            dialog[11] = "Un mag malvat?";
            dialog[12] = "Ara ja sóc molt vell per lluitar i necessito que tu ho facis. Jo t'ensenyaré a lluitar.";
            dialog[13] = "Com? Jo...? Jo no puc.";
            dialog[14] = "Si us plau, quan més triguem més fort es farà.";
            dialog[15] = "I què passarà amb la meva família?";
            dialog[16] = "No et preocupis, si derrotes al malvat estaran fora de perill. Si no vens, tots estareu en perill.";
            dialog[17] = "Vaja, suposo que no tinc elecció. Quan marxem?";
            dialog[18] = "Demà al matí. Tens aquesta nit per acomiadar-te de la teva família.";
            dialog[19] = "Perfecte, segur que m'espera una aventura increïble.";
        }
        else if (PlayerPrefs.GetString("idioma", "english") == "english")
        {
            buttonText.text = "Skip";
            dialog[0] = "Good morning, what are you looking for?";
            dialog[1] = "Good morning, I'm looking for wood to make a hilt.";
            dialog[2] = "So you're a blacksmith. You are the right one.";
            dialog[3] = "The right one?";
            dialog[4] = "I need your help young man, I have been watching you and you are the perfect one to continue with my work.";
            dialog[5] = "My help? What work?";
            dialog[6] = "Come to my cabin and I'll explain everything to you.";
            dialog[7] = "Wow! It is very well hidden.";
            dialog[8] = "Listen to me carefully and do not miss any details.";
            dialog[9] = "Alright.";
            dialog[10] = "I've been fighting against an evil magician on another island for years.";
            dialog[11] = "An evil magician?";
            dialog[12] = "Now I am too old to fight and I need you to do it. I will teach you how to fight.";
            dialog[13] = "What? I...? I can't.";
            dialog[14] = "Please, the longer we take the stronger it will be.";
            dialog[15] = "And what will happen to my family?";
            dialog[16] = "Do not worry, if you defeat the evil one they will be safe. If you do not come, you will all be in danger.";
            dialog[17] = "Ok, I guess I have no choice. When do we start?";
            dialog[18] = "Tomorrow morning. You have tonight to say goodbye to your family.";
            dialog[19] = "Perfect, surely an incredible adventure awaits me.";
        }
    }

    void Update () {
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
            else if (numDialog == numPerCanviarScenari && !animCinematic.GetBool("changeCinematic"))
            {
                animCinematic.SetBool("changeCinematic", true);
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
                else if (numDialog == numPerCanviarScenari && !animCinematic.GetBool("changeCinematic"))
                {
                    animCinematic.SetBool("changeCinematic", true);
                    waitCinematic = true;
                }
                else numDialog++;
            }
            if (animCinematic.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1) waitCinematic = false;
            else waitCinematic = true;
        }
#endif
        if (animCinematic.GetCurrentAnimatorStateInfo(0).IsName("Cinematica-End") && animCinematic.GetCurrentAnimatorStateInfo(0).normalizedTime >= animCinematic.GetCurrentAnimatorStateInfo(0).length)
        {
            if (PlayerPrefs.GetString("CinemConfig", "false") == "false") loadNivell1.SetActive(true);
            else if (PlayerPrefs.GetString("CinemConfig", "false") == "true") loadMenu.SetActive(true);
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
        if(PlayerPrefs.GetString("CinemConfig", "false") == "false") loadNivell1.SetActive(true);
        else if(PlayerPrefs.GetString("CinemConfig", "false") == "true") loadMenu.SetActive(true);

    }
}
