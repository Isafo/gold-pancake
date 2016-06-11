using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    private bool passed = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    void OnTriggerExit(Collider other)
    {
        if (!passed)
        {
            if (other.transform.gameObject.layer == LayerMask.NameToLayer("Player"))
            {
                other.GetComponent<Player>().enemiesPassed++;
                passed = true;
            }
        }
    }
}
