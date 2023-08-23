using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "New Status Data", menuName = "Custom/Skill Data")]
public class Skill : ScriptableObject
{ 
    public enum SkillState
    {
        None,
        Burn,
        Scar,
        Hungry
    }

    [SerializeField]
    public string Name;

    [SerializeField]
    public int Damage;

    [SerializeField]
    public SkillState state;

    [SerializeField]
    public int StateTurn;

    public int Statenum;
    public void StateNum()
    {
        switch (state)
        {
            case SkillState.None:
                Statenum = 0;
                break;
            case SkillState.Burn:
                Statenum = 1;
                break;
            case SkillState.Scar:
                Statenum = 2;
                break;
            case SkillState.Hungry:
                 Statenum = 3;
                break;
        }
    }
}
