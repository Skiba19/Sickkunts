using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    BuildManager buildManager;
    public TurretBlueprint standartTurret;
    public TurretBlueprint missleTurret;
    void Start()
    {
        buildManager=BuildManager.instance;
    }
    public void SelectStandardTurret()
    {
        Debug.Log("Standard Turret Purchased");
        buildManager.SelectTurretToBuild(standartTurret);
    }
    public void SelectMissleTurret()
    {
        Debug.Log("Missle Turret Purchased");
        buildManager.SelectTurretToBuild(missleTurret);
    }
    public void SelectAnotherTurret()
    {
       //buildManager.SelectTurreToBuild();
    }
}
