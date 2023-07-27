using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingSystem : MonoBehaviour
{
    public static BuildingSystem Instance { get; private set; } 

    [SerializeField] private LayerMask placingLayer;
    [SerializeField] private BuildingDataSO buildingData;

    private bool buildIsActive = false;
    private GameObject placingGameObject;
    private bool canBuild;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("There are more than one Stsat System");
        }
        Instance = this;
        print(gameObject.name);
    }
    void Start()
    {
        
    }

    void Update()
    {

        if (buildIsActive) 
        {
            CheckBuildingPossibility();
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, float.MaxValue, placingLayer))
            {
                if (hit.collider.TryGetComponent(out FarmFoundation farmFoundation))
                {
                    placingGameObject.transform.position = hit.transform.position;
                }
                else
                {
                    placingGameObject.transform.position = hit.point;
                }
               
                if (Input.GetMouseButtonDown(0) && buildIsActive && canBuild)
                {
                    /*Instantiate(placingGameObject, hit.point, Quaternion.identity);*/
                    buildIsActive = false;
                }
            }
        }
        
       

        

        
    }

    private void CheckBuildingPossibility()
    {
        
    }

    public void TryToBuyBuilding(int buildingIndex)
    {
        BuildingData currentBuildingData = buildingData.buildings[buildingIndex];

        if (StatSystem.Instance.EnoughMoneyToPlace(currentBuildingData.price) &&
            StatSystem.Instance.EnoughEnergyToPlace(currentBuildingData.energy) &&
            StatSystem.Instance.EnoughNuclearEnergyToPlace(currentBuildingData.nuclearEnergy))
        {
            placingGameObject = Instantiate(currentBuildingData.buildingPrefab);
            buildIsActive = true;
        }
    }
}
