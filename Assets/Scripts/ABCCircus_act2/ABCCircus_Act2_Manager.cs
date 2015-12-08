using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ABCCircus_Act2_Manager : MonoBehaviour {

    
    void Start () {
        Invoke("E",2f);
    }

    void E()
    {
        // print(WordGameManager.ins.Word);
        SpellClueSlots();
    }

    void SpellClueSlots()
    {
        Transform slot = null;
        Text txt = null;
        for(int i=0; i<WordGameManager.ins.groupClue.transform.childCount; i++)
        {
            slot = WordGameManager.ins.groupClue.transform.GetChild(i);
            txt = slot.GetComponent<Text>();
            txt.text = WordGameManager.ins.Word[i].ToString();
        }
        MoveItems(WordGameManager.ins.groupClue.transform, WordGameManager.ins.groupLetters.transform);
    }

    void MoveItems(Transform from, Transform to)
    {
        GameObject o = null;
        int n = 0;
        //SPAWN SLOT FOR THE ITEMS WILL BE MOVED-------------------------------------------------------
        for (int i=0; i<from.childCount; i++){
            if(from.GetChild(i).childCount == 1){
                n++;
           }
        }
        for (int i=0; i< n; i++)
        {
            o = (GameObject)Instantiate(WordGameManager.ins.slot, transform.position, Quaternion.identity);
            o.transform.SetParent(to);
            o.transform.SetLocalXPos(0);
            o.transform.SetLocalYPos(0);
            o.transform.SetLocalWidth(1);
            o.transform.SetLocalHeight(1);
            o.GetComponent<Text>().enabled = false;
            InventoryManager.ins.slots.Add(o);
        }
        //---------------------------------------------------------------------------------------------
        StartCoroutine(IEReparent(from, to));
        //

    }

    IEnumerator IEReparent(Transform from, Transform to)
    {
        for (int i = 0; i < from.childCount; i++)
        {
            Transform item = null;
            //print(from.childCount);
            if (from.GetChild(i).childCount == 1)
            {
                item = from.GetChild(i).GetChild(0);
                //print(item.name);
                //item.GetComponent<Image>().enabled = false;
                for (int j = 0; j < to.childCount; j++)
                {
                    if (to.GetChild(i).childCount == 0)
                    {
                       // print("x");
                        item.SetParent(to.GetChild(i));
                        item.SetLocalXPos(0);
                        item.SetLocalYPos(0);
                       
                    }
                }
            }
            yield return new WaitForSeconds(0.02f);
        }
    }
}
