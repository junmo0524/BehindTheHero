using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ps3 : MonoBehaviour
{
    public GameObject objj;//쓸 오브젝트의 자리
    public GameObject objee;
    public GameObject ob6;
    public GameObject ob5;
    public GameObject ob4;
    public GameObject ob3;
    public GameObject ob2;
    public GameObject ob1;
    public Vector3 tr;
    public Vector3 tr2;
    public int tra = 0;
    void OnMouseDrag()
    {
        float distance = Camera.main.WorldToScreenPoint(transform.position).z;

        Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
        Vector3 objPos = Camera.main.ScreenToWorldPoint(mousePos);


        transform.position = objPos;
    }
    void OnMouseUp()
    {
        if (tra == 1)
        {
            ob3.transform.position = tr2;
            tra = 0;
        }
        else
        {
            ob3.transform.position = tr;
        }
        objee = objj.GetComponent<col3>().obje;//Start()로는 안되서 일단 클릭해야 되는 걸로 함
        objee.GetComponent<tria3>().alla(4);//allalla에서 4를 뺄 것임
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (tra == 2)
        {
            switch (collision.gameObject.name)
            {
                case "Circle (1)":
                    tra = 1;
                    tr2 = ob1.transform.position;
                    ob1.transform.position = tr;
                    break;
                case "Circle (2)":
                    tra = 1;
                    tr2 = ob2.transform.position;
                    ob2.transform.position = tr;
                    break;
                case "Circle (3)":
                    tra = 1;
                    tr2 = ob3.transform.position;
                    ob3.transform.position = tr;
                    break;
                case "Circle (4)":
                    tra = 1;
                    tr2 = ob4.transform.position;
                    ob4.transform.position = tr;
                    break;
                case "Circle (5)":
                    tra = 1;
                    tr2 = ob5.transform.position;
                    ob5.transform.position = tr;
                    break;
                case "Circle (6)":
                    tra = 1;
                    tr2 = ob6.transform.position;
                    ob6.transform.position = tr;
                    break;
            }
        }
    }
    void OnMouseDown()
    {
        tr = ob3.transform.position;
        tra = 2;
    }

}


