using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GoldTest : MonoBehaviour
{
    public GoldData GoldData;
    public TMP_Text Display;

    public void Awake()
    {
        //GoldData.LoadGold(); // ∞ÒµÂ µ•¿Ã≈Õ √ ±‚»≠µ 
    }
    void Start()
    {
        GoldData.Money = 20;
        GoldData.SaveGold();
    }

    // Update is called once per frame
    void Update()
    {
        Display.text =
            "Money: " + GoldData.Money + "\n" +
            "Mineral: " + GoldData.Mineral + "\n" +
            "Wood: " + GoldData.Wood;
    }
}
