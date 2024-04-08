using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField]
    private float destroyDelay = 5f;

    [SerializeField]
    private float bulletSpeed = 10f;

    [SerializeField]
    private float bulletDamage = 1f;

    [SerializeField]
    private bool isAutoAimed = false;

    [SerializeField]
    private Transform target;

    public void Start()
    {
        Destroy(this.gameObject, destroyDelay);
    }

    public void Update()
    {
        if (isAutoAimed) 
        {
            this.transform.LookAt(target);
        }
        
        this.transform.Translate(Vector3.forward * bulletSpeed * Time.deltaTime);
    }
}
