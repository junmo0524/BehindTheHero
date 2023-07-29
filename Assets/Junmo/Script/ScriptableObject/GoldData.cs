using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Gold Data", menuName = "Custom/Gold Data", order = int.MaxValue)]
public class GoldData : ScriptableObject
{
    [SerializeField]
    public int Money;
    [SerializeField]
    public int Mineral;
    [SerializeField]
    public int Wood;

    public void SaveGold()
    {
        string jsonData = JsonUtility.ToJson(this);
        PlayerPrefs.SetString("GoldData", jsonData);
        PlayerPrefs.Save();
    }

    // PlayerPrefs로부터 데이터를 불러오는 메서드
    public void LoadGold()
    {
        if (PlayerPrefs.HasKey("GoldData"))
        {
            string jsonData = PlayerPrefs.GetString("GoldData");
            JsonUtility.FromJsonOverwrite(jsonData, this);
        }
    }
}
