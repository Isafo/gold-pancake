using UnityEngine;
using System.Collections;

public class CameraBehaviour : MonoBehaviour {

    public GameObject player;
    public GameObject tile1;
    public GameObject tile2;

    private Plane[] planes;
    private Collider playerCollider;
    private Vector3 playerStartPos;
	public bool isAlive = true;

    private Collider tile1Collider;
    private Collider tile2Collider;

    private int currentColider = 0;
    private int currentTile = 0;

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
        }
        else if (isAlive)
        {
			this.transform.Translate(Vector3.right * Time.deltaTime * 2);
        }

        if(currentColider == 1) {
            if (!GeometryUtility.TestPlanesAABB(planes, tile2Collider.bounds))
            {
                Debug.Log(tile2.transform.position.x);
                //tile2.transform.position.Set(tile2.transform.position.x + 39, 0,0);
                tile2.transform.Translate(Vector3.left * (39 * 2));
                Debug.Log("collided tile2");
                Debug.Log(tile2.transform.position.x);

                currentColider = 0;
           	    currentTile = 0;
            }
        }
        else {
            if (!GeometryUtility.TestPlanesAABB(planes, tile1Collider.bounds))
            {
                Debug.Log(tile1.transform.position.x);
                tile1.transform.Translate(Vector3.left * (39 * 2));
                //tile1.transform.position.Set(tile1.transform.position.x + 39, 0,0);
                Debug.Log("collided tile1");
                Debug.Log(tile1.transform.position.x);

                currentColider = 1;
                currentTile = 1;
            }
        }
	}
}
