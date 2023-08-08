using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MonsterTest : MonoBehaviour
{
    public M_StatusData Status;
    public GoldData Gold;
    public TMP_Text DisplayStatus;
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

    }

    public void Update()
    {
        DisplayStatus.text =
            M_name + "\n" +
           "HP: " + hp + "/" + Status.Hp + "\n" +
           "ATK: " + atk + "\n" +
           "DEF: " + def + "\n" +
           "DEX: " + dex;
    }
    public void OnDamage(int ATK)
    {
        hp = hp - ATK;
        Debug.Log(ATK + "만큼의 피해를 입었다");
        if(hp <= 0)
        {
            hp = 0;
            Debug.Log(M_name + "을 물리쳤습니다");
            Gold.Mineral += 50;
            GameObject[] enemys = GameObject.FindGameObjectsWithTag("Hero");
            foreach (GameObject hero in enemys)
            {
                hero.GetComponent<Test>()?.LevelUP(exp);
            }
            Debug.Log("Mineral 50을 얻었습니다. 현재 Mineral: " + Gold.Mineral);
            Invoke("Die", 0.2f);
        }
    }

    public void Attack()
    {
        Debug.Log(M_name + " 의 차례");
        GameObject[] enemys = GameObject.FindGameObjectsWithTag("Hero");
        foreach (GameObject hero in enemys)
        {
            hero.GetComponent<Test>()?.OnDamage(atk);
            hero.GetComponent<Test>()?.CurrState(1);
        }
    }

    public void Die()
    {
        gameObject.SetActive(false);
    }
}
