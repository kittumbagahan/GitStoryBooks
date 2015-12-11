using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FavoriteBox_Act1_Manager : MonoBehaviour {

	// Use this for initialization
	void Start () {
        WordGameManager.OnGenerate += DisableItemsImage;
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
}
