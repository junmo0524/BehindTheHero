using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[CreateAssetMenu(fileName = "New Status Data", menuName = "Custom/Status Data")]
public class StatusData : ScriptableObject
{
    //public List<status> statusList = new List<status>();

    [SerializeField]
    public string Name;
    [SerializeField]
    public int LEVEL;
    [SerializeField]
    public int EXP;
    [SerializeField]
    public int HP;
    [SerializeField]
    public int ATK;
    [SerializeField]
    public int DEF;
    [SerializeField]
    public int DEX;

    // 데이터를 PlayerPrefs에 저장하는 메서드
    public void SaveCharacterStatus()
    {
        string jsonData = JsonUtility.ToJson(this);
        PlayerPrefs.SetString("CharacterStatusData", jsonData);
        PlayerPrefs.Save();
    }

    // PlayerPrefs로부터 데이터를 불러오는 메서드
    public void LoadCharacterStatus()
    {
        if (PlayerPrefs.HasKey("CharacterStatusData"))
        {
            string jsonData = PlayerPrefs.GetString("CharacterStatusData");
            JsonUtility.FromJsonOverwrite(jsonData, this);
        }
    }
}
