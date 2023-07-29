using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[CreateAssetMenu(fileName = "New Status Data", menuName = "Custom/Status Data")]
public class StatusData : ScriptableObject
{
    public List<status> statusList = new List<status>();

    [Serializable]
    public class status
    {
        public string Name;
        public int LEVEL;
        public int EXP;
        public int HP;
        public int ATK;
        public int DEF;
        public int DEX;

        public status(string name, int level, int exp, int hp, int atk, int def, int dex)
        {
            Name = name;
            LEVEL = level;
            EXP = exp;
            HP = hp;
            ATK = atk;
            DEF = def;
            DEX = dex;
        }
    }

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
