using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Selectable
{
    GameObject Select();
    void Deselect();
    bool isSelectable();
}

public interface Moveable
{
    void Move();
    void MoveTo(float x, float z);
    bool isMoveable();
}
