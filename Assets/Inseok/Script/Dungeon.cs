using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dungeon : MonoBehaviour
{

     public GameObject menuDungeon;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Entering()
    {
        Time.timeScale = 0;
        menuDungeon.SetActive(true);
    }

    public void DungeonEnter()
    {
        Time.timeScale = 0;

    }

    public void MenuEnter()
    {
        Time.timeScale = 0;
        menuDungeon.SetActive(false);
    }
}
