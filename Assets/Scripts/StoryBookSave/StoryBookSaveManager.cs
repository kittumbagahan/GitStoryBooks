using UnityEngine;
using System.Collections;

//public enum ActivityNumber { ONE, TWO, THREE }
public enum Module { COLORING, SPOTDIFF, MISSINGLETTER }

public class StoryBookSaveManager : MonoBehaviour {

	public static StoryBookSaveManager instance;
	
	//ActivityNumber activityNumber;

	int activityDone = 0;
	
	// Use this for initialization
	void Start () 
	{
		instance = this;
	}

	public void Save(StoryBookEnum.StoryBook book, Module module)
	{
		if(!PlayerPrefs.HasKey((book.ToString() + "+" + module.ToString())))
	   	{
			activityDone = 1;
		}
		else
		{
			activityDone = PlayerPrefs.GetInt(book.ToString() + "+" + module.ToString()) + 1;
		}

		PlayerPrefs.SetInt(book.ToString() + "+" + module.ToString(), activityDone);

		activityDone = 0;// Reset coutn
	}

	public int Load(StoryBookEnum.StoryBook book, Module module)
	{
		if(!PlayerPrefs.HasKey(book.ToString() + "+" + module.ToString()))
		{
			return activityDone;
		}
		else
		{
			return PlayerPrefs.GetInt(book.ToString() + "+" + module.ToString());
		}
	}
}
