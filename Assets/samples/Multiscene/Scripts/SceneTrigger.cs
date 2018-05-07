using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class SceneTrigger : MonoBehaviour {

	public string sceneName;
	protected BoxCollider2D box;

	private void Start(){
		box = GetComponent<BoxCollider2D>();
	}
	
}
