using UnityEngine;
using System.Collections;

public class SceneLoader : MonoBehaviour {
	
	public static SceneLoader instance;

	// Use this for initialization
	void Start () {
		instance = this;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Load(int index)
	{
		Application.LoadLevel(index);
	}

	public void Load(string name)
	{
		Application.LoadLevel(name);
	}
}
