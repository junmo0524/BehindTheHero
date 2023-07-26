using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Test2 : MonoBehaviour
{
    public StatusData characterStatus;

    public void Start()
    {
        // PlayerPrefs에서 데이터를 불러옵니다.
        characterStatus.LoadCharacterStatus();

        if (characterStatus.statusList.Count > 0)
        {
            // 첫 번째 캐릭터의 HP를 1 증가시킵니다.
            characterStatus.statusList[0].HP++;
            Debug.Log("캐릭터가 레벨업하여 HP가 1 증가했습니다. 현재 HP: " + characterStatus.statusList[0].HP);

            // 변경된 상태 데이터를 PlayerPrefs에 저장합니다.
            characterStatus.SaveCharacterStatus();
        }
        else
        {
            Debug.Log("캐릭터 데이터가 없습니다. 레벨업에 실패했습니다.");
        }
    }

    private const int MaxCharacterLevel = 100;

    public void Update()
    {
        if (Input.GetMouseButton(0))
        {
            SceneManager.LoadScene("TestScene1");
        }
    }
}
