using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagsScript : MonoBehaviour {
    public GameObject players, orbPrefab;
    GameObject player;
    public Transform orbs;
    public AudioSource efectesAS;
    public AudioClip magSpell, magHit, enemieDead;
    int nivellPlayer;
    Animator animEnemic;
    Vector2 enemicPos;
    Vector2 enemicScale;
    string[] actions = new string[2];
    float diferencePositions;
    float velocity;
    float vida;
    bool getingAttack, isDead, hasAttacked;
    [HideInInspector]
    public bool attackDreta;
    BoxCollider2D playerCollider;
    GameObject or;

    void Start()
    {
        BuscarPlayerActive();
        or = transform.GetChild(0).gameObject;
        or.SetActive(false);
        enemicScale = transform.localScale;
        animEnemic = GetComponent<Animator>();
        isDead = false;
        getingAttack = false;
        attackDreta = false;
        velocity = 0.05f;
        actions[0] = "doAttack";
        actions[1] = "doIdle";
        if (tag == "Mag1Collider") vida = 40;
        else if (tag == "Mag2Collider") vida = 70;
    }

    void Update()
    {
        IsDead();
        if (!isDead)
        {
            EnimieHited();
            PlayerNearEnimie();
            IsAttacking();
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
        if (animEnemic.GetCurrentAnimatorStateInfo(0).IsName("Mag-Dead"))
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
            if (!getingAttack && player.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Main-Attack"))
            {
                animEnemic.SetTrigger("doHit");
                vida -= 10 * nivellPlayer;
                if (vida > 0) efectesAS.PlayOneShot(magHit);
                getingAttack = true;
            }
        }
    }

    void PlayerNearEnimie()
    {
        enemicPos = transform.position;
        diferencePositions = player.transform.position.x - transform.position.x;
        /*if (diferencePositions >= -10 && diferencePositions <= -8)
        {
            if (enemicScale.x < 0)
            {
                enemicScale.x = enemicScale.x * -1;
                transform.localScale = enemicScale;
            }
            animEnemic.SetFloat("speed", velocity);

            float posX = enemicPos.x - velocity;
            enemicPos = new Vector2(posX, enemicPos.y);
            transform.position = enemicPos;
        }
        else if (diferencePositions <= 10 && diferencePositions >= 8)
        {
            if (enemicScale.x > 0)
            {
                enemicScale.x = -enemicScale.x;
                transform.localScale = enemicScale;
            }
            animEnemic.SetFloat("speed", velocity);

            float posX = enemicPos.x + velocity;
            enemicPos = new Vector2(posX, enemicPos.y);
            transform.position = enemicPos;
        }*/
        if (diferencePositions >= -12 && diferencePositions <= 12)
        {
            if (diferencePositions <= 0 && enemicScale.x < 0)
            {
                enemicScale.x = enemicScale.x * -1;
                transform.localScale = enemicScale;
                attackDreta = false;
            }
            else if (diferencePositions >= 0 && enemicScale.x > 0)
            {
                enemicScale.x = -enemicScale.x;
                transform.localScale = enemicScale;
                attackDreta = true;
            }
            animEnemic.SetFloat("speed", 0);
            if (animEnemic.GetCurrentAnimatorStateInfo(0).IsName("Mag-Idle") && animEnemic.GetCurrentAnimatorStateInfo(0).normalizedTime >= animEnemic.GetCurrentAnimatorStateInfo(0).length)
            {
                int rand = Random.Range(0, 2);
                animEnemic.SetTrigger(actions[rand]);
            }
        }
        else
        {
            animEnemic.SetFloat("speed", 0);
        }
    }

    void IsAttacking()
    {
        if (!hasAttacked && animEnemic.GetCurrentAnimatorStateInfo(0).IsName("Mag-Attack") && animEnemic.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.5f)
        {
            hasAttacked = true;
            Invoke("AttackOrb", 0f);
        }
        else if(!animEnemic.GetCurrentAnimatorStateInfo(0).IsName("Mag-Attack")) hasAttacked = false;
    }

    void AttackOrb()
    {
        efectesAS.PlayOneShot(magSpell);
        Instantiate(orbPrefab, orbs);
    }

    void BuscarPlayerActive()
    {
        for (int i = 0; i < players.transform.childCount; i++)
        {
            if (players.transform.GetChild(i).gameObject.activeInHierarchy)
            {
                player = players.transform.GetChild(i).gameObject;
                nivellPlayer = i + 1;
            }
        }
    }
}
