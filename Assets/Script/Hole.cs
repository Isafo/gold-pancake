using UnityEngine;
using System.Collections;

public class Hole : MonoBehaviour {

    private bool passed = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if (!passed)
        {
            if (other.transform.gameObject.layer == LayerMask.NameToLayer("Player"))
            {
                other.GetComponent<Player>().holesPassed++;
                passed = true;
            }
        }
    }
}
