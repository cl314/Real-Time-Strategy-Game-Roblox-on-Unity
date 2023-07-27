using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Troop : MonoBehaviour
{
    private NavMeshAgent agent;

    [SerializeField] private GameObject selectedVisual;
    [SerializeField] private GameObject rangeVisual;

    [SerializeField] private float range;


    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        selectedVisual.SetActive(false);
        rangeVisual.transform.localScale *= range;
    }

    public void Move(Vector3 target)
    {
        agent.SetDestination(target);
    }

    private void Update()
    {
        if (UnitActions.Instance.GetSelectedUnit() == this) selectedVisual.SetActive(true);
        else selectedVisual.SetActive(false);
        
    }
}
