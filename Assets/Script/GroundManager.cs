using UnityEngine;
using System.Collections;

public class GroundManager : MonoBehaviour {

    public GameObject ground;
    public GameObject obstacle;

    private GameObject[] boxes;

	// Use this for initialization
	void Start () {
        boxes = new GameObject[10];
        bool lastWasHole = false;

        //first ground tile should be normal 
        boxes[0] = (GameObject)Instantiate(ground, new Vector3(0,0,0), Quaternion.identity);

        for (int i = 1; i < 10; i++)
        {
            Vector3 pos = new Vector3(i * ground.transform.localScale.x, 0, 0);
            float rand = Random.Range(0.0f, 1.0f);
            if (rand < 0.33)
            {
                //normal
                boxes[i] = (GameObject)Instantiate(ground, pos, Quaternion.identity);
                lastWasHole = false;
            }
            else if (rand < 0.67)
            {
                //obstacle
                boxes[i] = (GameObject)Instantiate(obstacle, pos, Quaternion.identity);
                lastWasHole = false;
            }
            else
            {
                //hole
                if (lastWasHole)
                    boxes[i] = (GameObject)Instantiate(ground, pos, Quaternion.identity);

                lastWasHole = true;
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
