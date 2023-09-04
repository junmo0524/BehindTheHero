using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountBar : MonoBehaviour
{
    public GameObject prfHpBar;
    public GameObject canvas;

    public Vector2 size;
   // public LayerMask whatis;

    RectTransform hpbar;

    public float height = -0.25f;
    
    // Start is called before the first frame update
    void Start()    
    {
        prfHpBar.SetActive(false);
        hpbar = Instantiate(prfHpBar,canvas.transform).GetComponent<RectTransform>();

        //������Ʈ ������ �浹�� ��� Ȯ��

        Collider2D[] hit = Physics2D.OverlapBoxAll(transform.position, size, 0);

        for (int i = 0; i < hit.Length; ++i)
        {
            Debug.Log(hit[i].name);
            if (hit[i].name == "Player")
            {
                prfHpBar.SetActive(true);
            }
            else
            {
                prfHpBar.SetActive(false);
            }
        }

    }

    // Update is called once per frame
    void Update()
    {   //������Ʈ�� HP�� ǥ��
        Vector3 _hpBarPos =
            Camera.main.WorldToScreenPoint(new Vector3(transform.position.x, transform.position.y + height, 0));
        hpbar.position = _hpBarPos;

    }

    void OnDrawGizmos()
    { //�浹ü ���� ���������� ����
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, size);
    }
}
