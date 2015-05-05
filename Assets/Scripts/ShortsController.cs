using UnityEngine;
using System.Collections;

public class ShortsController : MonoBehaviour {
	

	public Material[] materials;
	

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		float dx = Input.GetAxis ("Mouse X") * 10f;
		transform.Rotate (new Vector3 (0, 0, dx));
	
	}
}
