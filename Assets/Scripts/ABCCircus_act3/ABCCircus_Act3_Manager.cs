using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;

public class ABCCircus_Act3_Manager : MonoBehaviour {

    public List<AudioClip> lstAudio;
    public List<Text> lstText;

    int index = -1;
    AudioSource audSrc;
    public Color32[] clr;

    Button recentBtnClicked = null;
    
    void Start()
    {
        index++;
        ListOptions();
        audSrc = GetComponent<AudioSource>();
    }
    void ListOptions()
    {
        lstText.Shuffle();
        switch (index)
        {
            //set A
            case 0: ChangeTextsTo("A", "B", "C"); break;    //B
            case 1: ChangeTextsTo("C", "D", "E"); break;    //E
            case 2: ChangeTextsTo("F", "G", "H"); break;    //G
            case 3: ChangeTextsTo("I", "K", "L"); break;    // I
            case 4: ChangeTextsTo("M", "Z", "X"); break;    //Z
            //setA end

            //set B
            case 5: ChangeTextsTo("P", "Q", "R"); break; //Q
            case 6: ChangeTextsTo("F", "E", "A"); break; //F
            case 7: ChangeTextsTo("H", "A", "E"); break; //H
            case 8: ChangeTextsTo("C", "S", "L"); break; //S
            case 9: ChangeTextsTo("V", "B", "P"); break; //V
            //set B end

            //set C
            case 10: ChangeTextsTo("D", "B", "G"); break; //B
            case 11: ChangeTextsTo("H", "A", "J"); break; //J
            case 12: ChangeTextsTo("S", "K", "I"); break; //K
            case 13: ChangeTextsTo("J", "K", "I"); break; //I
            case 14: ChangeTextsTo("N", "M", "P"); break; //N
            //set C end


            default: break;
        };
    }

    void ChangeTextsTo(string opt1, string opt2, string opt3)
    {
        lstText[0].text = opt1;
        lstText[1].text = opt2;
        lstText[2].text = opt3;
    
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
        //recentBtnClicked.interactable = false;
        CheckAnswer(txt);
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

    IEnumerator IECorrect(Text txt)
    {
        print("Correct!");
        txt.color = clr[0];
        yield return new WaitForSeconds(1f);
        index++;
        ListOptions();
        recentBtnClicked.interactable = true;
        txt.color = clr[2];
    }

    IEnumerator IEWrong(Text txt)
    {
  
        print("WRONG");
        txt.color = clr[1];
        yield return new WaitForSeconds(0.5f);
        recentBtnClicked.interactable = true;
        txt.color = clr[2];
    }

    void CheckAnswer(Text txtChosen)
    {
        String ans = txtChosen.text;
        switch (index)
        {
            //set A
            case 0:
                if (ans == "B")
                {
                    StartCoroutine(IECorrect(txtChosen));
                }
                else
                {
                    StartCoroutine(IEWrong(txtChosen));
                }
                break;
            case 1:
                if (ans == "E")
                {
                    StartCoroutine(IECorrect(txtChosen));
                }
                else
                {
                    StartCoroutine(IEWrong(txtChosen));
                }
                break;
            case 2:
                if (ans == "G")
                {
                    StartCoroutine(IECorrect(txtChosen));
                }
                else
                {
                    StartCoroutine(IEWrong(txtChosen));
                }
                break;
            case 3:
                if (ans == "I")
                {
                    StartCoroutine(IECorrect(txtChosen));
                }
                else
                {
                    StartCoroutine(IEWrong(txtChosen));
                }
                break;
            case 4:
                if (ans == "Z")
                {
                    StartCoroutine(IECorrect(txtChosen));
                }
                else
                {
                    StartCoroutine(IEWrong(txtChosen));
                }
                break;
            //set B
            case 5:
                if (ans == "Q")
                {
                    StartCoroutine(IECorrect(txtChosen));
                }
                else
                {
                    StartCoroutine(IEWrong(txtChosen));
                }
                break;
            case 6:
                if (ans == "F")
                {
                    StartCoroutine(IECorrect(txtChosen));
                }
                else
                {
                    StartCoroutine(IEWrong(txtChosen));
                }
                break;
            case 7:
                if (ans == "H")
                {
                    StartCoroutine(IECorrect(txtChosen));
                }
                else
                {
                    StartCoroutine(IEWrong(txtChosen));
                }
                break;
            case 8:
                if (ans == "S")
                {
                    StartCoroutine(IECorrect(txtChosen));
                }
                else
                {
                    StartCoroutine(IEWrong(txtChosen));
                }
                break;
            case 9:
                if (ans == "V")
                {
                    StartCoroutine(IECorrect(txtChosen));
                }
                else
                {
                    StartCoroutine(IEWrong(txtChosen));
                }
                break;
            //set C
            case 10:
                if (ans == "B")
                {
                    StartCoroutine(IECorrect(txtChosen));
                }
                else
                {
                    StartCoroutine(IEWrong(txtChosen));
                }
                break;
            case 11:
                if (ans == "J")
                {
                    StartCoroutine(IECorrect(txtChosen));
                }
                else
                {
                    StartCoroutine(IEWrong(txtChosen));
                }
                break;
            case 12:
                if (ans == "K")
                {
                    StartCoroutine(IECorrect(txtChosen));
                }
                else
                {
                    StartCoroutine(IEWrong(txtChosen));
                }
                break;
            case 13:
                if (ans == "I")
                {
                    StartCoroutine(IECorrect(txtChosen));
                }
                else
                {
                    StartCoroutine(IEWrong(txtChosen));
                }
                break;
            case 14:
                if (ans == "N")
                {
                    StartCoroutine(IECorrect(txtChosen));
                }
                else
                {
                    StartCoroutine(IEWrong(txtChosen));
                }
                break;
            default: print("Game Over"); break;
        }
    }
}
