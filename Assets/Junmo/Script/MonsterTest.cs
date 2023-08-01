using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterTest : MonoBehaviour
{
    public M_StatusData Status;
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

    void Update()
    {
        
    }
}
