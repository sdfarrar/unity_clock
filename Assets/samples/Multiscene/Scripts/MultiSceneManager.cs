using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[HelpURL("https://www.youtube.com/watch?v=KRmqy22z0SM")]
public class MultiSceneManager : MonoBehaviour {

	public string initialScene;

	public static MultiSceneManager Instance;

	void Awake(){
		if(Instance!=null){
			Destroy(this.gameObject);
		}

		Instance = this;
		DontDestroyOnLoad(this.gameObject);
		LoadScene(initialScene);
	}

	void Update () {
		
	}

	public void LoadScene(string name){
		SceneManager.LoadSceneAsync(name, LoadSceneMode.Additive);
	}

	public void UnloadScene(string name){
		SceneManager.UnloadSceneAsync(name);
	}

}
