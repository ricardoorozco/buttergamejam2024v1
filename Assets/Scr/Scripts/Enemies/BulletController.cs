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

    public StationManager target;

    public void Start()
    {
        Destroy(this.gameObject, destroyDelay);
    }

    public void Update()
    {
        if (isAutoAimed && target) 
        {
            this.transform.LookAt(target.gameObject.transform);
        }
        
        this.transform.Translate(Vector3.forward * bulletSpeed * Time.deltaTime);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (target && other.CompareTag(target.tag))
        {
            target.TakeDamage(bulletDamage);
            Destroy(this.gameObject);
        }
    }

    public void setAutoAimed(bool autoAimed) {
        isAutoAimed = autoAimed;
    }
}
