using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ABCCircus_Act1_Manager : MonoBehaviour {

    public Text[] txtLetter;
    public Text txtBig;
    string[] strRecent = { "","","","" };
    public Color32[] clr;

    int pts = 0;
	void Start () {
        Generate();
	}
	void Generate()
    {
        txtLetter.Shuffle();
        clr.Shuffle();
        txtBig.text = MonoExtension.RandomLetter();
        
        txtLetter[0].text = txtBig.text.ToLower();
        txtLetter[0].color = clr[0];
        strRecent[0] = txtLetter[0].text;
        RandomText(txtLetter[1], txtBig.text, strRecent);
        strRecent[1] = txtLetter[1].text;
        txtLetter[1].color = clr[1];
        RandomText(txtLetter[2], txtBig.text, strRecent);
        strRecent[2] = txtLetter[2].text;
        txtLetter[2].color = clr[2];
        RandomText(txtLetter[3], txtBig.text, strRecent);
        strRecent[3] = txtLetter[3].text;
        txtLetter[3].color = clr[3];
    }

    void RandomText(Text txt, string strUnique, string[] recent)
    {
        txt.text = strUnique;
        while(txt.text == strUnique)
        {
            txt.text = MonoExtension.RandomLetter().ToLower();
            for (int i=0; i<recent.Length; i++) {
                if (txt.text == recent[i])
                {
                    RandomText(txt, strUnique, recent);
                }
            }
        }
       
    }

    public void Choose(Text txt)
    {
        if (txt.text.ToUpper() == txtBig.text.ToUpper())
        {
            print("CORRECT!");
            pts++;
            Generate();
        }
        else {
            print("WRONG");
        }
    }
}
