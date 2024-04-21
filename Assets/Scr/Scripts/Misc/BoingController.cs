using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoingController : MonoBehaviour
{
    [SerializeField]
    private Vector3 target;
    [SerializeField]
    private Vector3 initial;

    [SerializeField]
    private bool goToTarget = false;

    [SerializeField]
    private float speed;

    void Awake()
    {
        initial = transform.localPosition;
    }

    void Update()
    {
        if (Vector3.Distance(transform.localPosition, target) < 0.01f)
        {
            goToTarget = false;
        }
        else if(Vector3.Distance(transform.localPosition, initial) < 0.01f)
        {
            goToTarget = true;
        }

        if (goToTarget)
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, target, speed);
        }
        else
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, initial, speed);
        }
    }
}
