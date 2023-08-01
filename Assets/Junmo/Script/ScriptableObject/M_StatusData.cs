using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Monster Data", menuName = "Custom/Monster Data", order = int.MaxValue)]
public class M_StatusData : ScriptableObject
{
    [SerializeField]
    private string monsterName;
    public string MonsterName { get { return monsterName; } }
    [SerializeField]
    private int hp;
    public int Hp { get { return hp; } }
    [SerializeField]
    private int atk;
    public int ATK { get { return atk; } }
    [SerializeField]
    private int def;
    public int DEF { get { return def; } }
    [SerializeField]
    private int dex;
    public int DEX { get { return dex; } }
    [SerializeField]
    private int Exp;
    public int EXP { get { return dex; } }
}
