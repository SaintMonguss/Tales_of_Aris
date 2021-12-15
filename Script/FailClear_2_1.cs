using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FailClear_2_1 : MonoBehaviour
{

    public Text ChatText; // 내용
    public Text Talker; // 이름
    public int ID;
    BlinkArrowSC BlinkArrowController;
    CrackSC CrackSC;
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
        BlinkArrowController = GameObject.Find("Blinker").GetComponent<BlinkArrowSC>(); // blink 타이밍을 위한 변수 받아오기
        CrackSC = GameObject.Find("GameManager").GetComponent<CrackSC>(); // 크랙 타이밍을 위한 스크립트 연결

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

        if (ID == 2)//괴물 또는 ??? 같은 이질적인 존재
        {
            ChatText.font = Resources.Load<Font>("Fonts/Tracefont");//폰트 변경
            ChatText.fontSize = 32; // 폰트간 크기 차이 보정
            ChatText.color = Color.white;
            Talker.font = Resources.Load<Font>("Fonts/Tracefont");
            Talker.fontSize = 32; // 폰트간 크기 차이 보정
            Talker.color = Color.white;
        }

        if (ID == 3)//시스템
        {
            ChatText.font = Resources.Load<Font>("Fonts/YiSunShin");//폰트 변경
            ChatText.fontSize = 38; // 폰트간 크기 차이 보정
            ChatText.color = Color.red;
            Talker.font = Resources.Load<Font>("Fonts/YiSunShin");
            Talker.fontSize = 32; // 폰트간 크기 차이 보정
            Talker.color = Color.red;
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
        standing1.SetActive(true);
        yield return StartCoroutine(NormalChat("아리스", 1, "...! 여긴 막혔으니 다른 길을..."));
        yield return StartCoroutine(NormalChat("???", 2, "...!!"));
        standing1.SetActive(false);
        standing2.SetActive(true);
        yield return StartCoroutine(NormalChat("아리스", 1, "....?"));
        standing2.SetActive(false);
        standing3.SetActive(true);
        yield return StartCoroutine(NormalChat("아리스", 1, "아, 아히이이익!!"));
        StartCoroutine(FadeIn(background2)); //페이드 인 전환
        standing3.SetActive(false);
        GameObject.Find("SoundManager").GetComponent<AudioSource>().Play();
        yield return StartCoroutine(NormalChat( "FAIL", 3, "아리스는 눈치 채자 마자 이형의 존재의 습격을 받아 쓰러졌다."));
        yield return StartCoroutine(CrackSC.Crack()); // 크랙 함수 호출
        StartCoroutine(FadeOut(fadeout_background)); // 페이드 아웃 ->씬전환
		yield return new WaitForSeconds(0.80f);
		SceneManager.LoadScene("Stage2-1_Success");
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

