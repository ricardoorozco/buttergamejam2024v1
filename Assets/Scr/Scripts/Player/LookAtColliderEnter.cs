using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtColliderEnter : MonoBehaviour
{
    [SerializeField]
    string tagTarget;
    [SerializeField]
    Transform target;
    [SerializeField]
    public float maxAngle = 90.0f;
    private Quaternion initialRotation;
    List<WeaponController> weaponControllers = new();
    List<LaserWeaponController> laserControllers = new();
    [SerializeField]
    private bool hasChildren = false;

    void Awake()
    {
        checkChildren();
        initialRotation = transform.rotation;
    }

    void Update()
    {
        if (!hasChildren) {
            checkChildren();
        }

        if (GameController.instance.isGameOver)
        {
            Destroy(this.gameObject);
        }

        if (target)
        {
            float angleDifference = Quaternion.Angle(initialRotation, transform.rotation);
            if (Mathf.Abs(angleDifference - maxAngle) < 1.0f)
            {
                CanFire(false);
                target = null;
                transform.rotation = initialRotation;
            }
            else
            {
                transform.LookAt(target);
            }
        }
        else
        {
            CanFire(false);
            transform.rotation = initialRotation;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!target && other.CompareTag(tagTarget))
        {
            target = other.transform;
            CanFire(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform == target)
        {
            CanFire(false);
            target = null;
        }
    }

    public void CanFire(bool canFire)
    {
        foreach (WeaponController weapon in weaponControllers)
        {
            if (canFire)
            {
                Debug.Log(target);
                weapon.target = target.GetComponent<StationManager>();
                Debug.Log(weapon.target);
            }
            else
            {
                weapon.target = null;
            }
            weapon.CanFireStatus(canFire);
        }

        foreach (LaserWeaponController laser in laserControllers)
        {
            if (canFire)
            {
                laser.target = target.GetComponent<StationManager>();
            }
            else
            {
                laser.target = null;
            }
            laser.CanFireStatus(canFire);
        }
    }

    void checkChildren()
    {
        if (transform.childCount > 0)
        {
            hasChildren = true;

            foreach (Transform child in transform.GetChild(0))
            {
                Debug.Log("child.tag: " + child.tag);
                if (child.CompareTag("TurretWeapon"))
                {
                    WeaponController weaponController = child.GetComponent<WeaponController>();
                    if (weaponController)
                    {
                        weaponControllers.Add(weaponController);
                    }
                    else
                    {
                        LaserWeaponController laserWeaponController = child.GetComponent<LaserWeaponController>();
                        if (laserWeaponController)
                        {
                            laserControllers.Add(laserWeaponController);
                        }
                    }
                }
            }
        }
    }
}
