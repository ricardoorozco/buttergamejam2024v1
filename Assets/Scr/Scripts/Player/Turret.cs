using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Turret", menuName = "Turret")]
public class Turret : ScriptableObject
{
    public enum TurretType
    {
        MachineGun,
        MissileLauncher,
        LaserBeam
    }

    public TurretType turretType;
    public GameObject turretPrefab;
    public int cost;
}
