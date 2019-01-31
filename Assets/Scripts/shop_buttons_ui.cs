using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shop_buttons_ui : MonoBehaviour
{
    public player_inventory_values Customer;
    public UnityEngine.UI.Text[] buttonTexts;
    // Tax info
    public bool plant_tax;
    public bool fert_tax;

    string[] item_names = {"Plant 1","Plant 2","Plant 3","Natural Fertilizer","Artificial Fertilizer"};

    float tax = 0.6f;

    float[] plantValuesOriginal = { 50, 100, 250, 500, 1000 };
    float[] plantValues;

    void Start() {
      plantValues = new float[5];
    }

    void Update() {
      for(int i = 0; i < 5; i++) {
        plantValues[i] = plantValuesOriginal[i] + (plantValuesOriginal[i] * ((plant_tax && i < 3)||(fert_tax && i == 4) ? tax : 0));
        buttonTexts[i].text = item_names[i] + ": " + plantValues[i].ToString();
      }
    }

    public void ShopButtonPress(int targetPlant)
    {
        if (CanAffordPlant(targetPlant))                  // Can player afford Plant?
            BuyPlant(targetPlant);                        // Player buys Plant
    }

    private bool CanAffordPlant(int plantNumber)
    {
        float availableMoney = Customer.MoneyReserve;
        bool returnValue = (availableMoney >= plantValues[plantNumber]);
        return returnValue;
    }

    private void BuyPlant(int plantNumber)
    {
        Customer.MoneyReserve -= plantValues[plantNumber];
        Customer.AmountOfItems[plantNumber] += 1;
    }

}
