using System.Collections;
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

    public void Fire()
    {
        if (canFire && !GameController.instance.isGameOver)
        {
            activate();
        }
        else
        {
            deactivate();
        }
    }

    public void Update()
    {
        Fire();
    }

    void FixedUpdate()
    {
        if (!laserLine.enabled || !canFire || GameController.instance.isGameOver) {
            deactivate();
            return; 
        }

        Ray ray = new Ray(transform.position, transform.forward);
        bool cast = Physics.Raycast(ray, out RaycastHit hit, maxLaserDistance);
        float zDistance = hit.distance;

        if (cast)
        {
            zDistance = hit.distance;
        }
        else
        {
            zDistance = maxLaserDistance;
        }


        laserLine.SetPosition(0, new Vector3(0,0,0));
        laserLine.SetPosition(1, new Vector3(0, 0, zDistance));
    }

    public void CanFireStatus(bool status)
    {
        canFire = status;
    }
}