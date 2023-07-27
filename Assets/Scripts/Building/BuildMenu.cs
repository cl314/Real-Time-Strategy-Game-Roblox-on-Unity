using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildMenu : MonoBehaviour
{
    [SerializeField]private BuildingDataSO buildingData;
    [SerializeField]private GameObject menuItem;
    void Start()
    {
        foreach (BuildingData data in buildingData.buildings)
        {

            GameObject spanedItem = Instantiate(menuItem, transform);
            BuildingMenuItem spawnedBuildingMenuItem = spanedItem.GetComponent<BuildingMenuItem>();
            spawnedBuildingMenuItem.nameText.text = data.name;
            spawnedBuildingMenuItem.nuclearText.text = data.nuclearEnergy.ToString();
            spawnedBuildingMenuItem.energyText.text = data.energy.ToString();
            spawnedBuildingMenuItem.priceText.text = data.price.ToString();
            spawnedBuildingMenuItem.SetBuildingIndex(data.buildingIndex);
        }
    }

    
}
