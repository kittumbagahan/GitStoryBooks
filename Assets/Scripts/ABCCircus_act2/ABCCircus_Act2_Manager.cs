using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;


public class ABCCircus_Act2_Manager : MonoBehaviour {

    public ETiltDirection eTiltDir;
    public float maxTilt = 20;
    public Font font;

    void Start()
    {
        WordGameManager_2.OnGenerate += TiltObjects;
        WordGameManager_2.OnGenerate += DisableItemsImage;
        WordGameManager_2.OnGenerate += ChangeItemsFont;
    }

    void DisableItemsImage()
    {
        Image img = null;
        for(int i=0; i<InventoryManager.ins.items.Count; i++)
        {
            img = InventoryManager.ins.items[i].GetComponent<Image>();
            img.enabled = false;
        }
    }

    void TiltObjects()
    {
        //delay the wordgamemanager to make this work on Start()
        for (int i = 0; i < WordGameManager_2.ins.lstLetters.Count; i++)
        {
            RandomTilt(WordGameManager_2.ins.lstLetters[i].transform);
        }
    }

    void RandomTilt(Transform t)
    {
        int rnd = Random.Range(0, 2);
        switch (rnd)
        {
            case 0:

                t.SetLocalZRot(Random.Range(0, 20f));
                break;
            case 1:

                t.SetLocalZRot(Random.Range(340, 360));
                break;
            default: break;
        }
    }

    void ChangeItemsFont()
    {
        Text txt = null;
        for(int i=0; i<WordGameManager_2.ins.lstLetters.Count; i++)
        {
            txt = WordGameManager_2.ins.lstLetters[i].transform.GetChild(0).GetComponent<Text>();
            txt.font = font;
        }
    }

    //epic fail
    //void Start () {
    //    Invoke("E",2f);
    //}

    //void E()
    //{
    //    // print(WordGameManager.ins.Word);
    //    SpellClueSlots();
    //}

    //void SpellClueSlots()
    //{
    //    Transform slot = null;
    //    Text txt = null;
    //    for(int i=0; i<WordGameManager.ins.groupClue.transform.childCount; i++)
    //    {
    //        slot = WordGameManager.ins.groupClue.transform.GetChild(i);
    //        txt = slot.GetComponent<Text>();
    //     //   txt.text = WordGameManager.ins.Word[i].ToString();
    //    }
    //    MoveItems(WordGameManager.ins.groupClue.transform, WordGameManager.ins.groupLetters.transform);
    //}

    //void MoveItems(Transform from, Transform to)
    //{
    //    GameObject o = null;
    //    int n = 0;
    //    //SPAWN SLOT FOR THE ITEMS WILL BE MOVED-------------------------------------------------------
    //    for (int i=0; i<from.childCount; i++){
    //        if(from.GetChild(i).childCount == 1){
    //            n++;
    //       }
    //    }
    //    for (int i=0; i< n; i++)
    //    {
    //        o = (GameObject)Instantiate(WordGameManager.ins.slot, transform.position, Quaternion.identity);
    //        o.transform.SetParent(to);
    //        o.transform.SetLocalXPos(0);
    //        o.transform.SetLocalYPos(0);
    //        o.transform.SetLocalWidth(1);
    //        o.transform.SetLocalHeight(1);
    //        o.GetComponent<Text>().enabled = false;
    //        InventoryManager.ins.slots.Add(o);
    //    }
    //    //---------------------------------------------------------------------------------------------
    //    StartCoroutine(IEReparent(from, to));
    //    //

    //}

    //IEnumerator IEReparent(Transform from, Transform to)
    //{
    //    for (int i = 0; i < from.childCount; i++)
    //    {
    //        Transform item = null;
    //        //print(from.childCount);
    //        if (from.GetChild(i).childCount == 1)
    //        {
    //            item = from.GetChild(i).GetChild(0);
    //            //print(item.name);
    //            //item.GetComponent<Image>().enabled = false;
    //            for (int j = 0; j < to.childCount; j++)
    //            {
    //                if (to.GetChild(i).childCount == 0)
    //                {
    //                   // print("x");
    //                    item.SetParent(to.GetChild(i));
    //                    item.SetLocalXPos(0);
    //                    item.SetLocalYPos(0);

    //                }
    //            }
    //        }
    //        yield return new WaitForSeconds(0.02f);
    //    }
    //}
}
