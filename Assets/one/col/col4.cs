using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class col4 : MonoBehaviour
{
    public GameObject obje;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.name)
        {
            case "Triangle (1)":
                obje = collision.gameObject;
                break;
            case "Triangle (2)":
                obje = collision.gameObject;
                break;
            case "Triangle (3)":
                obje = collision.gameObject;
                break;
            case "Triangle (4)":
                obje = collision.gameObject;
                break;
            case "Triangle (5)":
                obje = collision.gameObject;
                break;
            case "Triangle (6)":
                obje = collision.gameObject;
                break;
        }
    }
}
