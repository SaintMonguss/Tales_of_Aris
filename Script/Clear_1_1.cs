using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Clear_1_1 : MonoBehaviour
{

    public Text ChatText; // 내용
    public Text Talker; // 이름
    public int ID;
    BlinkArrowSC BlinkArrowController;
    public Image fadeout_background;

    public Image background1;
    public Image background2;
    /*public Image background3;
    public Image background4;
    public Image background5;*/

    public GameObject standing1;
    public GameObject standing2;
    public GameObject standing3;
    /*public GameObject  standing4;
    public GameObject  standing5;
    public GameObject  standing6;*/

    //필요한 스탠딩 cg, 배경 갯수만큼 풀어서 사용할 것


    bool finished = false; // 다 출력후에 엔터를 받기 위함
    public string writerText = "";
    bool isButtonClicked = false;
    

    //public List<KeyCode> skipButton;

    void Start()
    {
		StartCoroutine(FadeOut_Black(fadeout_background));
        BlinkArrowController = GameObject.Find("Blinker").GetComponent<BlinkArrowSC>(); // blink 타이밍을 위한 변수 받아오기
        StartCoroutine(TextPrint());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space))
            if(finished == true)
                isButtonClicked = true;
    }

    IEnumerator NormalChat(string narrator, int narratorID , string narration) //narratorID 인물별 대사 설정 변경을 위한 식별자
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
        yield return StartCoroutine(NormalChat("나레이션", 0, "가까스로 교내를 나온 아리스는 달맞이꽃이 많이 있는, 마을을 수호한다는 큰 나무까지 올라갔어\n그리고 밤 하늘을 보면서 잠시 감상에 빠졌단다"));
        yield return StartCoroutine(NormalChat("나레이션", 0, "맑은 밤 하늘과 달빛을 받은 꽃들은 감상에 젖기 충분했거든"));
        yield return StartCoroutine(NormalChat("나레이션", 0, "밤 하늘에서 가장 빛나는 별을 보면서 고생했다는 생각은 점점 사라졌지"));
        standing1.SetActive(true);
        yield return StartCoroutine(NormalChat("아리스", 1, "가끔은 이렇게 오는 것도 좋네...아주 가끔은"));
        standing1.SetActive(false);
        standing2.SetActive(true);
        yield return StartCoroutine(NormalChat("아리스", 1, "그런데 저렇게 큰 별이 있었나? 처음 보는데"));
        standing2.SetActive(false);
        standing3.SetActive(true);
        yield return StartCoroutine(NormalChat("아리스", 1, "....? 점점 이쪽으로 오는 것 같은...데?"));
        StartCoroutine(FadeIn(background2)); //페이드 인 전환
        standing3.SetActive(false);
        yield return StartCoroutine(NormalChat("나레이션", 0 , "별이 이쪽으로 온다고 눈치 챘을 땐 이미 늦었어"));
        yield return StartCoroutine(NormalChat("나레이션", 0 , "운명이 바뀌는건 원래 한 순간이잖아"));
        yield return StartCoroutine(NormalChat("아리스", 1, "꺄아아아아악---!"));
        yield return StartCoroutine(NormalChat("아리스", 1, "왜 여기로 오는거야?!"));
        StartCoroutine(FadeOut(fadeout_background)); // 페이드 아웃 ->씬전환
		yield return new WaitForSeconds(0.80f);
		SceneManager.LoadScene("Chapter2_1_start");

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
	IEnumerator FadeOut_Black(Image picture)
	{
		float a = 2;
		while (a >= 0)
		{
			picture.color = new Color(0, 0, 0, a);
			a -= 0.1f;
			yield return new WaitForSeconds(0.04f);
		}
	}
}
