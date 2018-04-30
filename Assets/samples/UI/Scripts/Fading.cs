using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fading : MonoBehaviour {


	public Texture2D fadeOutTexture; // the texture that will overlay the screen. This can be a black image or a loading graphic
	public float fadeSpeed = 0.8f;   // the fade speed

	private int drawDepth = -1000;   // the texture's order in the draw hierarchy: lower numbers mean it renders later/on top
	private float alpha = 1.0f;      // the texture's alpha value between 0 and 1
	private int fadeDir = -1;        // the direction the scene should fade: in = -1 or out = 1

	void Awake(){
		SceneManager.sceneLoaded += OnSceneLoaded;
	}

	void OnGUI(){
		alpha += fadeDir * fadeSpeed * Time.deltaTime;
		alpha = Mathf.Clamp01(alpha);

		// set color of our GUI(texture)
		GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha);
		GUI.depth = drawDepth;
		GUI.DrawTexture(new Rect(0,0, Screen.width, Screen.height), fadeOutTexture); // draw texture to fit the entire screen
	}

	public float BeginFade(int direction){
		fadeDir = direction;
		return fadeSpeed;
	}

	void OnSceneLoaded(Scene scene, LoadSceneMode mode){
		Debug.Log("OnSceneLoaded: " + scene.name);
		Debug.Log(mode);
		BeginFade(-1);
	}

}
