using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour {
    public float moveSpeed;
    private float currentMoveSpeed;

    private Animator anim;
    private Rigidbody2D myRigidbody;


    private bool playerMoving;
    public Vector2 lastMove;
    private Vector2 moveInput;

    private static bool playerExists;

    private bool attacking;
    public float attackTime;
    private float attackTimeCounter;

    private SFXManager sfxMan;

    //SeAd
    private bool mousePressing;
    private  bool chargingAttack;
    private float mousePressingTime;
    private PlayerStat thePlayerStat;
    private SwordDamage theSwordDamage;
    private KnightSkill theKnightSkill;
    public int currentAttack;


    // Start is called before the first frame update
    void Start() {
        anim = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();
        sfxMan = FindObjectOfType<SFXManager>();


        if (!playerExists)
        {
            playerExists = true;
            DontDestroyOnLoad(transform.gameObject);
        } else {
            Destroy(gameObject);
        }


        //SeAd
        theKnightSkill = FindObjectOfType<KnightSkill>();
        theSwordDamage = FindObjectOfType<SwordDamage>();
        thePlayerStat = FindObjectOfType<PlayerStat>();
        

    }

    // Update is called once per frame
    void Update() {

        playerMoving = false;

        //SeAd
        chargingAttack = false;
        attacking = false;

        if (!attacking)
        {

            moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
            if (moveInput != Vector2.zero)
            {
                myRigidbody.velocity = new Vector2(moveInput.x * moveSpeed, moveInput.y * moveSpeed);
                playerMoving = true;
                lastMove = moveInput;
            }
            else
            {
                myRigidbody.velocity = Vector2.zero;
            }
        }
        //SeAd
        if (Input.GetMouseButtonDown(0))
        {
            mousePressingTime = Time.time;
            mousePressing = true;
            anim.SetBool("MousePressing", true);
        }

        if (Input.GetMouseButtonUp(0) && Time.time - mousePressingTime >= 1)
        {
            chargingAttack = true;
            attacking = false;

        }
        else
        {
            if (Input.GetMouseButtonUp(0) && Time.time - mousePressingTime < 1)
            {
                chargingAttack = false;
                attacking = true;
            }
        }


        if (chargingAttack)
        {
            attackTimeCounter = attackTime;
            myRigidbody.velocity = Vector2.zero;
            //Tell Animator
            anim.SetBool("ChargingAttack", true);
            anim.SetBool("MousePressing", false);
        }

        if (attacking)
        {
            attackTimeCounter = attackTime;
            myRigidbody.velocity = Vector2.zero;
            //Tell Animator
            anim.SetBool("Attack", true);
            anim.SetBool("MousePressing", false);

            sfxMan.playerSlash.Play();
        }

        //EndSeAd//



        if (attackTimeCounter >= 0)
        {
            attackTimeCounter -= Time.deltaTime;
        }

        if (attackTimeCounter <= 0)
        {
            attacking = false;
            anim.SetBool("Attack", false);

            chargingAttack = false;
            anim.SetBool("ChargingAttack", false);
        }



        anim.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
        anim.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));
        anim.SetBool("PlayerMoving", playerMoving);
        anim.SetFloat("LastMoveX", lastMove.x);
        anim.SetFloat("LastMoveY", lastMove.y);
    }
}
