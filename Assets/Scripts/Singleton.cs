using UnityEngine;
using System.Collections;

public class Singleton : MonoBehaviour {

	static Singleton instance;

	void Awake()
	{
		if(instance == null)
		{
			instance = this;
			DontDestroyOnLoad(gameObject);
		}
		else
		{
			Destroy(gameObject);
		}
	}
}
