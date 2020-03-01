using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NivellsScript : MonoBehaviour
{
    public Button doJumpBtn, doAttackBtn;
    [HideInInspector]
    public float movementBtnWidth, movementBtnHeight;
    public GameObject players, ocellPrefab, neuPrefab, panelDead, horizontaMovementPanel, loadMenu;
    GameObject player;
    AudioSource efectsAS;
    public AudioClip mainDeadSound;
    public GameObject[] videsImgs;
    public Transform nuvolsEmpty, neuEmpty;
    public GameObject[] nuvolsPrefab;
    int espasaSelect;
    public Text orTxt, ferroTxt, fustaTxt;
    int or, ferro, fusta, vides, videsRestades;

    private void Awake()
    {
        SeleccionarEspasa();
        BuscarPlayerActive();
#if UNITY_ANDROID || UNITY_IOS
        doAttackBtn.gameObject.SetActive(true);
        doJumpBtn.gameObject.SetActive(true);
        horizontaMovementPanel.SetActive(true);
#endif
#if UNITY_EDITOR || UNITY_STANDALONE || UNITY_WEBGL
        doAttackBtn.gameObject.SetActive(false);
        doJumpBtn.gameObject.SetActive(false);
        horizontaMovementPanel.SetActive(false);
#endif
    }
    void Start()
    {
        GetMaterials();
        SetVides();
        loadMenu.SetActive(false);
        efectsAS = transform.GetChild(0).GetComponent<AudioSource>();
        movementBtnWidth = Screen.width / 2;
        movementBtnHeight = horizontaMovementPanel.GetComponent<RectTransform>().rect.height;
        InvokeRepeating("Nuvols", 1, 5);
        if(SceneManager.GetActiveScene().name == "Nivell1" || SceneManager.GetActiveScene().name == "Nivell2") InvokeRepeating("Ocell", 1, 7);
        if(SceneManager.GetActiveScene().name == "Nivell3") InvokeRepeating("Nevada", 0f, 0.01f);
    }

    void Update()
    {
#if UNITY_ANDROID || UNITY_IOS
        if (!player.GetComponent<PlayerMainScript>().isDead) HorizontalMoveMobile();
#endif
    }
    void SeleccionarEspasa()
    {
        espasaSelect = PlayerPrefs.GetInt("espasaSelec", 1);
        for (int i = 0; i < players.transform.childCount; i++)
        {
            if (i == espasaSelect - 1)
            {
                players.transform.GetChild(espasaSelect - 1).gameObject.SetActive(true);
            }
            else players.transform.GetChild(i).gameObject.SetActive(false);
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
    public void GetMaterials()
    {
        or = PlayerPrefs.GetInt("or", 0);
        orTxt.text = or + "";
        ferro = PlayerPrefs.GetInt("ferro", 0);
        ferroTxt.text = ferro + "";
        fusta = PlayerPrefs.GetInt("fusta", 0);
        fustaTxt.text = fusta + "";
    }
    void SetVides()
    {
        vides = PlayerPrefs.GetInt("vides", 8);
        for (int i = 0; i < videsImgs.Length; i++)
        {
            if (i < vides) videsImgs[i].SetActive(true);
            else videsImgs[i].SetActive(false);
        }
    }
    void Nuvols()
    {
        Instantiate(nuvolsPrefab[Random.Range(0, 5)], nuvolsEmpty);
    }
    void Ocell()
    {
        Instantiate(ocellPrefab, nuvolsEmpty);
    }
    void Nevada()
    {
        Instantiate(neuPrefab, neuEmpty);
    }
    public void RestarVida(string enemic)
    {
        if (enemic == "Esq1")
        {
            videsRestades = 1;
        }
        else if (enemic == "Esq2" || enemic == "Mag1" || enemic == "Boss1")
        {
            videsRestades = 2;
        }
        else if (enemic == "Esq3" || enemic == "Mag2" || enemic == "Boss2")
        {
            videsRestades = 3;
        }
        else if (enemic == "Boss3" || enemic == "Boss4")
        {
            videsRestades = 4;
        }
        else if(enemic == "Boss5")
        {
            videsRestades = 5;
        }

        if (vides > 0)
        {
            for (int i = vides; i > vides - videsRestades; i--)
            {
                if (i >= 1)
                {
                    videsImgs[i - 1].GetComponent<VidaScript>().enabled = true;
                }
            }
            vides -= videsRestades;
        }
        if (vides <= 0)
        {
            MainDead();
        }
    }
    public void MainDead()
    {
        efectsAS.PlayOneShot(mainDeadSound);
        player.GetComponent<PlayerMainScript>().isDead = true;
        player.transform.GetChild(0).GetComponent<PlayerColliderScript>().enabled = false;
        panelDead.SetActive(true);
        panelDead.GetComponent<Animator>().SetTrigger("activateDead");
        Invoke("GoToMenu", 5);
    }
    void GoToMenu()
    {
        loadMenu.SetActive(true);
    }
    public void DoJump()
    {
        if (player.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Main-Idle") || player.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Main-Run")) player.GetComponent<PlayerMainScript>().DoJump();
    }
    public void DoAttack()
    {
        if (player.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Main-Idle") || player.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Main-Run")) player.GetComponent<PlayerMainScript>().DoAttack();
    }
    void HorizontalMoveMobile()
    {
        if (Input.touchCount > 0)
        {
            Touch myTouch = Input.GetTouch(0);
            if (myTouch.phase == TouchPhase.Stationary || myTouch.phase == TouchPhase.Moved)
            {
                if (myTouch.position.x >= movementBtnWidth / 2 && myTouch.position.x <= movementBtnWidth && myTouch.position.y <= movementBtnHeight)
                {
                    player.GetComponent<PlayerMainScript>().MoveRight();
                }
                else if (myTouch.position.x >= 0 && myTouch.position.x <= movementBtnWidth / 2 && myTouch.position.y <= movementBtnHeight)
                {
                    player.GetComponent<PlayerMainScript>().MoveLeft();
                }else player.GetComponent<PlayerMainScript>().NoMove();
            }
        }
        else player.GetComponent<PlayerMainScript>().NoMove();
    }
}
