using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="BuildingData", menuName ="Building/BuildingData")]
public class BuildingDataSO : ScriptableObject
{
    public List<BuildingData> buildings = new List<BuildingData>();
}

[System.Serializable]
public class BuildingData
{
    public string name;
    public string description;
    public int price;
    public int sellPrice;
    public int energy;
    public int nuclearEnergy;
    public int buildingIndex;
    public GameObject buildingPrefab;
}