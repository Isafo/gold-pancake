using UnityEngine;
using System.Collections;

public class CameraBehaviour : MonoBehaviour {

    public GameObject player;

    private Plane[] planes;
    private Collider playerCollider;
    private Vector3 playerStartPos;

	// Use this for initialization
    void Start()
    {
        playerCollider = player.GetComponent<Collider>();
        playerStartPos = player.transform.position;
	
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.Translate(Vector3.right * Time.deltaTime * 2);

        planes = GeometryUtility.CalculateFrustumPlanes(Camera.main);
        if (!GeometryUtility.TestPlanesAABB(planes, playerCollider.bounds))
        {
            //dead = true;
        }
        /*if (player.transform.position.y >= (playerStartPos.y + winDistance))
        {
            //win = true;
        }
        if (!player.GetComponent<Player>().alive)
        {
            //dead = true;
            print("Dead");
        }*/
	}
}
