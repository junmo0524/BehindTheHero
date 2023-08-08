using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Xml.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Test : MonoBehaviour
{
    public enum State
    {
        Warrior,
        Healer,
        Wizard,
        Thief
    }

    public StatusData characterStatus;
    public MaxStatusData max;
    public TMP_Text DisplayStatus;
    public TMP_Text DisplayEXP;
    public State state;

    private int HP;
    private int CurrHp;
    private int ATK;
    private int DEF;
    private int DEX;

    public void Awake()
    {
        characterStatus.SaveCharacterStatus();
    }
    public void Start()
    {
        HP = characterStatus.HP;
        CurrHp = characterStatus.HP;
        ATK = characterStatus.ATK;
        DEF = characterStatus.DEF;
        DEX = characterStatus.DEX;
        if (state == State.Warrior)
        {
            characterStatus.Name = "Warrior";
            DEF += 2;
        }
        else if (state == State.Healer)
        {
            characterStatus.Name = "Healer";
            HP += 2;
            CurrHp += 2;
        }
        else if (state == State.Wizard)
        {
            characterStatus.Name = "Wizard";
            ATK += 2;
        }
        else if (state == State.Thief)
        {
            characterStatus.Name = "Thief";
            //DEX += 2;
        }
    }

    public void Update()
    {
        //화면에 스탯창
        DisplayStatus.text =
             characterStatus.Name + "\n" +
           "HP: " + CurrHp + "/" + HP + "\n" +
           "ATK: " + ATK + "\n" +
           "DEF: " + DEF + "\n" +
           "DEX: " + DEX;
        DisplayEXP.text =
            "LEVEL: " + characterStatus.LEVEL + "\n" +
            "EXP: " + characterStatus.EXP + "/" + 10;

        // 변경된 상태 데이터를 PlayerPrefs에 저장합니다.
        characterStatus.SaveCharacterStatus();
    }

    public void Attack() // Attack 함수
    {
        Debug.Log(characterStatus.name + " 의 차례");
        GameObject[] enemys = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemys)
        {
            enemy.GetComponent<MonsterTest>()?.OnDamage(ATK);
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


    public void LevelUP(int EXP) // LevelUP 함수
    {
        if (characterStatus.LEVEL < max.MaxLevel)
        {
            characterStatus.EXP += EXP;
            Debug.Log("EXP" + EXP + "을 얻었습니다.");
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
        //characterStatus.DEX++;
        Debug.Log("HP가 1 증가했습니다. 현재 HP: " + characterStatus.HP);
        Debug.Log("ATK가 1 증가했습니다. 현재 ATK: " + characterStatus.ATK);
        Debug.Log("DEF가 1 증가했습니다. 현재 DEF: " + characterStatus.DEF);
        //Debug.Log("DEX가 1 증가했습니다. 현재 DEX: " + characterStatus.DEX);
    }

    public void Die()
    {
        gameObject.SetActive(false);
    }
}
