using UnityEngine;
using System.Collections;

public class Bomb : MonoBehaviour {
	public GameObject player;

	private Rigidbody rb;
	private int bCount = 1;

	Player playerIns;

	
	private int bounceForce = 100;

	// Use this for initialization
	void Start () {
		this.GetComponent<ParticleEmitter>().emit = false;
		playerIns = player.GetComponent<Player>();
	}
	
	// Update is called once per frame
	void Update () {
		float distance = this.transform.position.x - player.transform.position.x;

		if(distance < 3) {
			this.GetComponent<ParticleEmitter>().emit = true;
			playerIns.die();
		}
	}

	void OnCollisionEnter(Collision collision) {
		if(bCount == 5)
			Destroy(this);
		
		rb.AddForce(Vector2.up * (bounceForce / bCount));
		++bCount;
	}
}
