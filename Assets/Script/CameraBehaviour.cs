using UnityEngine;
using System.Collections;

public class CameraBehaviour : MonoBehaviour {

    public GameObject player;
    public GameObject tile1;
    public GameObject tile2;

	public Canvas lose;

    private Plane[] planes;
    private Collider playerCollider;
    private Vector3 playerStartPos;
	private bool isAlive = true;

    private Collider tile1Collider;
    private Collider tile2Collider;
    

	// Use this for initialization
    void Start()
    {
        playerCollider = player.GetComponent<Collider>();
        playerStartPos = player.transform.position;

        tile1Collider = tile1.GetComponent<Collider>();
        tile2Collider = tile2.GetComponent<Collider>();
	}
	
	// Update is called once per frame
	void Update () {
        planes = GeometryUtility.CalculateFrustumPlanes(Camera.main);
        if (!GeometryUtility.TestPlanesAABB(planes, playerCollider.bounds) && isAlive)
        {
            isAlive = false;
			Debug.Log("is dead");

        }
        else if (isAlive)
        {
			this.transform.Translate(Vector3.right * Time.deltaTime * 2);
        }


        if (!GeometryUtility.TestPlanesAABB(planes, tile1Collider.bounds))
        {
            tile1.transform.Translate(Vector3.right * 4);
        }
        if (!GeometryUtility.TestPlanesAABB(planes, tile2Collider.bounds))
        {
            tile2.transform.Translate(Vector3.right * 4);
        }
	}
}
