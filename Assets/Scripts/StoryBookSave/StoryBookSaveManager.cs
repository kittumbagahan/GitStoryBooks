using UnityEngine;
using System.Collections;

public enum ActivityNumber { ONE, TWO, THREE }
public enum Status { DONE, NOT_DONE}

public class StoryBookSaveManager : MonoBehaviour {

	public static StoryBookSaveManager instance;
	
	ActivityNumber activityNumber;

	Status done;
	// Use this for initialization
	void Start () 
	{
		instance = this;
	}

	public void Save(StoryBookEnum.StoryBook book, ActivityNumber activityNumber)
	{
		done = Status.DONE;
		PlayerPrefs.SetString(book.ToString() + "_" + activityNumber.ToString(), done.ToString());
	}

	public string Load(StoryBookEnum.StoryBook book, ActivityNumber activityNumber)
	{
		if(!PlayerPrefs.HasKey(book.ToString() + "_" + activityNumber.ToString()))
		{
			return Status.NOT_DONE.ToString();
		}
		else
		{
			return Status.DONE.ToString();
		}
	}
}
