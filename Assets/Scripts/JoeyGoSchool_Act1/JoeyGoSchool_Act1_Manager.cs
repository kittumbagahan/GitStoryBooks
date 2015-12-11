using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine.UI;

public class JoeyGoSchool_Act1_Manager : MonoBehaviour {

    public List<AudioClip> lstAudio;
    public List<Text> lstText;

    int index = -1;
    AudioSource audSrc;
    public Sprite[] sprtClicked;
    SpriteState tempSpriteState; //remove button pressed sprite to make this visually working
    [SerializeField]
    Button[] btns = new Button[4];
    Button recentBtnClicked = null;
    void Start()
    {
        index++;
        ListOptions();
        audSrc = GetComponent<AudioSource>();
        for (int i = 0; i < lstText.Count; i++){
            btns[i] = lstText[i].transform.parent.GetComponent<Button>();
        }
    }

    // Update is called once per frame
    void ListOptions()
    {
        lstText.Shuffle();
        switch (index)
        {
            //set A
            case 0: ChangeTextsTo("Carlo", "Joey", "Teacher", "Dad"); break;
            case 1: ChangeTextsTo("Scared", "Happy", "Excited", "Sad"); break;
            case 2: ChangeTextsTo("Aquarium", "Gate", "Building", "School"); break;
            case 3: ChangeTextsTo("Aquarium", "School", "Planet", "Home"); break;
            case 4: ChangeTextsTo("School of Fish", "Octopus", "Snails", "Jellyfish"); break;
            //setA end

            //set B
            case 5: ChangeTextsTo("Banana", "Newt", "Fish", "Frog"); break; 
            case 6: ChangeTextsTo("Net", "House", "School", "Gate"); break; 
            case 7: ChangeTextsTo("He smiled", "He cried", "He laughed", "He danced"); break; 
            case 8: ChangeTextsTo("Mom", "Dad", "Teacher", "Carlo"); break; 
            case 9: ChangeTextsTo("Teacher", "Mom", "Friends", "Dad"); break; 
                                                                           //set B end

            //set C
            case 10: ChangeTextsTo("Jaime", "Peter", "Carlo", "Teacher"); break;
            case 11: ChangeTextsTo("Antlers", "Fins", "A trunk", "A tail"); break;
            case 12: ChangeTextsTo("Sad", "Happy", "Angry", "Afraid"); break; 
           // case 13: ChangeTextsTo("Bone", "Foe", "Moon", "Blue"); break; //shoe
            //case 14: ChangeTextsTo("Tire", "Star", "Shine", "Red"); break; //car
            //set C end


            default: break;
        };
    }


    void ChangeTextsTo(string opt1, string opt2, string opt3, string opt4)
    {
        lstText[0].text = opt1;
        lstText[1].text = opt2;
        lstText[2].text = opt3;
        lstText[3].text = opt4;
    }

    public void Play(Button btnPlay)
    {
        try
        {
            audSrc.clip = lstAudio[index];
        }
        catch (ArgumentOutOfRangeException ex)
        {
            print(ex.Message);
        }
        audSrc.Play();
        btnPlay.interactable = false;
        StartCoroutine(IEPlay(btnPlay));
    }

    public void Choose(GameObject btnOption)
    {
        Text txt = null;

        txt = btnOption.transform.GetChild(0).GetComponent<Text>();
        recentBtnClicked = btnOption.GetComponent<Button>();
        recentBtnClicked.interactable = false;
        //disable other buttons for the meantime to avoid clicking so many button at time
        for (int i = 0; i < btns.Length; i++){
            if (btns[i] != recentBtnClicked){
                btns[i].enabled = false;
            }
        }
        CheckAnswer(txt.text);
    }

    void Correct()
    {
        index++;
        ListOptions();
    }

    IEnumerator IEPlay(Button btnPlay)
    {
        while (audSrc.isPlaying)
        {
            yield return new WaitForSeconds(0.05f);
        }
        btnPlay.interactable = true;

    }

    IEnumerator IECorrect()
    {
        print("Correct!");
        tempSpriteState.disabledSprite = sprtClicked[0];
        recentBtnClicked.spriteState = tempSpriteState;
        yield return new WaitForSeconds(1f);
        index++;
        ListOptions();
        recentBtnClicked.interactable = true;
        for (int i = 0; i < btns.Length; i++)
        {
            btns[i].enabled = true;
        }
    }

    IEnumerator IEWrong()
    {
        print("WRONG");
        tempSpriteState.disabledSprite = sprtClicked[1];
        recentBtnClicked.spriteState = tempSpriteState;
        yield return new WaitForSeconds(1f);
        recentBtnClicked.interactable = true;
        for (int i = 0; i < btns.Length; i++) {
            btns[i].enabled = true;
        }
    }



    void CheckAnswer(string ans)
    {
        switch (index)
        {
            //set A
            case 0:
                if (ans == "Joey")
                {
                    StartCoroutine(IECorrect());
                }
                else
                {
                    StartCoroutine(IEWrong());
                }
                break;
            case 1:
                if (ans == "Scared")
                {
                    StartCoroutine(IECorrect());
                }
                else
                {
                    StartCoroutine(IEWrong());
                }
                break;
            case 2:
                if (ans == "School")
                {
                    StartCoroutine(IECorrect());
                }
                else
                {
                    StartCoroutine(IEWrong());
                }
                break;
            case 3:
                if (ans == "Aquarium")
                {
                    StartCoroutine(IECorrect());
                }
                else
                {
                    StartCoroutine(IEWrong());
                }
                break;
            case 4:
                if (ans == "School of Fish")
                {
                    StartCoroutine(IECorrect());
                }
                else
                {
                    StartCoroutine(IEWrong());
                }
                break;
            //set B
            case 5:
                if (ans == "Fish")
                {
                    StartCoroutine(IECorrect());
                }
                else
                {
                    StartCoroutine(IEWrong());
                }
                break;
            case 6:
                if (ans == "Gate")
                {
                    StartCoroutine(IECorrect());
                }
                else
                {
                    StartCoroutine(IEWrong());
                }
                break;
            case 7:
                if (ans == "He cried")
                {
                    StartCoroutine(IECorrect());
                }
                else
                {
                    StartCoroutine(IEWrong());
                }
                break;
            case 8:
                if (ans == "Mom")
                {
                    StartCoroutine(IECorrect());
                }
                else
                {
                    StartCoroutine(IEWrong());
                }
                break;
            case 9:
                if (ans == "Friends")
                {
                    StartCoroutine(IECorrect());
                }
                else
                {
                    StartCoroutine(IEWrong());
                }
                break;
            //set C
            case 10:
                if (ans == "Teacher")
                {
                    StartCoroutine(IECorrect());
                }
                else
                {
                    StartCoroutine(IEWrong());
                }
                break;
            case 11:
                if (ans == "Fins")
                {
                    StartCoroutine(IECorrect());
                }
                else
                {
                    StartCoroutine(IEWrong());
                }
                break;
            case 12:
                if (ans == "Happy")
                {
                    StartCoroutine(IECorrect());
                }
                else
                {
                    StartCoroutine(IEWrong());
                }
                break;
            //case 13:
            //    if (ans == "Blue")
            //    {
            //        StartCoroutine(IECorrect());
            //    }
            //    else
            //    {
            //        StartCoroutine(IEWrong());
            //    }
            //    break;
            //case 14:
            //    if (ans == "Star")
            //    {
            //        StartCoroutine(IECorrect());
            //    }
            //    else
            //    {
            //        StartCoroutine(IEWrong());
            //    }
            //    break;
            default: print("Game Over"); break;
        }
    }
}
