using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fractal : MonoBehaviour {

	public Mesh[] meshes;
	public Material material;

	public int maxDepth;
	public float childScale;

	public float spawnProbability;
	public float maxRotationSpeed;
	public float maxTwist;

	private int depth;
	private float rotationSpeed;

	struct ChildSettings {
		public Vector3 direction;
		public Quaternion orientation;
		public ChildSettings(Vector3 dir, Quaternion orientation){
			this.direction = dir;
			this.orientation = orientation;
		}
	}

	private static ChildSettings[] childSettings = {
		new ChildSettings(Vector3.up, Quaternion.identity),
		new ChildSettings(Vector3.right, Quaternion.Euler( 0f,  0f, -90f)),
		new ChildSettings(Vector3.left, Quaternion.Euler( 0f,  0f, 0f)),
		new ChildSettings(Vector3.forward, Quaternion.Euler(90f, 0f, 0f)),
		new ChildSettings(Vector3.back, Quaternion.Euler(-90f, 0f, 0f)),
	};

	private Material[,] materials;

	private void InitializeMaterials(){
		materials = new Material[maxDepth+1, 2];
		for(int i=0; i<= maxDepth; ++i){
			float t = i / (maxDepth - 1f);
			t *= t;
			materials[i, 0] = new Material(material);
			materials[i, 0].color = Color.Lerp(Color.white, Color.yellow, t);
			materials[i, 1] = new Material(material);
			materials[i, 1].color = Color.Lerp(Color.white, Color.cyan, t);
		}
		materials[maxDepth, 0].color = Color.magenta;
		materials[maxDepth, 1].color = Color.red;
	}

	private void Start () {
		rotationSpeed = Random.Range(-maxRotationSpeed, maxRotationSpeed);
		transform.Rotate(Random.Range(-maxTwist, maxTwist), 0f, 0f);
		if(materials==null){
			InitializeMaterials();
		}
		gameObject.AddComponent<MeshFilter>().mesh = meshes[Random.Range(0, meshes.Length)];
		gameObject.AddComponent<MeshRenderer>().material = materials[depth, Random.Range(0, 2)];
		if(depth < maxDepth){
			StartCoroutine(CreateChildren());
		}
	}

	private void Update(){
		transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);
	}

	private IEnumerator CreateChildren(){
		for(int i=0; i< childSettings.Length; ++i){
			if(Random.value < spawnProbability){
				yield return new WaitForSeconds(Random.Range(0.1f, 0.5f));
				new GameObject("Fractal Child").AddComponent<Fractal>().Initialize(this, childSettings[i]);
			}
		}
	}
	
	private void Initialize(Fractal parent, ChildSettings settings){
		meshes = parent.meshes;
		materials = parent.materials;
		material = parent.material;
		maxDepth = parent.maxDepth;
		depth = parent.depth + 1;
		spawnProbability = parent.spawnProbability;
		childScale = parent.childScale;
		maxRotationSpeed = parent.maxRotationSpeed;
		maxTwist = parent.maxTwist;
		transform.parent = parent.transform;
		transform.localScale = Vector3.one * childScale;
		transform.localPosition = settings.direction * (0.5f + 0.5f * childScale);
		transform.localRotation = settings.orientation;
	}

}
