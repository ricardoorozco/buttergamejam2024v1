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
        initial = transform.position;
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, target) < 0.1f)
        {
            goToTarget = false;
        }
        else if(Vector3.Distance(transform.position, initial) < 0.1f)
        {
            goToTarget = true;
        }

        if (goToTarget)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, speed);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, initial, speed);
        }
    }
}
