using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Start_2_1 : MonoBehaviour
{

    public Text ChatText; // 내용
    public Text Talker; // 이름
    public int ID;
    BlinkArrowSC BlinkArrowController;
    public Image fadeout_background;

    public Image background1;
    /*public Image background2;
    public Image background3;
    public Image background4;
    public Image background5;*/

    public GameObject standing1;
    public GameObject standing2;
    public GameObject standing3;
    public GameObject  standing4;
    /*public GameObject  standing5;
    public GameObject  standing6;*/

    //필요한 스탠딩 cg, 배경 갯수만큼 풀어서 사용할 것


    bool finished = false; // 다 출력후에 엔터를 받기 위함
    public string writerText = "";
    bool isButtonClicked = false;


    //public List<KeyCode> skipButton;

    void Start()
    {
        BlinkArrowController = GameObject.Find("Blinker").GetComponent<BlinkArrowSC>(); // blink 타이밍을 위한 변수 받아오기
        StartCoroutine(TextPrint());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space))
            if (finished == true)
                isButtonClicked = true;
    }

    IEnumerator NormalChat(string narrator, int narratorID, string narration) //narratorID 인물별 대사 설정 변경을 위한 식별자
    {
        int a = 0;
        writerText = "";
        ID = narratorID;
        Talker.text = narrator;

        if (ID == 1)//아리스
        {
            ChatText.font = Resources.Load<Font>("Fonts/MapoBackpacking");//폰트 변경
            ChatText.fontSize = 32; // 폰트간 크기 차이 보정
            ChatText.color = Color.white;
            Talker.font = Resources.Load<Font>("Fonts/MapoBackpacking");
            Talker.fontSize = 32; // 폰트간 크기 차이 보정
            Talker.color = Color.white;
        }
        if (ID == 0)//나레이션
        {
            ChatText.font = Resources.Load<Font>("Fonts/MapoPeacefull");
            ChatText.fontSize = 32;
            ChatText.color = Color.white;
            Talker.font = Resources.Load<Font>("Fonts/MapoPeacefull");
            Talker.fontSize = 32;

            Talker.color = Color.white;
        }

        //텍스트 타이핑 효과
        for (a = 0; a < narration.Length; a++)
        {
            writerText += narration[a];
            ChatText.text = writerText;
            yield return new WaitForSeconds(0.05f);
            if (a == narration.Length - 1)
            {
                BlinkArrowController.turnOn();
            }
        }
        finished = true; // 출력 완료~

        //키를 다시 누를 떄 까지 무한정 대기
        while (true)
        {
            if (isButtonClicked)
            {
                finished = false;
                isButtonClicked = false;
                BlinkArrowController.turnOff();
                break;
            }
            yield return new WaitForSeconds(0.05f);
        }
    }

    IEnumerator TextPrint()
    {
        yield return StartCoroutine(NormalChat("나레이션", 0, "별빛은 마을 전체를 뒤덮을 정도로 밝았지만 찰나의 순간에 사그라졌고, 그 빛을 본 사람은 아리스가 유일했어"));
        yield return StartCoroutine(NormalChat("나레이션", 0, "별빛은 쓰러진 아리스를 감싸고 순식간에 몸으로 스며들어 사라져 버렸어"));
        yield return StartCoroutine(NormalChat("나레이션", 0, "그로부터 어느정도 시간이 지난 후 아리스는 잠에서 깨어났단다"));
        standing1.SetActive(true);
        yield return StartCoroutine(NormalChat("아리스", 1, "어어... 무슨 일이람... 어, 안경.. 안경이 어디있지...?"));
        yield return StartCoroutine(NormalChat("아리스", 1, "안경이 깨져버렸잖아..."));
        standing1.SetActive(false);
        standing2.SetActive(true);
        yield return StartCoroutine(NormalChat("아리스", 1, "엥? 안경을 안 쓰고 있는데 왜 이렇게 잘 보이지...?"));
        standing2.SetActive(false);
        standing3.SetActive(true);
        yield return StartCoroutine(NormalChat("아리스", 1, "내 가방! 가방은 또 어디갔지?"));
        standing3.SetActive(false);
        standing4.SetActive(true);
        yield return StartCoroutine(NormalChat("아리스", 1, "잃어버리면 안되는데! 엄마가 사준건데..."));
        yield return StartCoroutine(NormalChat("아리스", 1, "깜깜해서 무서워... 근처에 있었으면 좋겠는데"));
        yield return StartCoroutine(NormalChat("아리스", 1, "빨리 찾아서 돌아가야지..."));
        StartCoroutine(FadeOut(fadeout_background)); // 페이드 아웃 ->씬전환
		yield return new WaitForSeconds(0.80f);
		SceneManager.LoadScene("Stage2-1_Fail");
	}

    IEnumerator FadeIn(Image picture)
    {
        float a = 0;
        while (a <= 2)
        {
            picture.color = new Color(1, 1, 1, a);
            a += 0.1f;
            yield return new WaitForSeconds(0.04f);
        }
    }

    IEnumerator FadeOut(Image picture)
    {
        float a = 0;
        while (a <= 2)
        {
            picture.color = new Color(0, 0, 0, a);
            a += 0.1f;
            yield return new WaitForSeconds(0.04f);
        }
    }

}