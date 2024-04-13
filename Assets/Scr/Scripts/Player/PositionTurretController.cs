using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionTurretController : MonoBehaviour
{
    [SerializeField]
    TurretsManager turretsManager;

    [SerializeField]
    private bool canPutTurret = true;

    public void PutTurret() {
        if (canPutTurret) {
            GameObject turret = turretsManager.GetTurret();
            if (turret)
            {
                GameObject turretIntance = Instantiate(turret, transform.position, transform.rotation);
                turretIntance.transform.parent = transform;
                turretIntance.transform.localScale = new Vector3(1, 1, 1);
                canPutTurret = false;
            }
        }
    }
}
