using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpSystem : MonoBehaviour
{
    public float speed;

    public void Update()
    {
        Up();
    }

    void Up()
    {
        transform.Translate(Vector3.up * Time.deltaTime * speed);
    }

    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
    }
}
