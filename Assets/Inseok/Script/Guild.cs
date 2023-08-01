using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guild : MonoBehaviour
{

    public GameObject menuGuild;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Click_Guild()
    {
        Time.timeScale = 0;
        menuGuild.SetActive(true);
    }

    public void Click_Quest()
    {
        Time.timeScale = 0;
        
    }


}
