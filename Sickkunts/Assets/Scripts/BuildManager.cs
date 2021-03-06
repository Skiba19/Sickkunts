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
    public GameObject buildEffect;
    private TurretBlueprint turretToBuild;
    private Node selectedNode;
    public bool CanBuild{get{return turretToBuild!=null;}}
    public bool HasMoney{get{return PlayerStats.Money>=turretToBuild.cost;}}
    public NodeUI nodeUI;
    public void SelectNode(Node node)
    {
        if(selectedNode==node)
        {
            DeselectNode();
        }
        selectedNode=node;
        turretToBuild=null;

        nodeUI.SetTarget(node);
    }
    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild=turret;
        DeselectNode();
    }
    public void DeselectNode()
    {
        selectedNode=null;
        nodeUI.Hide();
    }
    public TurretBlueprint GetTurretToBuild()
    {
        return turretToBuild;
    }
}