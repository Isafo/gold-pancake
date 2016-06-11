using UnityEngine;
using UnityEditor;
using System.Collections;

public class LoseWin : MonoBehaviour
{

    public GameObject player;
    public Camera camera;

    private Plane[] planes;
    private Collider playerCollider;

    private Vector3 playerStartPos;
    private Vector3 cameraStartPos;

    private Rect windowRect;
    private bool dead;
    private bool win;

    // Use this for initialization
    void Start()
    {
        playerCollider = player.GetComponent<Collider>();
        playerStartPos = player.transform.position;
        cameraStartPos = camera.transform.position;

        dead = false;
        win = false;
        windowRect = new Rect(Screen.width / 2 - 60, Screen.height / 2 - 25, 120, 70);
    }

    // Update is called once per frame
    void Update()
    {
        planes = GeometryUtility.CalculateFrustumPlanes(Camera.main);
        if (!GeometryUtility.TestPlanesAABB(planes, playerCollider.bounds))
        {
            dead = true;
        }
    }

    void OnGUI()
    {
        if (dead)
        {
            //stop player
            player.GetComponent<Rigidbody>().isKinematic = true;
            //show window
            windowRect = GUI.Window(0, windowRect, LoseWindowFunc, "You Lost");
        }
        else if (win)
        {
            //stop player
            player.GetComponent<Rigidbody>().isKinematic = true;
            //show window
            windowRect = GUI.Window(0, windowRect, WinWindowFunc, "You Won!");
        }
    }

    void LoseWindowFunc(int windowID)
    {
        if (GUI.Button(new Rect(10, 30, 100, 20), "Restart"))
        {
            restart();
        }
        /*if (GUI.Button(new Rect(10, 40, 100, 20), "Quit")) {
            Application.Quit();
        }*/

    }

    void WinWindowFunc(int windowID)
    {
        if (GUI.Button(new Rect(10, 30, 100, 20), "Restart"))
        {
            restart();
        }
    }

    void restart()
    {
        //for now

        //reset player and camera position
        player.transform.position = playerStartPos;
        camera.transform.position = cameraStartPos;

        //reset player physics
        player.GetComponent<Rigidbody>().isKinematic = false;

        //revive player
        dead = false;
        win = false;

        //start camera
        camera.GetComponent<CameraBehaviour>().isAlive = true;
    }
}
