using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public Rigidbody2D rigid;
    public GoldData collect;

    public string item;
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Target")
        {

            switch (item)
            {
                case "Wood":
                    Debug.Log("³ª¹« 1°³ È¹µæ");
                    collect.Wood++;
                    Debug.Log("³ª¹«:"+collect.Wood);
                    Destroy(gameObject);
                    break;

                case "gold":
                    Debug.Log("°ñµå 1°³ È¹µæ");
                    collect.Money++;
                    Debug.Log("µ·:" + collect.Money);
                    Destroy(gameObject);
                    break;

                case "mineral":
                    Debug.Log("±¤¹° 1°³ È¹µæ");
                    collect.Mineral++;
                    Debug.Log("±¤¹°:" + collect.Mineral);
                    Destroy(gameObject);
                    break;
            }

        }
    }
}
