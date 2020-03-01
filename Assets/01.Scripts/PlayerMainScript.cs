using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMainScript : MonoBehaviour {
    public AudioSource efectsAS, musicAS;
    public AudioClip jump, battleMusic;
    int or, ferro, fusta;
    Camera cam;
    Vector3 initCamPos, firstCamPos, lastCamPos;
    Vector2 initPlayerPos, playerScale;
    [HideInInspector]
    public bool moveMontains, isDead, isAttacking;
    Animator animMain;
    Rigidbody2D rbMain;
    Vector2 mainPos;
    public int jumpForce;
    public float velocity;
    [HideInInspector]
    public string playerMove;
    [HideInInspector]
    public enum PlayerState { Idle, Attack, Run, Hit, Jump, Dead};
    PlayerState myState;
    float temps;
    bool bossMusic, isTouchingPlatform;

    void Start () {
        cam = Camera.main;
        initCamPos = cam.transform.position;
        firstCamPos = new Vector3(245, cam.transform.position.y, cam.transform.position.z);
        lastCamPos = new Vector3(256, cam.transform.position.y, cam.transform.position.z);
        playerScale = transform.localScale;
        initPlayerPos = transform.position;
        animMain = GetComponent<Animator>();
        rbMain = GetComponent<Rigidbody2D>();
        myState = PlayerState.Idle;
        isDead = false;
        bossMusic = false;
        isTouchingPlatform = false;
        isAttacking = false;
    }
	
	void Update () {
#if UNITY_EDITOR || UNITY_STANDALONE || UNITY_WEBGL
        if (!isDead) HorizontalMovement();
#endif
        AnimationActions();
        CameraMovenment();
    }

    void AnimationActions()
    {
        if (animMain.GetCurrentAnimatorStateInfo(0).IsName("Main-Idle") || animMain.GetCurrentAnimatorStateInfo(0).IsName("Main-Run"))
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                DoJump();
            }
            else if (Input.GetKeyDown(KeyCode.Space))
            {
                DoAttack();
            }
            else if (Input.GetKeyDown(KeyCode.H))
            {
                transform.GetComponent<Animator>().SetTrigger("doHit");
            }
            if (isDead) animMain.SetTrigger("doDead");
        }
        
    }
    void HorizontalMovement()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            MoveRight();
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            MoveLeft();
        }
        else
        {
            NoMove();
        }
    }
    public void DoJump()
    {
        efectsAS.PlayOneShot(jump);
        myState = PlayerState.Jump;
        animMain.SetTrigger("doJump");
        rbMain.AddForce(new Vector2(rbMain.velocity.x, jumpForce), ForceMode2D.Impulse);
    }
    public void DoAttack()
    {
        efectsAS.PlayDelayed(0.2f);
        myState = PlayerState.Attack;
        animMain.SetTrigger("doAttack");
    }
    public void MoveRight()
    {
        mainPos = gameObject.transform.position;
        if (playerScale.x < 0)
        {
            playerScale.x = playerScale.x * -1;
            transform.localScale = playerScale;
        }
        if (animMain.GetCurrentAnimatorStateInfo(0).IsName("Main-Attack") && animMain.GetCurrentAnimatorStateInfo(0).normalizedTime <= animMain.GetCurrentAnimatorStateInfo(0).length)
        {
            myState = PlayerState.Attack;
        }
        else myState = PlayerState.Run;
        animMain.SetFloat("speed", velocity);
        if (myState != PlayerState.Attack)
        {
            playerMove = "Right";
            //Vector2 moveRight = new Vector2(velocity, rbMain.velocity.y);
            //rbMain.velocity = moveRight;
            float posX = mainPos.x + (velocity * Time.deltaTime);
            mainPos = new Vector2(posX, mainPos.y);
            transform.position = mainPos;
        }
        else playerMove = "Idle";
    }
    public void MoveLeft()
    {
        mainPos = gameObject.transform.position;
        if (playerScale.x > 0)
        {
            playerScale.x = -playerScale.x;
            transform.localScale = playerScale;
        }
        if (animMain.GetCurrentAnimatorStateInfo(0).IsName("Main-Attack") && animMain.GetCurrentAnimatorStateInfo(0).normalizedTime <= animMain.GetCurrentAnimatorStateInfo(0).length)
        {
            myState = PlayerState.Attack;
        }
        else myState = PlayerState.Run;
        animMain.SetFloat("speed", velocity);
        if (myState != PlayerState.Attack && myState != PlayerState.Hit && myState != PlayerState.Dead)
        {
            playerMove = "Left";
            //Vector2 moveLeft = new Vector2(-velocity, rbMain.velocity.y);
            //rbMain.velocity = moveLeft;
            float posX = mainPos.x - (velocity * Time.deltaTime);
            mainPos = new Vector2(posX, mainPos.y);
            transform.position = mainPos;
        }
        else playerMove = "Idle";
    }
    public void NoMove()
    {
        animMain.SetFloat("speed", 0);
        myState = PlayerState.Idle;
        playerMove = "Idle";
    }
    void CameraMovenment()
    {
        if (transform.position.x >= 0 && cam.transform.position.x <= 245)
        {
            if(!isTouchingPlatform) moveMontains = true;
            Vector3 camMoveX = new Vector3(transform.position.x, cam.transform.position.y, -10);
            cam.transform.position = camMoveX;
        }
        else if (cam.transform.position.x >= 245 && cam.transform.position.x <= 256)
        {
            moveMontains = false;
            if (!musicAS.isPlaying) bossMusic = false;
            if (!bossMusic)
            {
                musicAS.Stop();
                musicAS.PlayOneShot(battleMusic);
                bossMusic = true;
            }
            temps += Time.deltaTime;
            cam.transform.position = Vector3.Lerp(firstCamPos, lastCamPos, temps * 1f);
        }
        else moveMontains = false;

        if (transform.position.y >= initPlayerPos.y+3f)
        {
            Vector3 camMoveY = new Vector3(cam.transform.position.x, (transform.position.y - (initPlayerPos.y+3)), -10);
            cam.transform.position = camMoveY;
        }
        else
        {
            Vector3 camMoveY = new Vector3(cam.transform.position.x, initCamPos.y, -10);
            cam.transform.position = camMoveY;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if ((collision.collider.tag == "Plataforma" && transform.position.y < collision.gameObject.transform.position.y) || collision.collider.tag == "Limit")
        {
            isTouchingPlatform = true;
            moveMontains = false;
        }
        else isTouchingPlatform = false;
    }
}