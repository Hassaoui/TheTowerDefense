using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class Node : MonoBehaviour
{
    private GameObject turret;
    public Text sellText;
    public GameObject shop;
    public GameObject sellbutton;
    BuildManager buildmanager;
    private GameObject lastturret;

    void Start()
    {
        buildmanager = BuildManager.instance;
    }
    void OnMouseDown()
    {
        if (BuildManager.instance.GetTurretToBuild() == null && turret == null)
        {
            lastturret = buildmanager.GetTargetTurret();
            if(lastturret != null)
                lastturret.GetComponent<turret>().StopRange();
            sellbutton.SetActive(false);
            return;
        }
            
        buildmanager.SetNode(this) ;

        if (turret != null)
        {
            if(buildmanager.GetTargetTurret() != null)
            {
                lastturret = buildmanager.GetTargetTurret();
                lastturret.GetComponent<turret>().StopRange();
            }
            buildmanager.SetTargetTurret(turret);
            turret.GetComponent<turret>().SetRange();
            sellText.text = "Sell turret for " + turret.GetComponent<turret>().GetCoutTurret()/2 + "$";
            sellbutton.SetActive(true);
            return;
        }

        if(turret == null)
        {
                
                GameObject turretToBuild = BuildManager.instance.GetTurretToBuild();
                turret = (GameObject)Instantiate(turretToBuild, transform.position, transform.rotation);
                buildmanager.SetTurretToBuild(null);

        }

        if (!buildmanager.canBuild())
            return;
    }

    public GameObject GetTurret()
    {
        return turret;
    }
}
