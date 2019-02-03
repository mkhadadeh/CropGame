using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_inventory_values : MonoBehaviour {

    public float MoneyReserve = 1000;
    public int[] AmountOfItems = { 0, 0, 0, 0, 0 }; // First three indices are plants, fourth and fifth indices are fertilizers

    void Update() {
      controller_scr.money = (int)MoneyReserve;
    }
}
