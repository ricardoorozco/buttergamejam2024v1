using System.Collections;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
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

    public void Awake()
    {
        bulletSpawnPoint = transform;
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
                Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
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
