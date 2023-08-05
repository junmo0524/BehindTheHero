using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using TMPro;
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
    public TMP_Text DisplayStatus;
    public TMP_Text DisplayEXP;
    public State state;
    private int RoleNum;

    private int CurrHp;

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

        CurrHp = characterStatus.HP;
    }

    public void Update()
    {
        DisplayStatus.text =
             characterStatus.Name + "\n" +
           "HP: " + CurrHp + "/" + characterStatus.HP + "\n" +
           "ATK: " + characterStatus.ATK + "\n" +
           "DEF: " + characterStatus.DEF + "\n" +
           "DEX: " + characterStatus.DEX;
        DisplayEXP.text =
            "LEVEL: " + characterStatus.LEVEL + "\n" +
            "EXP: " + characterStatus.EXP + "/" + 10;

        if (Input.GetMouseButtonDown(0))
        {
            //Attack();
        }
        // 변경된 상태 데이터를 PlayerPrefs에 저장합니다.
        characterStatus.SaveCharacterStatus();
    }

    public void Attack() // Attack 함수
    {
        Debug.Log(characterStatus.name + " 의 차례");
        GameObject[] enemys = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemys)
        {
            enemy.GetComponent<MonsterTest>()?.OnDamage(characterStatus.ATK, RoleNum);
            LevelUP();
        }
    }

    public void OnDamage(int ATK)
    {
        CurrHp = CurrHp - ATK;
        Debug.Log(ATK + "만큼의 피해를 입었다");
        if (CurrHp <= 0)
        {
            Debug.Log(characterStatus.name + "이 쓰러졌습니다");
            CurrHp = 0;
            Invoke("Die", 0.2f);
        }
    }


    public void LevelUP() // LevelUP 함수
    {
        if (characterStatus.LEVEL < max.MaxLevel)
        {
            if (characterStatus.EXP == 10)
            {
                characterStatus.LEVEL++;
                characterStatus.EXP = 0;
                StatusUP();
                Debug.Log("레벨업했습니다. 현재 LEVEL: " + characterStatus.LEVEL);
            }
        }
    }
    public void StatusUP() // StatusUP 함수
    {
        characterStatus.HP++;
        characterStatus.ATK++;
        characterStatus.DEF++;
        characterStatus.DEX++;
        Debug.Log("HP가 1 증가했습니다. 현재 HP: " + characterStatus.HP);
        Debug.Log("ATK가 1 증가했습니다. 현재 ATK: " + characterStatus.ATK);
        Debug.Log("DEF가 1 증가했습니다. 현재 DEF: " + characterStatus.DEF);
        Debug.Log("DEX가 1 증가했습니다. 현재 DEX: " + characterStatus.DEX);
    }

    public void Die()
    {
        gameObject.SetActive(false);
    }
}
