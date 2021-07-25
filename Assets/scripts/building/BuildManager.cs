using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    private Node selectedNode;

    public List<GameObject> turrets = new List<GameObject>();

    private GameObject LastTargetedTurret = null;

    private GameObject turretToBuild;
    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        turretToBuild = null;
    }

    public void SetNode(Node node)
    {
        selectedNode = node;
    }

    public Node GetNode()
    {
        return selectedNode;
    }

    public void SetTurretToBuild(GameObject turretabuild)
    {
        turretToBuild = turretabuild;
    }

    public GameObject GetTurretToBuild()
    {
        return turretToBuild;
    }

    public List<GameObject> GetListTurret()
    {
        return turrets;
    }

    public bool canBuild()
    {
        if(turretToBuild == null)
        {
            return false;
        }
        return true;
    }

    public void SetTargetTurret(GameObject I)
    {
        LastTargetedTurret = I;
    }

    public GameObject GetTargetTurret()
    {
        return LastTargetedTurret;
    }
}
