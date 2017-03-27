using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerScript : MonoBehaviour {
    bool selectmode;
    bool movemode;
    List<GameObject> selist = new List<GameObject>();
	// Use this for initialization
	void Start () {
        selectmode = true;
        movemode = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (selectmode && Input.GetMouseButton(0))
        {
            selist = new List<GameObject>();
            RaycastHit hitInfo = new RaycastHit();
            bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);
            if (hit && hitInfo.transform.gameObject.GetComponent<Unit>() != null)
            {
                selist.Add(hitInfo.transform.gameObject.GetComponent<Unit>().Select());
            }
        }
        if (selectmode && Input.GetMouseButtonUp(0))
        {
            selectmode = false;
            movemode = true;
        }
        if (movemode && Input.GetMouseButtonDown(0)){
            foreach (GameObject obj in selist)
            {
                RaycastHit hitInfo = new RaycastHit();
                bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);
                if (hit)
                {
                    obj.GetComponent<Unit>().MoveTo(hitInfo.transform.position.x, hitInfo.transform.position.z);
                }
            }
            movemode = false;
            selectmode = true;
        }
    }
}
