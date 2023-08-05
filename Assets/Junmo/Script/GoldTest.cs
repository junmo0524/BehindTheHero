using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldTest : MonoBehaviour
{
    public GoldData GoldData;

    public void Awake()
    {
        //GoldData.LoadGold(); // ∞ÒµÂ µ•¿Ã≈Õ √ ±‚»≠µ 
    }
    void Start()
    {
        GoldData.Money = 20;
        Debug.Log("µ∑: "+ GoldData.Money);
        Debug.Log("±§π∞: " + GoldData.Mineral);
        Debug.Log("≥™π´: " + GoldData.Wood);
        GoldData.SaveGold();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
