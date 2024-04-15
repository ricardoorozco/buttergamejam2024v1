using System.Collections;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class LaserWeaponController : MonoBehaviour
{
    public StationManager target;

    [SerializeField]
    private LineRenderer laserLine;

    [SerializeField]
    private float maxLaserDistance;

    [SerializeField]
    private bool canFire = true;

    [SerializeField]
    private bool isEnemyWeapon;

    [SerializeField]
    private float damage = 10f;

    [SerializeField]
    private LayerMask targetLayer;

    public void Awake()
    {
        if (isEnemyWeapon && !GameController.instance.isGameOver)
        {
            target = GameObject.FindGameObjectWithTag("Player").GetComponent<StationManager>();
        }
    }

    public void activate()
    {
        laserLine.enabled = true;
    }

    public void deactivate()
    {
        laserLine.enabled = false;
    }

    public void Update()
    {
        if (canFire && !GameController.instance.isGameOver)
        {
            activate();
        }
        else
        {
            deactivate();
            return;
        }

        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit, maxLaserDistance, targetLayer))
        {
            laserLine.SetPosition(0, transform.position);
            laserLine.SetPosition(1, hit.point);
            target.TakeDamage(damage);
        }
    }

    public void CanFireStatus(bool status)
    {
        canFire = status;
    }
}