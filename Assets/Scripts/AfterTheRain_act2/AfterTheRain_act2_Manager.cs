using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AfterTheRain_act2_Manager : MonoBehaviour {
    public static AfterTheRain_act2_Manager ins;
  
    public List<GameObject> lstColorItem;
    public List<GameObject> lstColorSlot;
    [SerializeField]
    int point = 0;

    public int Point
    {
        set { point = value; }
        get { return point; }
    }

    public void IncPoints()
    {
        point++;
    }
    void Start()
    {
        ins = this;
        StartCoroutine(IELate());

    }
    IEnumerator IELate()
    {
        yield return new WaitForSeconds(1);
        Item itm = null;
        ColorObject clrObj = null;
        lstColorItem = InventoryManager.ins.items;
        lstColorSlot = InventoryManager.ins.slots;

        for (int i = 0; i < InventoryManager.ins.items.Count; i++)
        {
            itm = InventoryManager.ins.items[i].GetComponent<Item>();
            if (itm.GetComponent<ColorObject>() != null)
            {
                clrObj = itm.GetComponent<ColorObject>();
                clrObj.OnInserted += IncPoints;
            }
       
            itm.delegateDrop += GameOver;
           
        }
    }

    void GameOver()
    {
        if (point == 4)
        {
           
            print("done");
        }
    }
}
