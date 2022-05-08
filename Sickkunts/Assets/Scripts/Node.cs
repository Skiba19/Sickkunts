using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Vector3 positionOffset;
    [HideInInspector]
    public GameObject turret;
    [HideInInspector]
    public TurretBlueprint turretBlueprint;
    [HideInInspector]
    public bool isUpgraded=false;
    private Renderer rend;
    private Color startColor;
    BuildManager buildManager;
    void Start()
    {
        rend=GetComponent<Renderer>();
        startColor=rend.material.color;
        buildManager=BuildManager.instance;
    }
    public Vector3 getBuildPosition()
    {
        return transform.position+positionOffset;
    }
    void OnMouseDown()
    {
        if(EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if(turret!=null)
        {
            buildManager.SelectNode(this);
            return;
        }
        if(!buildManager.CanBuild)
        {
            return;
        }
        BuildTurret(buildManager.GetTurretToBuild());
    }
    void BuildTurret(TurretBlueprint blueprint)
    {
        if(PlayerStats.Money<blueprint.cost)
        {
            Debug.Log("Not enough gold to build that!");
            return;
        }
        PlayerStats.Money-=blueprint.cost;
        GameObject _turret=(GameObject) Instantiate(blueprint.prefab, getBuildPosition(), Quaternion.identity);
        turret=_turret;
        turretBlueprint=blueprint;
        GameObject effect=(GameObject) Instantiate(buildManager.buildEffect, getBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);
        
    }
    public void UpgradeTurret()
    {
        if(PlayerStats.Money<turretBlueprint.upgradeCost)
        {
            Debug.Log("Not enough gold to build that!");
            return;
        }
        PlayerStats.Money-=turretBlueprint.upgradeCost;
        Destroy(turret);
        GameObject _turret=(GameObject) Instantiate(turretBlueprint.upgradedPrefab, getBuildPosition(), Quaternion.identity);
        GameObject effect=(GameObject) Instantiate(buildManager.buildEffect, getBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);
        isUpgraded=true;
        turret=_turret;
    }
    void OnMouseEnter()
    {
        if(EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        if(!buildManager.CanBuild)
        {
            return;
        }
        if(buildManager.HasMoney)
        {
            rend.material.color=hoverColor;
        }
        else
        {
            rend.material.color=Color.red;
        }
        
    }
    void OnMouseExit()
    {
        rend.material.color=startColor;
    }
}
