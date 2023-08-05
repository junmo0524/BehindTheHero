using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterTest : MonoBehaviour
{
    public M_StatusData Status;
    public StatusData H_Status;
    public GoldData Gold;
    private string M_name;
    private int hp;
    private int atk;
    private int def;
    private int dex;
    private int exp;

    public void Awake()
    {
        M_name = Status.MonsterName;
        hp = Status.Hp;
        atk = Status.ATK;
        def = Status.DEF;
        dex = Status.DEX;
        exp = Status.EXP;
    }
    void Start()
    {
        Debug.Log(M_name);
    }

    public void Update()
    {

    }
    public void OnDamage(int ATK, int RoleNum)
    {
        hp = hp - ATK;
        Debug.Log("남은 체력: " + hp);
        if(hp <= 0)
        {
            Debug.Log(M_name + "을 물리쳤습니다");
            Gold.Mineral += 50;
            H_Status.statusList[RoleNum].EXP += 5;
            Debug.Log("Mineral 50을 얻었습니다. 현재 Mineral: " + Gold.Mineral);
            Debug.Log("EXP 5을 얻었습니다. 현재 EXP: " + H_Status.statusList[RoleNum].EXP);
            gameObject.SetActive(false);
        }
    }
}
