using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class col3 : MonoBehaviour
{
    public GameObject obje;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.name)
        {
            case "Triangle (3)":
                obje = collision.gameObject;
                Debug.Log("¿¿¿¿¿¿");
                break;
        }
    }
}
