using UnityEngine;

public class UpSystem : MonoBehaviour
{
    public float speed;

    public void Update()
    {
        this.Up();
    }

    void Up()
    {
        this.transform.Translate(Vector3.up * Time.deltaTime * this.speed);
    }

    public void SetSpeed(float newSpeed)
    {
        this.speed = newSpeed;
    }

    public void AddSpeed(float speed)
    {
        this.speed += speed;
    }
}
