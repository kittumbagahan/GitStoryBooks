using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FavoriteBox_Act1_Manager : MonoBehaviour {

    public Sprite itemBG;

	void Start () {
        //WordGameManager.OnGenerate += DisableItemsImage;
         WordGameManager.OnGenerate += ChageItemBG;
        WordGameManager.OnGenerate += ResizeItems;
    }

    void DisableItemsImage()
    {
        Image img = null;
        for (int i = 0; i < InventoryManager.ins.items.Count; i++)
        {
            img = InventoryManager.ins.items[i].GetComponent<Image>();
            img.enabled = false;
        }
    }


    void ResizeItems()
    {
        RectTransform rect = null;
        Text txt = null;
        for(int i=0; i<InventoryManager.ins.items.Count; i++)
        {
            rect = InventoryManager.ins.items[i].GetComponent<RectTransform>();
            rect.SetHeight(70);
            rect.SetWidth(70);
            txt = InventoryManager.ins.items[i].transform.GetChild(0).GetComponent<Text>();
            txt.resizeTextMaxSize = 70;
        }
    }
    void ChageItemBG()
    {
        Image img = null;
        for (int i = 0; i < InventoryManager.ins.items.Count; i++)
        {
            img = InventoryManager.ins.items[i].GetComponent<Image>();
            img.sprite = itemBG;
        }
    }

    void Return(Transform parent, Transform item)
    {

    }
}
