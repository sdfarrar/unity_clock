using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadSceneTrigger : SceneTrigger {

	void OnTriggerEnter2D(Collider2D other){
		if(sceneName==""){ return; }
		MultiSceneManager.Instance.LoadScene(sceneName);
		box.enabled = false;
	}

}
