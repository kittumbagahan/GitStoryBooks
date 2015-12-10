using UnityEngine;
using System.Collections;

public class ActivityDone : MonoBehaviour {

	public static ActivityDone instance;

	public StoryBookEnum.StoryBook storyBook;
	//public ActivityNumber actNumber;
	public Module module;

	[SerializeField]
	RectTransform dialog;

	[SerializeField]
	string levelToLoad;

	public 

	// Use this for initialization
	void Start () {
		instance = this;
	}

	public void Done()
	{
		StartCoroutine(ShowDialog());
	}

	IEnumerator ShowDialog()
	{
		dialog.gameObject.SetActive(true);//Show Dialog
		yield return new WaitForSeconds(5);
		//dialog.gameObject.SetActive(false)
		StoryBookSaveManager.instance.Save(storyBook, module);//Save
		Application.LoadLevel(levelToLoad);
	}

	public void PlayAgain()
	{
		Application.LoadLevel(Application.loadedLevelName);
	}
}
