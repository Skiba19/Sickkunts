using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NodeUI : MonoBehaviour
{
    public GameObject ui;
    private Node target;
    public Text uprageCost;
    public Button uprageButton;
    public void SetTarget(Node _target)
    {
        target=_target;
        transform.position=target.getBuildPosition();
        if(!target.isUpgraded)
        {
            uprageCost.text="$"+target.turretBlueprint.upgradeCost;
            uprageButton.interactable=true;
        }
        else
        {
            uprageCost.text="Maxed out!";
            uprageButton.interactable=false;
        }
       

        ui.SetActive(true);
    }
    public void Hide()
    {
        ui.SetActive(false);
    }
    public void Upgrade()
    {
        target.UpgradeTurret();
        BuildManager.instance.DeselectNode();
    }
}
