using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public PlayerMovement Instance;

	public float speed = 5f;

	void Awake(){
		if(Instance!=null){ 
			Destroy(this.gameObject); 
			return;
		}

		Instance = this;
		DontDestroyOnLoad(this.gameObject);
	}

	void Update () {
		Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, 0);

		transform.position += input * speed * Time.deltaTime;
	}
}
