using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPice : MonoBehaviour
{
    public bool moveNow = false;
    public int numberOfStepsToMove;
    public PathObjectParent pathParent;

    private void Awake()
    {
        pathParent = FindObjectOfType<PathObjectParent>();
    }
}
