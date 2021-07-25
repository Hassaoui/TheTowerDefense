using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickyScript : MonoBehaviour
{
    public GameObject UI;

    private GameObject lastturret;

    BuildManager buildmanager;

    void Start()
    {
        buildmanager = BuildManager.instance;
    }

    void OnMouseDown()
    {
        UI.SetActive(false);
        lastturret = buildmanager.GetTargetTurret();
        if(lastturret!=null)
            lastturret.GetComponent<turret>().StopRange();
    }
}
