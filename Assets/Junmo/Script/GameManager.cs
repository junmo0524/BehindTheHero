using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private List<int> DexList = new List<int>(); // DEX 값을 저장할 List를 생성합니다.
    private List<GameObject> StatusList = new List<GameObject>(); // DEX가 가장 높은 Enemy를 저장할 List를 생성합니다.
    public List<GameObject> List = new List<GameObject>();

    public void Start()
    {
        TurnSpeed();
        Debug.Log(turn + "턴");
    }

    public void TurnSpeed()
    {
        // Enemy 태그를 가진 모든 오브젝트를 찾습니다.
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject[] heores = GameObject.FindGameObjectsWithTag("Hero");

        // 찾은 각 오브젝트들의 StatusData 스크립트에서 DEX 값을 가져와서 List에 추가합니다.
        foreach (GameObject enemy in enemies)
        {
            int M_status = enemy.GetComponent<MonsterTest>().Status.DEX;
            DexList.Add(M_status);
        }
        foreach (GameObject hero in heores)
        {
            int H_status = hero.GetComponent<Test>().characterStatus.DEX;
            DexList.Add(H_status);
        }

        // List를 내림차순으로 정렬합니다.
        DexList.Sort();
        DexList.Reverse();

        // 정렬된 순서대로 EnemyList에 추가합니다.
        foreach (int dexValue in DexList)
        {
            GameObject enemy = FindEnemyByDEX(dexValue);
            GameObject hero = FindHeroByDEX(dexValue);
            StatusList.Add(hero);
            StatusList.Add(enemy);
        }
        foreach (GameObject w in StatusList)
        {
            if (w != null)
            {
                List.Add(w);
            }
        }
    }

    // DEX 값을 기반으로 해당 enemy를 찾는 메서드
    private GameObject FindEnemyByDEX(int dexValue)
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            int status = enemy.GetComponent<MonsterTest>().Status.DEX;
            if (status == dexValue)
            {
                return enemy;
            }
        }
        return null;
    }

    private GameObject FindHeroByDEX(int dexValue)
    {
        GameObject[] heroes = GameObject.FindGameObjectsWithTag("Hero");
        foreach (GameObject hero in heroes)
        {
            int status = hero.GetComponent<Test>().characterStatus.DEX;
            if (status == dexValue)
            {
                return hero;
            }
        }
        return null;
    }

    int num;
    int turn = 1;
    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (num < List.Count)
            {
                if (List[num].gameObject.tag == "Enemy")
                {
                    if (List[num].gameObject.activeSelf == true)
                    {
                        List[num].GetComponent<MonsterTest>().TurnStart();
                    }
                    else if (List[num].gameObject.activeSelf == false)
                    {
                        Debug.Log(List[num].gameObject.GetComponent<MonsterTest>().Status.name + "은/는 움직일 수 없다");
                    }
                }
                else if (List[num].gameObject.tag == "Hero")
                {
                    if (List[num].gameObject.activeSelf == true)
                    {
                        List[num].GetComponent<Test>().TurnStart();
                    }
                    else if (List[num].gameObject.activeSelf == false)
                    {
                        Debug.Log(List[num].gameObject.GetComponent<Test>().characterStatus.name + "은/는 움직일 수 없다");
                    }
                }
                num++;
            }
            else
            {
                turn++;
                num = 0;
                DexList.Clear();
                StatusList.Clear();
                List.Clear();
                TurnSpeed();
                Debug.Log(turn + "턴");
            }
        }
    }
}
