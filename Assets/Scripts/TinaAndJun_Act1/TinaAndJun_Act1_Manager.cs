using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;


public class TinaAndJun_Act1_Manager : MonoBehaviour {

    public Sprite[] sprts;
    public GameObject item;
    public Transform itemContainer;

    int sprtIndex = 0;
    [SerializeField]
    int pts = 0;
	void Start () {
        sprts.Shuffle();
        Generate();
	}

    void Generate() {
        for(int i=0; i<4; i++)
        {
            GameObject o = (GameObject)Instantiate(item, new Vector3(0,0,0), Quaternion.identity);
            Reparent(o.transform);
            InventoryManager.ins.items.Add(o);
        }
       
        ChangeSprite();
        SetItemsID();
    }

    void Reparent(Transform item)
    {
        Slot s = null;
        bool f = false;
        for(int i=0; i<InventoryManager.ins.slots.Count; i++)
        {
            s = InventoryManager.ins.slots[i].GetComponent<Slot>();
            if (s.empty && !f)
            {
                item.SetParent(InventoryManager.ins.slots[i].transform);
                item.SetLocalXPos(0);
                item.SetLocalYPos(0);
                item.GetComponent<RectTransform>().SetHeight(160);
                item.GetComponent<RectTransform>().SetWidth(160);
                //item.SetLocalHeight(160);
                //item.SetLocalWidth(160);
                s.empty = false;
                f = true;
            }
        }
    }

    void ChangeSprite()
    {
        
        for (int i = 0; i< InventoryManager.ins.items.Count; i++)
        {
            Image img = null;
            img = InventoryManager.ins.items[i].GetComponent<Image>();
            img.sprite = sprts[sprtIndex];
            sprtIndex++;
        }
    }

    void SetItemsID()
    {
        Item itm = null;
        for (int i=0; i<InventoryManager.ins.items.Count; i++)
        {
            itm = InventoryManager.ins.items[i].GetComponent<Item>();
            string s = InventoryManager.ins.items[i].GetComponent<Image>().sprite.name.ToUpper();
            if (s.Contains("EE") || s.Contains("EA"))
            {
                itm.eColor = EID.red;
            }
            else if (s.Contains("OO"))
            {
                itm.eColor = EID.green;
            }
        }
    }

    void IncPts()
    {
        pts++;
    }
}
