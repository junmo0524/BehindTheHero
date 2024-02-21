using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class frontcol1 : MonoBehaviour
{
    public GameObject ob6;
    public GameObject ob5;
    public GameObject ob4;
    public GameObject ob3;
    public GameObject ob2;
    public GameObject ob1;
    void Start()
    {

    }
    void Update()
    {

    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.name)
        {
            case "Circle (1)":
                ob1.GetComponent<ps1>().fron = 1;
                break;
            case "Circle (2)":
                ob2.GetComponent<ps2>().fron = 1;
                break;
            case "Circle (3)":
                ob3.GetComponent<ps3>().fron = 1;
                Debug.Log("Àü¿­");
                break;
            case "Circle (4)":
                ob4.GetComponent<ps4>().fron = 1;
                break;
            case "Circle (5)":
                ob5.GetComponent<ps5>().fron = 1;
                break;
            case "Circle (6)":
                ob6.GetComponent<ps6>().fron = 1;
                break;
        }
    }
}
