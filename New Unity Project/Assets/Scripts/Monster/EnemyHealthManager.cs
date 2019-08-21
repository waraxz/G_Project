using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour
{
    public int MaxHealth;
    public int CurrentHealth;

    private PlayerStat thePlayerStats;


    public int expToGive;

    public string enemyQuestName;


    // Start is called before the first frame update
    void Start()
    {
         CurrentHealth = MaxHealth;

        thePlayerStats = FindObjectOfType<PlayerStat>();

    }

    // Update is called once per frame
    void Update()
    {
        if (CurrentHealth <= 0)
        {
            Destroy(gameObject);
            thePlayerStats.AddExperience(expToGive);


        }
    }


    public void HurtEnemy(int damageToGive)
    {
        CurrentHealth -= damageToGive;
    }

    public void SetMaxHealth()
    {
        CurrentHealth = MaxHealth;
    }
}
