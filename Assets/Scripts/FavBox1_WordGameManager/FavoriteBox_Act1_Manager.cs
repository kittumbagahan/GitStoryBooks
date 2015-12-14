using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FavoriteBox_Act1_Manager : MonoBehaviour {

    public Sprite itemBG;

	void Start () {
        //WordGameManager.OnGenerate += DisableItemsImage;
         WordGameManager.OnGenerate += ChageItemBG;
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

    void ChageItemBG()
    {
        Image img = null;
        for (int i = 0; i < InventoryManager.ins.items.Count; i++)
        {
            img = InventoryManager.ins.items[i].GetComponent<Image>();
            img.sprite = itemBG;
        }
    }
}
