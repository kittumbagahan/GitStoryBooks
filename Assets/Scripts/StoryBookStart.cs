using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StoryBookStart : MonoBehaviour {

	[SerializeField]
	RectTransform btnNext, btnPrev, btnRead, btnAct, btnBookShelf, BG;

//	// Use this for initialization
//	void Start () {
//	
//	}
//	
//	// Update is called once per frame
//	void Update () {
//	
//	}

	public void Read()
	{
		btnNext.gameObject.SetActive(true);
		btnPrev.gameObject.SetActive(true);
		btnRead.gameObject.SetActive(false);
		btnAct.gameObject.SetActive(false);
		btnBookShelf.gameObject.SetActive(false);
		BG.GetComponent<RawImage>().color = new Color32(255, 255, 255, 0);
		transform.GetComponent<SceneSpawner>().enabled = true;
	}

	public void ReStart()
	{
		btnNext.gameObject.SetActive(false);
		btnPrev.gameObject.SetActive(false);
		btnRead.gameObject.SetActive(true);
		btnAct.gameObject.SetActive(true);
		btnBookShelf.gameObject.SetActive(true);
		BG.GetComponent<RawImage>().color = new Color32(255, 255, 255, 255);
		transform.GetComponent<SceneSpawner>().enabled = false;
	}

	public void Activity(string name)
	{
		Application.LoadLevel(name);
	}
}
