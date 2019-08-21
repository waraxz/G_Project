using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtEnemy : MonoBehaviour
{

    private int currentDamage;

    public GameObject damageBurst;
    //public Transform hitPoint;
    public GameObject damageNumber;

    

    /// SeAd
    private PlayerStat thePlayerStat;
    private KnightSkill theKnightSkill;
    private PlayerController thePlayerController;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        ///SeAd
        thePlayerStat = FindObjectOfType<PlayerStat>();
        theKnightSkill = FindObjectOfType<KnightSkill>();
        thePlayerController = FindObjectOfType<PlayerController>();

    }

    // Update is called once per frame
    void Update()
    {


    }

    void OnTriggerEnter2D(Collider2D other)
    {

        
        ///



        if (other.gameObject.tag == "Enemy")
        {
            currentDamage = thePlayerStat.currentAttack;

            other.gameObject.GetComponent<EnemyHealthManager>().HurtEnemy(currentDamage);
            //DamageBurst
            //Instantiate(damageBurst, other.transform.position, hitPoint.rotation);
            Instantiate(damageBurst, other.transform.position, other.transform.rotation);
            var clone = (GameObject) Instantiate(damageNumber, other.transform.position, Quaternion.Euler(Vector3.zero));
            clone.GetComponent<FloatingNumber>().damageNumber = currentDamage;

        }



    }


    



}
