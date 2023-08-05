using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Test : MonoBehaviour
{
    public enum State
    {
        Warrior,
        Archer,
        Wizard,
        Thief
    }

    public StatusData characterStatus;
    public MaxStatusData max;
    public State state;
    private int RoleNum;

    public void Awake()
    {
        characterStatus.SaveCharacterStatus();
    }
    public void Start()
    {
        if (state == State.Warrior)
            RoleNum = 0;
        else if (state == State.Archer)
             RoleNum = 1;
        else if (state == State.Wizard)
            RoleNum = 2;
        else if (state == State.Thief)
            RoleNum = 3;
    }

    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject[] enemys = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject enemy in enemys)
            {
                enemy.GetComponent<MonsterTest>()?.OnDamage(characterStatus.statusList[RoleNum].ATK, RoleNum);
            }

            if (characterStatus.statusList.Count > 0)
            {
                if (characterStatus.statusList[RoleNum].LEVEL < max.MaxLevel)
                {
                    if (characterStatus.statusList[RoleNum].EXP == 10)
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
        characterStatus.statusList[RoleNum].LEVEL++;
        characterStatus.statusList[RoleNum].EXP = 0;
        StatusUP();
        Debug.Log("레벨업했습니다. 현재 LEVEL: " + characterStatus.statusList[RoleNum].LEVEL);
    }
    public void StatusUP() // StatusUP 함수
    {
        characterStatus.statusList[RoleNum].HP++;
        characterStatus.statusList[RoleNum].ATK++;
        characterStatus.statusList[RoleNum].DEF++;
        characterStatus.statusList[RoleNum].DEX++;
        Debug.Log("HP가 1 증가했습니다. 현재 HP: " + characterStatus.statusList[RoleNum].HP);
        Debug.Log("ATK가 1 증가했습니다. 현재 ATK: " + characterStatus.statusList[RoleNum].ATK);
        Debug.Log("DEF가 1 증가했습니다. 현재 DEF: " + characterStatus.statusList[RoleNum].DEF);
        Debug.Log("DEX가 1 증가했습니다. 현재 DEX: " + characterStatus.statusList[RoleNum].DEX);
    }
}
