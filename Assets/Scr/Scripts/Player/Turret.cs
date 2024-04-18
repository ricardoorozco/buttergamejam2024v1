using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public enum TurretType
    {
        MachineGun,
        MissileLauncher,
        LaserBeam
    }

    public TurretType turretType;
    public int cost;
}
