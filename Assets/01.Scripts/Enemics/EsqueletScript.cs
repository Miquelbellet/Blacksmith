using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EsqueletScript : MonoBehaviour {
    public GameObject players;
    GameObject player;
    int nivellPlayer;
    public AudioSource efectesAS;
    public AudioClip shieldHit, enemieHit, enemieDead;
    Animator animEnemic;
    Vector2 enemicPos;
    Vector2 enemicScale;
    float diferencePositions;
    string[] actions = new string[3];
    float velocity;
    float vida;
    bool getingAttack, defending, isDead;
    [HideInInspector]
    public bool isAttacking;
    BoxCollider2D playerCollider;
    GameObject or;

    void Start () {
        BuscarPlayerActive();
        or = transform.GetChild(0).gameObject;
        or.SetActive(false);
        enemicScale = transform.localScale;
        animEnemic = GetComponent<Animator>();
        actions[0] = "doAttack";
        actions[1] = "doDefend";
        actions[2] = "doIdle";
        isDead = false;
        getingAttack = false;
        isAttacking = false;
        velocity = 2f;
        if (tag == "Esq1") vida = 20;
        else if (tag == "Esq2") vida = 40;
        else if (tag == "Esq3") vida = 80;
    }
	
	void Update () {
        IsDead();
        if (!isDead)
        {
            EnimieHited();
            PlayerNearEnimie();
        }
    }

    void IsDead()
    {
        if (vida <= 0 && !isDead)
        {
            animEnemic.SetBool("doDead", true);
            efectesAS.PlayOneShot(enemieDead);
            GetComponent<BoxCollider2D>().isTrigger = true;
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
            isDead = true;
            Invoke("ActivateOr", 1);
        }
        if (animEnemic.GetCurrentAnimatorStateInfo(0).IsName("Esq-Dead"))
        {
            animEnemic.SetBool("doDead", false);
            Invoke("EnemieDied", 10);
        }
    }
    void ActivateOr()
    {
        or.SetActive(true);
        or.GetComponent<Animator>().SetTrigger("activateOr");
    }
    void EnemieDied()
    {
        Destroy(gameObject);
    }
    void EnimieHited()
    {
        playerCollider = player.GetComponent<BoxCollider2D>();
        if (!player.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Main-Attack")) getingAttack = false;
        if (GetComponent<BoxCollider2D>().IsTouching(playerCollider))
        {
            if (!getingAttack && player.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Main-Attack") && !animEnemic.GetCurrentAnimatorStateInfo(0).IsName("Esq-Defend"))
            {
                animEnemic.SetTrigger("doHit");
                vida -= 10 * nivellPlayer;
                if (vida > 0) efectesAS.PlayOneShot(enemieHit);
                getingAttack = true;
            }
            else if (!getingAttack && player.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Main-Attack") && animEnemic.GetCurrentAnimatorStateInfo(0).IsName("Esq-Defend"))
            {
                efectesAS.PlayOneShot(shieldHit);
                getingAttack = true;
            }
        }
    }
    void PlayerNearEnimie()
    {
        enemicPos = transform.position;
        diferencePositions = player.transform.position.x - transform.position.x;
        if (diferencePositions >= -10 && diferencePositions <= -2f)
        {
            if (enemicScale.x < 0)
            {
                enemicScale.x = enemicScale.x * -1;
                transform.localScale = enemicScale;
            }
            animEnemic.SetFloat("speed", velocity);

            float posX = enemicPos.x - (velocity*Time.deltaTime);
            enemicPos = new Vector2(posX, enemicPos.y);
            transform.position = enemicPos;
        }
        else if (diferencePositions <= 10 && diferencePositions >= 2f)
        {
            if (enemicScale.x > 0)
            {
                enemicScale.x = -enemicScale.x;
                transform.localScale = enemicScale;
            }
            animEnemic.SetFloat("speed", velocity);

            float posX = enemicPos.x + (velocity*Time.deltaTime);
            enemicPos = new Vector2(posX, enemicPos.y);
            transform.position = enemicPos;
        }
        else if (diferencePositions >= -2f && diferencePositions <= 2f)
        {
            if (diferencePositions <= 0 && enemicScale.x < 0)
            {
                enemicScale.x = enemicScale.x * -1;
                transform.localScale = enemicScale;
            }
            else if (diferencePositions >= 0 && enemicScale.x > 0)
            {
                enemicScale.x = -enemicScale.x;
                transform.localScale = enemicScale;
            }
            animEnemic.SetFloat("speed", 0);
            if (animEnemic.GetCurrentAnimatorStateInfo(0).normalizedTime >= animEnemic.GetCurrentAnimatorStateInfo(0).length)
            {
                int rand = Random.Range(0, 3);
                animEnemic.SetTrigger(actions[rand]);
            }
        }
        else
        {
            animEnemic.SetFloat("speed", 0);
        }
    }
    void BuscarPlayerActive()
    {
        for (int i = 0; i < players.transform.childCount; i++)
        {
            if (players.transform.GetChild(i).gameObject.activeInHierarchy)
            {
                player = players.transform.GetChild(i).gameObject;
                nivellPlayer = i+1;
            }
        }
    }

    void EsqueletAttacking()
    {
        isAttacking = true;
    }
    void EsqueletNoAttacking()
    {
        isAttacking = false;
        player.transform.GetChild(0).GetComponent<PlayerColliderScript>().oneHit = true;
    }
}