using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatSystem : MonoBehaviour
{
    public static StatSystem Instance { get; private set; }

    [SerializeField] private int money;
    [SerializeField] private int nuclearEnergy;
    [SerializeField] private int maxEnergy;
    [SerializeField] private int maxUnitCount;

    [Header("Text Fields")]
    [SerializeField] private TextMeshProUGUI moneyText;
    [SerializeField] private TextMeshProUGUI nuclearEnergyText;
    [SerializeField] private TextMeshProUGUI maxEnergyText;
    [SerializeField] private TextMeshProUGUI currentEnergyText;
    [SerializeField] private TextMeshProUGUI maxUnitText;
    [SerializeField] private TextMeshProUGUI currentUnitText;

    private int currentEnergy = 0;
    private int currentUnitCount = 0;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("There are more than one Stsat System");
        }
        Instance = this;
        print(gameObject.name);
    }

    private void Update()
    {
        moneyText.text = "$" + money.ToString();
        nuclearEnergyText.text = nuclearEnergy.ToString();
        maxEnergyText.text = maxEnergy.ToString();
        currentEnergyText.text = currentEnergy.ToString();
        maxUnitText.text = maxUnitCount.ToString();
        currentUnitText.text = currentUnitCount.ToString();
    }

    public void AddMoney(int amount)
    {
        money += amount;
    }

    public void SpendMoney(int amount)
    {
        money -= amount;
    }

    public int GetMoney()
    {
        return money;
    }

    public void AddNuclearEnergy(int amount)
    {
        nuclearEnergy += amount;
    }

    public void SpendNuclearEnergy(int amount)
    {
        nuclearEnergy -= amount;
    }

    public void AddEnergy(int amount)
    {
        currentEnergy += amount;
    }

    public void SpendEnergy(int amount)
    {
        currentEnergy -= amount;
    }


    public void AddUnit(int amount)
    {
        currentUnitCount += amount;
    }

    public void SpendUnit(int amount)
    {
        currentUnitCount -= amount;
    }

    public int GetUnit()
    {
        return currentUnitCount;
    }

    public int GetMaxUnit()
    {
        return maxUnitCount;
    }

    public bool EnoughEnergyToPlace(int buildingEnergyCost)
    {
        if (maxEnergy >= buildingEnergyCost + currentEnergy)
        {
            return true;
        }
        return false;
    }
    public bool EnoughNuclearEnergyToPlace(int buildingNuclearEnergyCost)
    {
        if (nuclearEnergy >= buildingNuclearEnergyCost)
        {
            return true;
        }
        return false;
    }

    public bool EnoughMoneyToPlace(int moneyCost)
    {
        if (money >= moneyCost)
        {
            return true;
        }
        return false;

    }
}
