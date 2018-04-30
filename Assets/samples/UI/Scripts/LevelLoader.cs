using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LevelLoader : MonoBehaviour {

	public GameObject loadingScreen;
	public Slider slider;
	public TMP_Text progressText;


	public void LoadLevelWithLoadingBar(int sceneIndex){
		StartCoroutine(LoadAsync(sceneIndex));
	}

	public void LoadLevelWithFade(int sceneIndex){
		StartCoroutine(LoadSyncWithFade(sceneIndex));
	}

	IEnumerator LoadAsync(int sceneIndex){
		AsyncOperation op = SceneManager.LoadSceneAsync(sceneIndex);

		loadingScreen.SetActive(true);

		while(!op.isDone){
			float progress = Mathf.Clamp01(op.progress/0.9f);
			slider.value = progress;
			progressText.text = progress * 100f + "%";
			yield return null; // wait a frame
		}

	}

	IEnumerator LoadSyncWithFade(int sceneIndex){
		float fadeTime = GameObject.Find("_GM").GetComponent<Fading>().BeginFade(1);
		yield return new WaitForSeconds(fadeTime);
		SceneManager.LoadScene(sceneIndex);
	}


}
