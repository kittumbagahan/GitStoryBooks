using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class AfterTheRain_Act1_Manager : MonoBehaviour {

    public enum ETilDirection { left, right}
    public ETilDirection eTiltDir;
    public float maxTilt = 20;
    public Sprite sprtSlotXitemBG;

    Image _img = null;
    Color _clr = Color.white;
    Transform _transSlot = null;
    void Start () {
        // WordGameManager.ins.delGenerateWord += TiltSlots;
        //  WordGameManager.ins.delGenerateWord += ChangeClueSlotsSprite;
        //  WordGameManager.ins.delGenerateWord += ChangeSlotsItemSprite(WordGameManager.ins.groupClue);
        WordGameManager.OnGenerate += TiltSlots;
        WordGameManager.OnGenerate += ChangeClueSlotsSprite;
        WordGameManager.OnGenerate += DisableGroupLettersSlotImage;
        //.OnGenerate += ChangeSlotsItemSprite(WordGameManager.ins.groupClue.transform);
    }


    void TiltSlots()
    {
        //delay the wordgamemanager to make this work on Start()
        for (int i=0; i<InventoryManager.ins.slots.Count; i++)
        {
            RandomTilt(InventoryManager.ins.slots[i].transform);
        }
    }

    void RandomTilt(Transform t)
    {
        int rnd = Random.Range(0, 2);
        switch (rnd)
        {
            case 0:
             
                t.SetLocalZRot(Random.Range(0,20f));
                break;
            case 1:
                
                t.SetLocalZRot(Random.Range(340,360));
                break;
            default: break;
        }
    }

    void ChangeClueSlotsSprite()
    {
        
        _clr.a = 0.5f;
        for (int i=0; i<WordGameManager.ins.groupClue.transform.childCount; i++)
        {
            _img = WordGameManager.ins.groupClue.transform.GetChild(i).GetComponent<Image>();
            _img.sprite = sprtSlotXitemBG;
            _img.color = _clr;
        }
        ChangeSlotsItemSprite(WordGameManager.ins.groupClue.transform);
        ChangeSlotsItemSprite(WordGameManager.ins.groupLetters.transform);
    }

    void DisableGroupLettersSlotImage()
    {
        for (int i=0; i<WordGameManager.ins.groupLetters.transform.childCount; i++)
        {
            WordGameManager.ins.groupLetters.transform.GetChild(i).GetComponent<Image>().enabled = false;
        }
    }

    void ChangeSlotsItemSprite(Transform container)
    {
        for (int i = 0; i < container.childCount; i++)
        {
            _transSlot = container.GetChild(i);
            //print(_transSlot.childCount);
            if(_transSlot.childCount == 1)
            {
                _img = _transSlot.GetChild(0).GetComponent<Image>();
                _img.sprite = sprtSlotXitemBG;
            }
        }
    }
}
