using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public float speed = 1.0f;
    public float JumpSpeed = 100.0f;
    public int holesPassed = 0;

    private Rigidbody rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
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
            Debug.Log("down");
            rb.transform.localScale = new Vector3(1.5f,0.5f,1.0f);
        }
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            Debug.Log("down");
            rb.transform.localScale = new Vector3(1.0f,1.0f,1.0f);
        }
	}
}
