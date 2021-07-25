using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemToolTip : MonoBehaviour
{
    [SerializeField] Text nomTurret;
    [SerializeField] Text coutTurret;
    [SerializeField] Text description;

    public void ShowTooltipItem(string _nomTurret, int _coutTurret, string _description)
    {
        nomTurret.text = _nomTurret;
        coutTurret.text = _coutTurret + " $";
        description.text = _description;
        gameObject.SetActive(true);
    }

    public void HideToolTip()
    {
        gameObject.SetActive(false);
    }


}
