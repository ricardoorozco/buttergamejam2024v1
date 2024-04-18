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

    public StageController stageController;

    [SerializeField]
    private bool isSupply = false;

    void Awake()
    {
        stageController = GameObject.Find("StageController").GetComponent<StageController>();
        if (isSupply) {
            target = GameObject.FindGameObjectWithTag("Player").GetComponent<StationManager>();
        }
    }

    public void Start()
    {
        if (isSupply)
        {
            LeanTween.alpha(this.gameObject, 0.1f, destroyDelay);
        }
        
        Destroy(this.gameObject, destroyDelay);
    }

    public void Update()
    {
        if (isAutoAimed && target) 
        {
            this.transform.LookAt(target.gameObject.transform);
        }

        if (!isSupply)
        {
            this.transform.Translate(Vector3.forward * bulletSpeed * Time.deltaTime);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (GameController.instance.isGameOver)
        {
            return;
        }

        if (isSupply && other.CompareTag(target.tag))
        {
            stageController.addSupply((int)bulletDamage);
            Destroy(this.gameObject);
        }
        else if (target && other.CompareTag(target.tag))
        {
            target.TakeDamage(bulletDamage);
            Destroy(this.gameObject);
        }
    }

    public void setAutoAimed(bool autoAimed) {
        isAutoAimed = autoAimed;
    }

    private void OnMouseOver()
    {
        if (isSupply && !GameController.instance.isGameOver) {
            LeanTween.move(this.gameObject, target.transform.position, 0.5f);
        }
    }
}
