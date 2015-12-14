using UnityEngine;
using System.Collections;

public class ChatAspect : AspectManager {

	[SerializeField]
	RectTransform gameCompleteDialog;

	// Use this for initialization
	void Start () {
		Aspect();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void GameCompleteDialog()
	{
		StartCoroutine("_IEGameComplete");
	}

	IEnumerator _IEGameComplete()
	{
		gameCompleteDialog.gameObject.SetActive(true);
		yield return new WaitForSeconds(3);
		gameCompleteDialog.gameObject.SetActive(false);
		Application.LoadLevel(Application.loadedLevel);
	}
}
