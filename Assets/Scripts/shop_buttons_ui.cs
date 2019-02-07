using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shop_buttons_ui : MonoBehaviour
{
    public player_inventory_values Customer;
    public UnityEngine.UI.Text[] buttonTexts;
    public life_event_manager_scr LE_Control;
    // Tax info
    public bool plant_tax;
    public bool fert_tax;
    public bool shop_sale;

    string[] item_names = {"Plant 1","Plant 2","Plant 3","Natural Fertilizer","Artificial Fertilizer"};

    float tax = 1.6f;
    float sale = 0.6f;

    float[] plantValuesOriginal = { 50, 100, 250, 500, 1000 };
    float[] plantValues;

    void Start() {
      plantValues = new float[5];
    }

    void Update() {
      if(LE_Control.current_event == life_event_manager_scr.RobotEvents.A_FERT_PRICE_UP) {
        fert_tax = true;
      }
      else {
        fert_tax = false;
      }
      if(LE_Control.current_event == life_event_manager_scr.RobotEvents.TAX && LE_Control.tax == life_event_manager_scr.TaxType.ALL_SEEDS_MORE) {
        plant_tax = true;
      }
      else {
        plant_tax = false;
      }
      if(LE_Control.current_event == life_event_manager_scr.RobotEvents.SHOP_SALE) {
        shop_sale = true;
      }
      else {
        shop_sale = false;
      }
      for(int i = 0; i < 5; i++) {
        plantValues[i] = plantValuesOriginal[i] * ((plant_tax && i < 3)||(fert_tax && i == 4) ? tax : 1) * ((shop_sale) ? sale : 1);
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
