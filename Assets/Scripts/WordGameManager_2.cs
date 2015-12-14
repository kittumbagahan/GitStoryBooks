using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine.UI;

public class WordGameManager_2 : MonoBehaviour {
    public static WordGameManager_2 ins;

    public string[] wordArr;
    //inventory canvas
    public GameObject groupClue, groupLetters;
    public GameObject slot, itemLetter;
    //end inventory canvas
    public List<GameObject> lstLetters;
    public delegate void ActionGenerate();
    public static event ActionGenerate OnGenerate;

    int wordArrIndex = 0;
    void Start()
    {
        ins = this;
        wordArr.Shuffle();
        GenerateWord();
    }

    void SpawnSlotTo(Transform container, List<GameObject> lstInventory)
    {
        GameObject o = null;
     
        o = (GameObject)Instantiate(slot, transform.position, Quaternion.identity);
        o.transform.SetParent(container);
        o.transform.SetLocalXPos(0);
        o.transform.SetLocalYPos(0);
        o.transform.SetLocalWidth(1);
        o.transform.SetLocalHeight(1);
        lstInventory.Add(o);

    }

    void GenerateWord()
    {
        for (int i=0; i<wordArr[wordArrIndex].Length; i++)
        {
            SpawnSlotTo(groupClue.transform, InventoryManager.ins.slots);
            SpawnSlotTo(groupLetters.transform, InventoryManager.ins.slots);
        }
        ChangeClueLetters();
        DisableSlotsText();
        for (int i=0; i<wordArr[wordArrIndex].Length; i++)
        {
            SpawnLetterTo(groupLetters.transform.GetChild(i), InventoryManager.ins.items, lstLetters);
        }
        ChangeItemsText();
        for (int i=0; i<InventoryManager.ins.slots.Count; i++)
        {
            Slot s = InventoryManager.ins.slots[i].GetComponent<Slot>();
            s.CheckSlot();
        }
        InventoryManager.ins.InitSlotEvents();
        
        if(OnGenerate != null)
        {
            OnGenerate();
        }
    }

    void ChangeClueLetters()
    {
        for (int i=0; i<groupClue.transform.childCount; i++)
        {
            Text txt = groupClue.transform.GetChild(i).GetComponent<Text>();
            txt.text = wordArr[wordArrIndex][i].ToString();
        }
    }

    void DisableSlotsText() {
        for (int i=0; i<groupLetters.transform.childCount; i++)
        {
            groupLetters.transform.GetChild(i).GetComponent<Text>().enabled = false;
        }
    }

    void SpawnLetterTo(Transform parent, List<GameObject> lstInventory, List<GameObject> lstLetters)
    {
        GameObject o = null;
  
        o = (GameObject)Instantiate(itemLetter, transform.position, Quaternion.identity);
        o.transform.SetParent(parent);
        o.transform.SetLocalXPos(0);
        o.transform.SetLocalYPos(0);
        o.transform.SetLocalWidth(1);
        o.transform.SetLocalHeight(1);
  
        lstInventory.Add(o);
        lstLetters.Add(o);
    }

    void ChangeItemsText()
    {
        Text txt = null;
        lstLetters.Shuffle();
        for(int i=0; i<lstLetters.Count; i++)
        {
            txt = lstLetters[i].transform.GetChild(0).GetComponent<Text>();
            txt.text = wordArr[wordArrIndex][i].ToString();
        }
    }

}
