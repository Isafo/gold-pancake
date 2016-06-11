using UnityEngine;
using System.Collections;

public class CameraBehaviour : MonoBehaviour {

    public GameObject player;

	public Canvas lose;

    private Plane[] planes;
    private Collider playerCollider;
    private Vector3 playerStartPos;
	private bool isAlive = true;

	// Use this for initialization
    void Start()
    {
        playerCollider = player.GetComponent<Collider>();
        playerStartPos = player.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        planes = GeometryUtility.CalculateFrustumPlanes(Camera.main);
        if (!GeometryUtility.TestPlanesAABB(planes, playerCollider.bounds) && isAlive)
        {
            isAlive = false;
			Debug.Log("is dead");
			lose.GetComponent<CanvasGroup>().alpha = 1f;

        }
        else if (isAlive)
        {
			this.transform.Translate(Vector3.right * Time.deltaTime * 2);
        }
	}
}
