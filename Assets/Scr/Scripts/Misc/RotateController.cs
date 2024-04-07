using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateController : MonoBehaviour
{
    [SerializeField]
    private float speed = 60;
    [SerializeField]
    private bool positive = true;
    [SerializeField]
    private bool right;
    [SerializeField]
    private bool up;
    [SerializeField]
    private bool foward;

    public void Start()
    {
        Vector3 rotationAxis;

        if (right)
        {
            rotationAxis = Vector3.right;
        }
        else if (up)
        {
            rotationAxis = Vector3.up;
        }
        else if (foward)
        {
            rotationAxis = Vector3.forward;
        }
        else
        {
            rotationAxis = Vector3.up;
        }

        LeanTween.rotateAroundLocal(gameObject, rotationAxis, 360 * (positive ? +1 : -1), speed).setLoopClamp();
    }
}
