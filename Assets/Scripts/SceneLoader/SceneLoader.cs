using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour {
	
	public static SceneLoader instance;

	[SerializeField]
	Text loading;
	// Use this for initialization
	void Start () {
		instance = this;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public IEnumerator Load(int index)
	{
		AsyncOperation async = Application.LoadLevelAsync(index);
		yield return async;
	}

	public IEnumerator Load(string name)
	{
		loading.gameObject.SetActive(true);
		AsyncOperation async = Application.LoadLevelAsync(name);
		yield return async;
	}
}
