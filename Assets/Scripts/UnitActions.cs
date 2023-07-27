using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class UnitActions : MonoBehaviour
{
    public static UnitActions Instance { get; private set; }

    private Troop selectedUnit;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("There are more than one UnitAtions");
        }
        Instance = this;
    }
  

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Troop selectedTroop = TryGetSelectedTroop();
            if (selectedTroop != null)
            {
                selectedUnit = selectedTroop;
            }
        }

        /*        if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    Troop selectedTroop = TryGetSelectedTroop();
                    if (selectedTroop != null)
                    {
                        selectedUnit = selectedTroop;
                        selectionCheck.SetActive(true);
                    }          
                }
                else if (Input.GetKeyDown(KeyCode.Q))
                {
                    selectedUnit = null;
                    selectionCheck.SetActive(false);
                }

                if (selectedUnit != null)
                {
                    selectionCheck.transform.position = selectedUnit.transform.position - new Vector3(0, 0.17f, 0);
                }*/

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if(hit.collider.TryGetComponent(out WalkableZone walkableZone))
            {
                if (Input.GetKeyDown(KeyCode.Mouse0) && selectedUnit != null)
                {
                    selectedUnit.Move(hit.point);
                }                
            }
            
        }
    }

    public Troop GetSelectedUnit()
    {
        return selectedUnit;
    }

    private Troop TryGetSelectedTroop()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
                if (hit.collider.TryGetComponent(out Troop troop))
                {
                    return troop;
                }
        }
        return null;
       
    }

   
}
