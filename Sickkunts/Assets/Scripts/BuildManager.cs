using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;
    void Awake()
    {
        if(instance!=null)
        {
            Debug.LogError("More than one BuildManager in scene!");
            return;
        }
        instance=this;
    }
    public GameObject standardTurretPrefab;
    public GameObject missleTurretPrefab;
    public GameObject buildEffect;
    private TurretBlueprint turretToBuild;
    public bool CanBuild{get{return turretToBuild!=null;}}
    public bool HasMoney{get{return PlayerStats.Money>=turretToBuild.cost;}}
    public void BuildTurretOn(Node node)
    {
        if(PlayerStats.Money<turretToBuild.cost)
        {
            Debug.Log("Not enough gold to build that!");
            return;
        }
        PlayerStats.Money-=turretToBuild.cost;
        GameObject turret=(GameObject) Instantiate(turretToBuild.prefab, node.getBuildPosition(), Quaternion.identity);
        GameObject effect=(GameObject) Instantiate(buildEffect, node.getBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);
        node.turret=turret;
    }
    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild=turret;
    }

}