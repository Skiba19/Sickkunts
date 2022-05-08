using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    BuildManager buildManager;
    public TurretBlueprint standartTurret;
    public TurretBlueprint missleTurret;
    public TurretBlueprint laserTurret;
    void Start()
    {
        buildManager=BuildManager.instance;
    }
    public void SelectStandardTurret()
    {
        Debug.Log("Standard Turret Selected");
        buildManager.SelectTurretToBuild(standartTurret);
    }
    public void SelectMissleTurret()
    {
        Debug.Log("Missle Turret Selected");
        buildManager.SelectTurretToBuild(missleTurret);
    }
    public void SelectLaserTurret()
    {
       Debug.Log("Laser Turret Selected");
        buildManager.SelectTurretToBuild(laserTurret);
    }
}
