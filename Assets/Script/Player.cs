using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public float speed = 1.0f;
    public float JumpSpeed = 100.0f;
    public int holesPassed = 0;
    public int enemiesPassed = 0;

    public bool dead;

    Player playerIns;

    private Rigidbody rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        dead = false;
	}
	
    public void die() {
        dead = true;
    }

    public bool isDead() {
        return dead;
    }

    public void revive() {
        dead = false;
    }

	// Update is called once per frame
	void Update () {

        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        transform.position += move * speed * Time.deltaTime;

        if (Input.GetKeyDown("space"))
        {
            rb.AddForce(Vector2.up * JumpSpeed);
        }
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            rb.transform.localScale = new Vector3(1.0f,0.5f,1.0f);
        }
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            rb.transform.localScale = new Vector3(0.5f,1.0f,1.0f);
        }
	}
}
