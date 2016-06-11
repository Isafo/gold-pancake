using UnityEngine;
using System.Collections;

public class GroundManager : MonoBehaviour {

    public GameObject ground;
    public GameObject obstacle;
    public GameObject hole;
    public GameObject enemy;
    public bool hasObstacles = false;
    public int numHoles = 0;
    public int numBoxes = 0;

    private GameObject[] boxes;
    private int current = 0;
    private bool lastWasHole = false;
    private float height;

	// Use this for initialization
	void Start () {
        height = transform.position.y;
        boxes = new GameObject[10];

        //first ground tile should be normal 
        boxes[0] = (GameObject)Instantiate(ground, new Vector3(0,height,0), Quaternion.identity);

        for (int i = 1; i < 10; i++)
        {
            createBox(i);
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (outside(boxes[current]))
        {
            //recreate this box
            Destroy(boxes[current]);
            createBox(current);

            current++;
            if (current == 10)
                current = 0;
        }
	}

    void createBox(int curr)
    {
        float rand1 = Random.Range(0.0f, 1.0f);
        if (rand1 < 0.33)
        {
            //normal
            boxes[curr] = (GameObject)Instantiate(ground, new Vector3(numBoxes * ground.transform.localScale.x, height, 0), Quaternion.identity);
            lastWasHole = false;
        }
        else if (rand1 < 0.67)
        {
            //obstacle
            boxes[curr] = (GameObject)Instantiate(obstacle, new Vector3(numBoxes * ground.transform.localScale.x, height + 0.5f, 0), Quaternion.identity);
            lastWasHole = false;
        }
        else
        {
            //hole
            if (lastWasHole)
                boxes[curr] = (GameObject)Instantiate(ground, new Vector3(numBoxes * ground.transform.localScale.x, height, 0), Quaternion.identity);
            else
            {
                boxes[curr] = (GameObject)Instantiate(hole, new Vector3(numBoxes * ground.transform.localScale.x, height, 0), Quaternion.identity);
                lastWasHole = true;
                numHoles++;
            }
        }
        if (!lastWasHole && hasObstacles) //if this is not a hole and obstacles are possible
        {
            float rand2 = Random.Range(0.0f, 1.0f);
            if (rand2 < 0.25)
                Instantiate(enemy, new Vector3(numBoxes * ground.transform.localScale.x, height - 0.5f, 0), Quaternion.identity);
        }
        numBoxes++;
    }

    bool outside(GameObject go)
    {
        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(Camera.main);
        if (go.GetComponent<Collider>() == null)
        {
            Debug.Log("No collider");
            return false;
        }
        if (!GeometryUtility.TestPlanesAABB(planes, go.GetComponent<Collider>().bounds))
        {
            return true;
        }

        return false;
    }
}
