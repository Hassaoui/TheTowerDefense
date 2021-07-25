using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class ShopSlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [Header("ToolTip")]
    [SerializeField] ItemToolTip tooltip;
    public string nomTurret;
    public int CoutTurret;
    public string Description;
    [Space]
    public GameObject turret;
    [Space]
    public GameObject broketext;
    public GameObject sellButton;

    //private
    private BuildManager buildmanager;
    private string noMoney = "Need More CASH!";


    void Start()
    {
        buildmanager = BuildManager.instance;
    }

    public void OnClick()
    {
        sellButton.SetActive(false);
        if (buildmanager.GetTurretToBuild() != null)
            return;

        
        if (turret.GetComponent<turret>().GetCoutTurret() <= PlayerStat.Money)
        {
            buildmanager.SetTurretToBuild(turret);
            PlayerStat.Money -= turret.GetComponent<turret>().GetCoutTurret();
        }
        else
        {
            StartCoroutine(Broke(1));
           
        }
    }

    IEnumerator Broke (float delay)
    {
        broketext.SetActive(true);
        yield return new WaitForSeconds(delay);
        broketext.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        tooltip.ShowTooltipItem(nomTurret, CoutTurret, Description);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        tooltip.HideToolTip();
    }
    
}
