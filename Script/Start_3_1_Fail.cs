﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Start_3_1_Fail : MonoBehaviour
{
	private GameObject main_camera;
	private GameObject text_canvas;
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
	public GameObject standing4;
	public GameObject standing5;
	public GameObject standing6;
	public GameObject standing7;
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

		main_camera = GameObject.Find("Main Camera");
		text_canvas = GameObject.Find("Canvas");
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
		StartCoroutine(FadeOut_Black(background1)); // 페이드 아웃 ->씬전환*/
		text_canvas.SetActive(false);
		main_camera.GetComponent<Cam_manager_stage3_1_Fail>().StartCoroutine("Show_Night_Coroutine");
		yield return new WaitForSeconds(10f);
		text_canvas.SetActive(true);

		yield return StartCoroutine(NormalChat("나레이션", 0, "깊고 어두운 심연속에 아리스가 삼켜지는 듯 했지만, 거기에는 또 다른 한명이 있었지"));

		standing1.SetActive(true); // Ophelia_complicated
		yield return StartCoroutine(NormalChat("???", 1, "뭣도 모르고 쫓아와서 굴러 떨어지고.. 스승님 보기가 부끄럽네"));
		standing1.SetActive(false);

		yield return StartCoroutine(NormalChat("나레이션", 0, "붉은 머리칼이 인상적인 이 꼬맹이는 오필리아."));

		standing2.SetActive(true); // Ophelia_complicated.
		yield return StartCoroutine(NormalChat("오필리아", 1, "뭐 보이는 것도 체스판 같은 바닥밖에 없고.. 누가 이런걸 만든거지?"));
		standing2.SetActive(false);

		standing3.SetActive(true); // Ophelia_complicated
		yield return StartCoroutine(NormalChat("오필리아", 1, "이것저것 따지면서 다니는 건 정말 귀찮은데"));
		standing3.SetActive(false);

		standing4.SetActive(true); // Ophelia_angry
		yield return StartCoroutine(NormalChat("오필리아", 1, "에잇! 길이 나올때까지 다 때려 부수고 싶어!"));
		standing4.SetActive(false);

		yield return StartCoroutine(NormalChat("나레이션", 0, "굉장히 알기 쉬운 성격이지..."));

		yield return StartCoroutine(NormalChat("나레이션", 0, "아무튼.. 이 소녀도 자신이 큰 흐름 속에 몸이 담겨버린 걸 눈치 채지 못했단다."));

		standing5.SetActive(true); // Ophelia_Surprise
		yield return StartCoroutine(NormalChat("오필리아", 1, "뭐지...? 방금 소리!?"));
		standing5.SetActive(false);

		standing6.SetActive(true); // Ophelia_Surprise
		yield return StartCoroutine(NormalChat("오필리아", 1, "건너편에서 소리가 난 거 같은데.. 가봐야겠어!"));
		standing6.SetActive(false);

		standing7.SetActive(true); // Ophelia_normal
		yield return StartCoroutine(NormalChat("오필리아", 1, "거슬리는 벽을 부수는 문자는 A야. 하지만 부수는데 한계가 있으니 신중하게.."));
		standing7.SetActive(false);

		main_camera.GetComponent<Cam_manager_stage3_1_Fail>().StartCoroutine("Now_Game_Start");
		text_canvas.SetActive(false);
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
	public void Fade_Image()
	{
		StartCoroutine(FadeOut_Clear(fadeout_background));
	}
	IEnumerator FadeOut_Clear(Image picture)
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