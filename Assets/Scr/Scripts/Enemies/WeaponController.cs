using System.Collections;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class WeaponController : MonoBehaviour
{
    public StationManager target;

    [SerializeField]
    private BulletController bulletPrefab;

    [SerializeField]
    private Transform bulletSpawnPoint;

    [SerializeField]
    private float fireDelay = 1f;

    [SerializeField]
    private int bulletsPerShot = 1;

    [SerializeField]
    private float bulletsPerShotDelay;

    [SerializeField]
    private bool canFire = true;

    [SerializeField]
    private bool isEnemyWeapon;

    public void Awake()
    {
        bulletSpawnPoint = transform;
        if(isEnemyWeapon && !GameController.instance.isGameOver)
        {
            target = GameObject.FindGameObjectWithTag("Player").GetComponent<StationManager>();
        }
    }

    float currentDelay = 0f;

    void Start()
    {
        currentDelay = fireDelay;
    }

    public void Update()
    {
        if (canFire && !GameController.instance.isGameOver)
        {
            if (currentDelay > 0)
            {
                currentDelay -= Time.deltaTime;
            }
            else
            {
                fire();
            }
        }
    }

    public void fire()
    {
        currentDelay = fireDelay;

        StartCoroutine(FireCoroutine());
    }

    private IEnumerator FireCoroutine()
    {
        for (int i = 0; i < bulletsPerShot; i++)
        {
            if (!GameController.instance.isGameOver)
            { 
                BulletController bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
                bullet.target = target;
            }
            else
            {                 
                break;
            }
            yield return new WaitForSeconds(bulletsPerShotDelay);
        }
        yield return null;
    }
}
