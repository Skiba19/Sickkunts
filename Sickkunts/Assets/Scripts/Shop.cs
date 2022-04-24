using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    BuildManager buildManager;
    public TurretBlueprint standartTurret;
    void Start()
    {
        buildManager=BuildManager.instance;
    }
    public void SelectStandardTurret()
    {
        Debug.Log("Standard Turret Purchased");
        buildManager.SelectTurreToBuild(standartTurret);
    }
    public void SelectAnotherTurret()
    {
       //buildManager.SelectTurreToBuild();
    }
}
