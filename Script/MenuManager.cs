using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public GameObject GameStartArrow;
    public GameObject GameEndArrow;
    public GameObject OptionArrow;
    public GameObject blur;
    int SelectMenu = 0;

    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow) && SelectMenu < 2)
        {
            SelectMenu += 1;
            ImgOnOff(SelectMenu);
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow) && SelectMenu > 0)
        {
            SelectMenu -= 1;
            ImgOnOff(SelectMenu);
        }
        if(Input.GetKeyDown(KeyCode.Return)) // 엔터 입력시 실행
        {
            Selection(SelectMenu);
        }

    }

    void ImgOnOff(int SelelctMenu) // 화면에 보이는 UI 변경 함수
    {
        switch (SelectMenu)
        {
            case 0:
                GameStartArrow.SetActive(true);
                OptionArrow.SetActive(false);
                GameEndArrow.SetActive(false);
                break;
            case 1:
                GameStartArrow.SetActive(false);
                OptionArrow.SetActive(true);
                GameEndArrow.SetActive(false);
                break;
            case 2:
                GameStartArrow.SetActive(false);
                OptionArrow.SetActive(false);
                GameEndArrow.SetActive(true);
                break;
        }
    }


    void Selection(int SelectMenu) // 실제 메뉴 선택시 동작하는 함수
    {
        switch (SelectMenu)
        {
            case 0:
                SceneManager.LoadScene("Stage1"); // 차후에 게임 씬으로 넣어야 하는 곳
                break;
            case 1://옵션 위치
              
                break;
            case 2:
#if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;    // 유니티 플레이어에서 끄기
#else   
                Application.Quit();
#endif
                break;

        }
    }
}
