using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MonsterTest : MonoBehaviour
{
    public M_StatusData Status;
    public GoldData Gold;
    public List<Skill> SkillList = new List<Skill>();
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
        SkillList[0].StateNum();
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

    public void TurnStart()
    {
        Debug.Log(M_name + " 의 차례");
        Attack();
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
        Debug.Log(M_name + "의 " + SkillList[0].name + " 공격!");
        GameObject[] enemys = GameObject.FindGameObjectsWithTag("Hero");
        foreach (GameObject hero in enemys)
        {
            hero.GetComponent<Test>()?.OnDamage(atk + SkillList[0].Damage);
            hero.GetComponent<Test>()?.CurrState(SkillList[0].Statenum);
            hero.GetComponent<Test>()?.StateTurn(SkillList[0].StateTurn);
        }
    }

    public void Die()
    {
        gameObject.SetActive(false);
    }
}
