

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
    private bool isAutoAimed;

    [SerializeField]
    private bool isEnemyWeapon;

    [SerializeField]
    private AudioSource fireSource;

    [SerializeField]
    private AudioClip fireSound;

    public void Awake()
    {
        bulletSpawnPoint = transform;
        if (isEnemyWeapon && !GameController.instance.isGameOver)
        {
            target = GameObject.FindGameObjectWithTag("Player").GetComponent<StationManager>();
            fireSource = GameObject.Find("EnemyFxSource").GetComponent<AudioSource>();
        }
        else
        {
            fireSource = GameObject.Find("TurretFxSource").GetComponent<AudioSource>();
        }
        if (fireSound)
        {
            fireSource.clip = fireSound;
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
                bool canToSound = false;
                if (isEnemyWeapon && GameController.instance.totalEnemyWeaponsSounds < GameController.instance.maxEnemyWeaponsSounds)
                {
                    GameController.instance.totalEnemyWeaponsSounds++;
                    canToSound = true;
                    fireSource.PlayOneShot(fireSound);
                }
                else if(!isEnemyWeapon && GameController.instance.totalTurretWeaponsSounds < GameController.instance.maxTurretWeaponsSounds)
                {
                    GameController.instance.totalTurretWeaponsSounds++;
                    canToSound = true;
                    
                }
                if (canToSound) 
                {
                    fireSource.PlayOneShot(fireSound);
                }
                BulletController bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
                bullet.target = target;
                bullet.setAutoAimed(isAutoAimed);

                if (isEnemyWeapon && canToSound)
                {
                    LeanTween.delayedCall(0.2f, () =>
                    {
                        GameController.instance.totalEnemyWeaponsSounds--;
                    });
                }
                else if (!isEnemyWeapon && canToSound)
                {
                    LeanTween.delayedCall(0.2f, () =>
                    {
                        GameController.instance.totalTurretWeaponsSounds--;
                    });
                }
            }
            else
            {
                break;
            }
            yield return new WaitForSeconds(bulletsPerShotDelay);
        }
        yield return null;
    }

    public void CanFireStatus(bool status)
    {
        canFire = status;
    }
}
