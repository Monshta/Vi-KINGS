using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour,Selectable, Moveable
{
    bool selected = false;
    bool moving = false;
    Vector3 toLocation;
    public float movespeed = 0.1f;

    public GameObject Select()
    {
        this.selected = true;
        return this.gameObject;
    }
    public void Deselect()
    {
        this.selected = false;
    }

    public bool isSelectable()
    {
        return true;
    }

    public void Move()
    {
        if (this.toLocation.x > gameObject.transform.position.x)
            gameObject.transform.position += new Vector3(movespeed,0, 0);
        if (this.toLocation.z > gameObject.transform.position.z)
            gameObject.transform.position += new Vector3(0, 0, movespeed);
        if (this.toLocation.x < gameObject.transform.position.x)
            gameObject.transform.position += new Vector3(-movespeed, 0, 0);
        if (this.toLocation.z < gameObject.transform.position.z)
            gameObject.transform.position += new Vector3(0, 0, -movespeed);
    }
    public void MoveTo(float x, float z)
    {
        this.moving = true;
        this.toLocation = new Vector3(x, 0, z);
    }
    public bool isMoveable()
    {
        return true;
    }
    void Update()
    {
        if (this.moving)
        {
            this.Move();
            if (this.toLocation == gameObject.transform.position)
                moving = false;
        }
    }

}

