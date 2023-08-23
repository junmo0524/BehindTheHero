using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tria3 : MonoBehaviour
{
    public int allalla = 10;
    // Start is called before the first frame update
    public void alla(int a)
    {
        Debug.Log("Àü");
        Debug.Log(allalla);//10
        Debug.Log("»©±â");
        Debug.Log(a);//4
        allalla = allalla - a;
        Debug.Log("ÈÄ");
        Debug.Log(allalla);//6
    }
}
