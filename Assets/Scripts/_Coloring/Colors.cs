using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Colors : AspectManager {

    public static Colors instance;

    public enum COLORS { NULL, BLUE, GREY, FLESH, BROWN, GREEN, PURPLE, RED, YELLOW };
	//public enum BOOKACT { NULL, FAVBOX, COLORSALLMIXEDUP };

    public static COLORS selectedColor = COLORS.NULL;

	[SerializeField] StoryBookEnum.StoryBook bookAct;

    [SerializeField]
    RectTransform CompleteButton;

//	[SerializeField]
//	Text text;
	
    // Use this for initialization
    void Start () {
        instance = this;

		Aspect();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SelectedColor()
    {
        print(selectedColor.ToString());
    }

    public Color32 SelectedColorValue()
    {
        switch(selectedColor)
        {
            case COLORS.BLUE:
                return new Color32(94, 132, 160, 255);
                break;
            case COLORS.GREY:
                return new Color32(108, 99, 107, 255);
                break;
            case COLORS.FLESH:
                return new Color32(232, 194, 127, 255);
                break;
            case COLORS.BROWN:
                return new Color32(171, 116, 83, 255);
                break;
            case COLORS.GREEN:
                return new Color32(48, 73, 9, 255);
                break;
			case COLORS.YELLOW:
				return new Color32(255, 255, 153, 255);
				break;
			case COLORS.RED:
				return new Color32(207, 47, 47, 255);
				break;
			case COLORS.PURPLE:
				return new Color32(174, 76, 231, 255);
				break;
            default:
                return new Color32(255, 255, 255, 255);
                break;
        }        
    }

    int ctr = 0;
    public void ClickCheck()
    {
        ctr++;        
		switch(bookAct)
		{
		case StoryBookEnum.StoryBook.FAVORITE_BOX:
			if(ctr == 5)
			{
				print("Colored all area");
				CompleteButton.gameObject.SetActive(true);
			}
			break;
		case StoryBookEnum.StoryBook.COLORS_ALL_MIXED_UP:
			if(ctr == 6)
			{
				print("Colored all area");
				CompleteButton.gameObject.SetActive(true);
			}
			break;
		}
    }
}
