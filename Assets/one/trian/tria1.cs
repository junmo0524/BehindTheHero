using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tria1 : MonoBehaviour
{
    public int matk = 2;
    public int mhp = 10;
    public void attack(int atk)
    {
        Debug.Log("Àü");
        Debug.Log(mhp);//10
        Debug.Log("»©±â");
        Debug.Log(atk);//4
        mhp = mhp - atk;
        Debug.Log("ÈÄ");
        Debug.Log(mhp);//6
    }
}
