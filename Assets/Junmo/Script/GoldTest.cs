using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldTest : MonoBehaviour
{
    public GoldData GoldData;

    public void Awake()
    {
        GoldData.LoadGold();
    }
    void Start()
    {
        GoldData.Money = 20;
        Debug.Log("µ·: "+ GoldData.Money);
        Debug.Log("±¤¹°: " + GoldData.Mineral);
        Debug.Log("³ª¹«: " + GoldData.Wood);
        GoldData.SaveGold();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
