using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickUp : MonoBehaviour
{
    [SerializeField] Item item;
    [SerializeField] Inventory inventory;
    [SerializeField] int amount = 1;


    private bool isEmpty;
    private bool isInRange;


    public void Start()
    {
        
    }
    private void OnValidate()
    {
        if (inventory == null)
            inventory = FindObjectOfType<Inventory>();
    }

    private void Update()
    {
        if (isInRange && !isEmpty)
        {
            if(item.ID == item.ID)
            {
                Item itemCopy = item.GetCopy();            
                if (inventory.AddItem(itemCopy))
                {
                    // จำนวนไอเท็มลดลงไป 1 คือ 0
                    amount--;
                    // ทำลายไอเท็มหลังเก็บใน inventory
                    Destroy(this.gameObject);
                    // ถ้าไอเท็มไม่มีค่า คือ 0
                    if (amount == 0)
                    {
                        // เก็บไม่ได้แล้ว
                        isEmpty = true;

                    }
                }
                else
                {
                    itemCopy.Destroy();             
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isInRange = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        isInRange = false;
    }
}
