using UnityEngine;
using System.Collections;

public class CameraBehaviour : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.Translate(Vector3.right * Time.deltaTime * 2);
	}
}
