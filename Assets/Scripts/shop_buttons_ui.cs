using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shop_buttons_ui : MonoBehaviour
{
    public player_inventory_values Customer;
    int[] plantValues = { 50, 100, 250 };

    public void ShopButtonPress(int targetPlant)
    {
        Debug.Log("Button pressed!");
        if (CanAffordPlant(targetPlant))                  // Can player afford Plant?
            BuyPlant(targetPlant);                        // Player buys Plant
    }

    private bool CanAffordPlant(int plantNumber)
    {
        int availableMoney = Customer.MoneyReserve;
        bool returnValue = (availableMoney >= plantValues[plantNumber]);
        return returnValue;
    }

    private void BuyPlant(int plantNumber)
    {
        Customer.MoneyReserve -= plantValues[plantNumber];
        Customer.AmountOfPlants[plantNumber] += 1;
    }

}