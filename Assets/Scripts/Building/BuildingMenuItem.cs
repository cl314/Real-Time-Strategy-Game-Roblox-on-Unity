using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using JetBrains.Annotations;

public class BuildingMenuItem : MonoBehaviour
{
    public TextMeshProUGUI nameText; 
    public TextMeshProUGUI nuclearText; 
    public TextMeshProUGUI energyText; 
    public TextMeshProUGUI priceText;

    private int buildingIndex;

    public void BuyBuilding()
    {
        BuildingSystem.Instance.TryToBuyBuilding(buildingIndex);
        print(buildingIndex);
    }

    public void SetBuildingIndex(int index)
    {
        buildingIndex = index;
    }
}
