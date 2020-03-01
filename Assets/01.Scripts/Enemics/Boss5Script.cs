using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss5Script : MonoBehaviour {
    public GameObject players, loadCinematic2, orbPrefab;
    GameObject player;
    public Transform orbs;
    int nivellPlayer;
    public AudioSource efectesAS, musicAS;
    public AudioClip enemieHit, levelWin, magSpell;
    GameObject[] materials = new GameObject[3];
    Animator animEnemic;
    Vector2 enemicPos;
    Vector2 enemicScale;
    float diferencePositions, velocity, vida;
    string[] actions = new string[3];
    bool getingAttack, defending, isDead, hasAttacked;
    [HideInInspector]
    public bool attackDreta;
    BoxCollider2D playerCollider;

    void Start()
    {
        loadCinematic2.SetActive(false);
        BuscarPlayerActive();
        for (int i = 0; i < 3; i++)
        {
            materials[i] = transform.GetChild(i).gameObject;
            materials[i].SetActive(false);
        }
        enemicScale = transform.localScale;
        animEnemic = GetComponent<Animator>();
        actions[0] = "doAttack1";
        actions[1] = "doAttack2";
        actions[2] = "doIdle";
        isDead = false;
        getingAttack = false;
        hasAttacked = false;
        attackDreta = false;
        velocity = 2.5f;
        vida = 150;
    }

    void Update()
    {
        IsDead();
        if (!isDead)
        {
            EnimieHited();
            PlayerNearEnimie();
            IsAttackingMagic();
        }
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
    void GoToCinematica2()
    {
        loadCinematic2.SetActive(true);
    }
    void IsDead()
    {
        if (vida <= 0 && !isDead)
        {
            musicAS.Stop();
            musicAS.PlayOneShot(levelWin);
            animEnemic.SetBool("doDead", true);
            GetComponent<BoxCollider2D>().isTrigger = true;
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
            isDead = true;
            Invoke("ActivateMaterials", 1f);
        }

        if (animEnemic.GetCurrentAnimatorStateInfo(0).IsName("Boss5-Dead"))
        {
            animEnemic.SetBool("doDead", false);
            Invoke("GoToCinematica2", 6);

            Social.ReportProgress("CggIv9GCrUcQAhAE", 100.0f, (bool success) => {
                Debug.Log("Result: " + success);
            });
            Social.ReportProgress("CggIv9GCrUcQAhAF", 100.0f, (bool success) => {
                Debug.Log("Result: " + success);
            });
        }
    }
    void ActivateMaterials()
    {
        for (int i = 0; i < 3; i++)
        {
            if (materials[i] != null)
            {
                materials[i].SetActive(true);
                if (materials[i].tag == "Or") materials[i].GetComponent<Animator>().SetTrigger("activateOr");
                else if (materials[i].tag == "Ferro") materials[i].GetComponent<Animator>().SetTrigger("activateFerro");
                else if (materials[i].tag == "Fusta") materials[i].GetComponent<Animator>().SetTrigger("activateFusta");
            }
        }
    }
    void EnimieHited()
    {
        playerCollider = player.GetComponent<BoxCollider2D>();
        if (!player.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Main-Attack")) getingAttack = false;
        if (GetComponent<BoxCollider2D>().IsTouching(playerCollider))
        {
            if (!getingAttack && player.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Main-Attack"))
            {
                efectesAS.PlayOneShot(enemieHit);
                animEnemic.SetTrigger("doHit");
                vida -= 10 * nivellPlayer;
                getingAttack = true;
            }
        }
    }
    void PlayerNearEnimie()
    {
        enemicPos = transform.position;
        diferencePositions = player.transform.position.x - transform.position.x;
        if (diferencePositions >= -12 && diferencePositions <= -3f)
        {
            if (enemicScale.x < 0)
            {
                enemicScale.x = enemicScale.x * -1;
                transform.localScale = enemicScale;
            }
            animEnemic.SetFloat("speed", velocity);
            float posX = enemicPos.x - (velocity * Time.deltaTime);
            enemicPos = new Vector2(posX, enemicPos.y);
            transform.position = enemicPos;
        }
        else if (diferencePositions <= 12 && diferencePositions >= 3f)
        {
            if (enemicScale.x > 0)
            {
                enemicScale.x = -enemicScale.x;
                transform.localScale = enemicScale;
            }
            animEnemic.SetFloat("speed", velocity);
            float posX = enemicPos.x + (velocity * Time.deltaTime);
            enemicPos = new Vector2(posX, enemicPos.y);
            transform.position = enemicPos;
        }
        else if (diferencePositions >= -3f && diferencePositions <= 3f)
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
            if (animEnemic.GetCurrentAnimatorStateInfo(0).IsName("Boss5-Idle") && animEnemic.GetCurrentAnimatorStateInfo(0).normalizedTime >= animEnemic.GetCurrentAnimatorStateInfo(0).length)
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

    void IsAttacking()
    {
        player.transform.GetChild(0).GetComponent<PlayerColliderScript>().bossAttacking = true;
    }
    void NoAttacking()
    {
        player.transform.GetChild(0).GetComponent<PlayerColliderScript>().bossAttacking = false;
        player.transform.GetChild(0).GetComponent<PlayerColliderScript>().oneHit = true;
    }

    void IsAttackingMagic()
    {
        if (!hasAttacked && animEnemic.GetCurrentAnimatorStateInfo(0).IsName("Boss5-Attack2") && animEnemic.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.5f)
        {
            hasAttacked = true;
            Invoke("AttackOrb", 0f);
        }
        else if (!animEnemic.GetCurrentAnimatorStateInfo(0).IsName("Boss5-Attack2")) hasAttacked = false;
    }
    void AttackOrb()
    {
        efectesAS.PlayOneShot(magSpell);
        Instantiate(orbPrefab, orbs);
    }
}
