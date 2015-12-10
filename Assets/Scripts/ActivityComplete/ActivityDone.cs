using UnityEngine;
using System.Collections;

public class ActivityDone : MonoBehaviour {

	public static ActivityDone instance;

	[SerializeField]
	RectTransform dialog;

	[SerializeField]
	string levelToLoad;

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
		dialog.gameObject.SetActive(true);
		yield return new WaitForSeconds(5);
		//dialog.gameObject.SetActive(false)
		Application.LoadLevel(levelToLoad);
	}

	public void PlayAgain()
	{
		Application.LoadLevel(Application.loadedLevelName);
	}
}
