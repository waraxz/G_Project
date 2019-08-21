using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat : MonoBehaviour
{

    public int currentLevel;

    public int currentExp;

    public int[] toLevelUp;


    public int currentHP;
    public int currentAttack;
    public int currentDefence;


    private PlayerHealthManager thePlayerHealth;

    ///SeAd
    public int StatPoint;
    public int Strenght;
    public int Intelligent;
    public int Accuracy;
    public int AngelFruit;
    private KnightSkill theKnightSkill;
    private SwordDamage theSwordDamage;
    private int BaseHP = 95;
    private PlayerController theChargingAttack;
    public int currentFaithSkill;
    ///ENDSeAd

    // Start is called before the first frame update
    void Start()
    {
        thePlayerHealth = FindObjectOfType<PlayerHealthManager>();

        ///Self Added
        thePlayerHealth.playerMaxHealth = BaseHP + (currentLevel * 5);
        currentLevel = 1;
        theKnightSkill = FindObjectOfType<KnightSkill>();
        theSwordDamage = FindObjectOfType<SwordDamage>();
        theChargingAttack = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentExp >= toLevelUp[currentLevel])
        {
            LevelUp();
        }

        ///SeAd
        thePlayerHealth.playerMaxHealth = BaseHP + (currentLevel * 5) + (Strenght * 2) + (AngelFruit * 10) + (theKnightSkill.FaithAmount[theKnightSkill.currentFaithSkill]) + ((Strenght * theKnightSkill.FaithPercent[theKnightSkill.currentFaithSkill]) / 100) ;
        currentAttack = 5 + (Strenght * 2) + (theSwordDamage.swordDamage[0]) + (theKnightSkill.SwordMasterAmount[theKnightSkill.currentSwordMasterSkill]) + ((Strenght * theKnightSkill.SwordMasterPercent[theKnightSkill.currentSwordMasterSkill]) / 100);
        currentDefence = Strenght * 2;


        }

    public void AddExperience(int experienceToAdd)
    {
        currentExp += experienceToAdd;

    }

    public void LevelUp()
    {
        currentLevel++;


        ///SeAd
        StatPoint += 2;
        thePlayerHealth.playerCurrentHealth = BaseHP + (currentLevel * 5) + (Strenght * 2) + (AngelFruit * 10) + (theKnightSkill.FaithAmount[theKnightSkill.currentFaithSkill]) + ((Strenght*theKnightSkill.FaithPercent[theKnightSkill.currentFaithSkill])/100);

    }

}
