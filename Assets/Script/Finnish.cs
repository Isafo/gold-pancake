using UnityEngine;
using System.Collections;

public class Finnish : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision collision) {
        winText.renderer.enabled=true;
    }
}
