using UnityEngine;

public class UnloadSceneTrigger : SceneTrigger {

	void OnTriggerEnter2D(Collider2D other){
		if(sceneName==""){ return; }
		MultiSceneManager.Instance.UnloadScene(sceneName);
		box.enabled = false;
	}

}
