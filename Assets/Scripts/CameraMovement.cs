using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {
    GameObject camera;
    public int Boundary = 50;
    public float cameraMoveSpeed = 0.1f;
    public float maxWPoint = -8;
    public float maxSPoint = 17;
    public float maxAPoint = 6;
    public float maxDPoint = -2;
	// Use this for initialization
	void Start () {
        camera = GameObject.Find("Main Camera");
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey("w"))
            camMoveW();
        if (Input.GetKey("s"))
            camMoveS();
        if (Input.GetKey("a"))
            camMoveA();
        if (Input.GetKey("d"))
            camMoveD();
        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
            zoomIn();
        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
            zoomOut();
        if (Input.mousePosition.x > Screen.width - Boundary)
            camMoveD();
        if (Input.mousePosition.x < 0 + Boundary)
            camMoveA();
        if (Input.mousePosition.y > Screen.height - Boundary)
            camMoveW();
        if (Input.mousePosition.y < 0 + Boundary)
            camMoveS();
    }

    public void camMoveW()
    {
        camera.transform.position += new Vector3(0, 0, -cameraMoveSpeed);
        if (camera.transform.position.z < maxWPoint)
            camera.transform.position = new Vector3(camera.transform.position.x, camera.transform.position.y, maxWPoint);
    }

    public void camMoveS()
    {
        camera.transform.position += new Vector3(0, 0, cameraMoveSpeed);
        if (camera.transform.position.z > maxSPoint)
            camera.transform.position = new Vector3(camera.transform.position.x, camera.transform.position.y, maxSPoint);
    }
    public void camMoveA()
    {
        camera.transform.position += new Vector3(cameraMoveSpeed, 0, 0);
        if (camera.transform.position.x > maxAPoint)
            camera.transform.position = new Vector3(maxAPoint, camera.transform.position.y, camera.transform.position.z);
    }
    public void camMoveD()
    {
        camera.transform.position += new Vector3(-cameraMoveSpeed, 0, 0);
        if (camera.transform.position.x < maxDPoint)
            camera.transform.position = new Vector3(maxDPoint, camera.transform.position.y, camera.transform.position.z);
    }
    public void zoomIn()
    {
        camera.transform.position += new Vector3(0, cameraMoveSpeed, 0);
    }
    public void zoomOut()
    {
        camera.transform.position += new Vector3(0, -cameraMoveSpeed, 0);
    }
}
