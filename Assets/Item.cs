using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class Item : MonoBehaviour
{
    [SerializeField] private Text itemNumber;
    [SerializeField] private Text itemQuantity;
    [SerializeField] private Text itemPrice;
    private int ID = 0;
    [SerializeField] private int quantity = 10;
    // Money is in Sens
    [SerializeField] private int price = 100;

    public void Awake()
    {
        itemQuantity.text = quantity.ToString();
        itemPrice.text = ((double) price/100).ToString();
    }

    public int getNumber()
    {
        return ID;
    }

    public int getQuantity()
    {
        return quantity;
    }

    public int getPrice()
    {
        return price;
    }

    public void setID(int ID)
    {
        this.ID = ID;
        itemNumber.text = ID.ToString();
    }

    // removes 1 from the quantity of the item and returns the price of the item 
    public int SelectItem()
    {
        quantity--;
        itemQuantity.text = quantity.ToString();
        return price;
    }

}
