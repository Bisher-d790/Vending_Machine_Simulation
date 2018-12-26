using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Controller : MonoBehaviour {

    [SerializeField] private Item[] items;
    [SerializeField] private Text selectedItemText;
    [SerializeField] private Text insertedMoneyText;
    [SerializeField] private Text logText;
    private double logTimer = 0.0f;
    // Money is in sens
    [SerializeField] private int insertedMoney = 0;
    private int selectedItem = 0;

    public void Start()
    {
        logText.text = "";
        insertedMoneyText.text = ((double)insertedMoney / 100).ToString();
        for(int i=0;i<=items.Length;i++)
        {
            items[i].setID(i);
        }
    }

    public void AddMoney(int insertedMoney)
    {
        this.insertedMoney += insertedMoney;
        insertedMoneyText.text = ((double)this.insertedMoney / 100).ToString();
    }

    public void SelectItem()
    {
        this.selectedItem = int.Parse(selectedItemText.text);
        if (selectedItem < 0 || selectedItem >= items.Length)
        {
            logText.text = "Please enter a valid number.";
            logTimer = 3.0f;
            return;
        }
        if (items[selectedItem].getPrice() <= insertedMoney)
        {
            AddMoney(-1 * items[selectedItem].SelectItem());
        }
        else
        {
            logText.text = "Not enough money!";
            logTimer = 3.0f;
        }
    }

    public void Update()
    {
        if (logTimer > 0)
        {
            logTimer -= Time.deltaTime;
            if (logTimer < 1)
            {
                logTimer = 0;
                logText.text = "";
            }
        }
    }

}
