using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<int> MonsterList = new List<int>(); // DEX 값을 저장할 List를 생성합니다.
    public List<GameObject> EnemyList = new List<GameObject>(); // DEX가 가장 높은 Enemy를 저장할 List를 생성합니다.

    public void Start()
    {
        // Enemy 태그를 가진 모든 오브젝트를 찾습니다.
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        // 찾은 각 오브젝트들의 StatusData 스크립트에서 DEX 값을 가져와서 List에 추가합니다.
        foreach (GameObject enemy in enemies)
        {
            int status = enemy.GetComponent<MonsterTest>().Status.DEX;
            MonsterList.Add(status);
        }

        // List를 내림차순으로 정렬합니다.
        MonsterList.Sort();
        MonsterList.Reverse();

        // 정렬된 순서대로 EnemyList에 추가합니다.
        foreach (int dexValue in MonsterList)
        {
            GameObject enemy = FindEnemyByDEX(dexValue);
            if (enemy != null)
            {
                EnemyList.Add(enemy);
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

    private GameObject FindHeroByDEX(int dexValue, int RoleNum)
    {
        GameObject[] heroes = GameObject.FindGameObjectsWithTag("Hero");
        foreach (GameObject hero in heroes)
        {
            int status = hero.GetComponent<Test>().characterStatus.statusList[RoleNum].DEX;
            if (status == dexValue)
            {
                return hero;
            }
        }
        return null;
    }
}
