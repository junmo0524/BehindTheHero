using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Test : MonoBehaviour
{
    public StatusData characterStatus;
    public MaxStatusData max;

    public void Awake()
    {
        characterStatus.SaveCharacterStatus();
    }
    public void Start()
    {
        tag = characterStatus.statusList[0].Name;
    }

    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (characterStatus.statusList.Count > 0)
            {
                if (characterStatus.statusList[0].LEVEL < max.MaxLevel)
                {
                    characterStatus.statusList[0].EXP++;
                    Debug.Log("현재 EXP: " + characterStatus.statusList[0].EXP);
                    if (characterStatus.statusList[0].EXP == 10)
                    {
                        LevelUP();
                    }
                }
            }
            else
            {
                Debug.Log("캐릭터 데이터가 없습니다.");
            }
            // 변경된 상태 데이터를 PlayerPrefs에 저장합니다.
            characterStatus.SaveCharacterStatus();
        }
    }

    public void LevelUP() // LevelUP 함수
    {
        characterStatus.statusList[0].LEVEL++;
        characterStatus.statusList[0].EXP = 0;
        StatusUP();
        Debug.Log("레벨업했습니다. 현재 LEVEL: " + characterStatus.statusList[0].LEVEL);
    }
    public void StatusUP() // StatusUP 함수
    {
        characterStatus.statusList[0].HP++;
        characterStatus.statusList[0].ATK++;
        characterStatus.statusList[0].DEF++;
        characterStatus.statusList[0].DEX++;
        Debug.Log("HP가 1 증가했습니다. 현재 HP: " + characterStatus.statusList[0].HP);
        Debug.Log("ATK가 1 증가했습니다. 현재 ATK: " + characterStatus.statusList[0].ATK);
        Debug.Log("DEF가 1 증가했습니다. 현재 DEF: " + characterStatus.statusList[0].DEF);
        Debug.Log("DEX가 1 증가했습니다. 현재 DEX: " + characterStatus.statusList[0].DEX);
    }
}
