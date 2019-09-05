using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyPanel : MonoBehaviour
{

    public GameObject key, key1, key2, key3, key4,key5;

    // Start is called before the first frame update
    void Start()
    {
        key.gameObject.SetActive(false);
        key1.gameObject.SetActive(false);
        key2.gameObject.SetActive(false);
        key3.gameObject.SetActive(false);
        key4.gameObject.SetActive(false);
        key5.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        QuestKey();
        UseKey();
        
    }

   public void QuestKey()
    {
        //ทำเควสเสร้จแล้วให้สามารถ setactive แต่ละกุญแจ
        if (Input.GetKeyDown(KeyCode.P))
        {
            key.gameObject.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.O))
        {
            key1.gameObject.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.I))
        {
            key2.gameObject.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.U))
        {
            key3.gameObject.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.Y))
        {
            key4.gameObject.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.T))
        {
            key5.gameObject.SetActive(true);
        }

    }
    public void UseKey()
    {
        if(key.gameObject.activeSelf)
        {
            //ใส่ฟังค์ชั่นลง
        }
        if (key1.gameObject.activeSelf)
        {
            //ใส่ฟังค์ชั่นลง
        }
        if (key2.gameObject.activeSelf)
        {
            //ใส่ฟังค์ชั่นลง
        }
        if (key3.gameObject.activeSelf)
        {
            //ใส่ฟังค์ชั่นลง
        }
        if (key4.gameObject.activeSelf)
        {
            //ใส่ฟังค์ชั่นลง
        }
        if (key5.gameObject.activeSelf)
        {
            //ใส่ฟังค์ชั่นลง
        }
    }

}
