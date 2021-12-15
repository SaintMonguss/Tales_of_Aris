using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SuccessClear_2_1 : MonoBehaviour
{

    public Text ChatText; // 내용
    public Text Talker; // 이름
    public int ID;
    BlinkArrowSC BlinkArrowController;
    public Image fadeout_background;
    public Image flashin_background;

    public Image background1;
    public Image background2;
    public Image background3;
    public Image background4;
    //public Image background5;

    public GameObject standing1;
    public GameObject standing2;
    public GameObject standing3;
    public GameObject standing4;
    public GameObject standing5;
    public GameObject standing6;
    public GameObject standing7;

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

        if (ID == 0)//나레이션
        {
            ChatText.font = Resources.Load<Font>("Fonts/MapoPeacefull");
            ChatText.fontSize = 32;
            ChatText.color = Color.white;
            Talker.font = Resources.Load<Font>("Fonts/MapoPeacefull");
            Talker.fontSize = 32;
            Talker.color = Color.white;
        }

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
        yield return StartCoroutine(NormalChat("아리스", 1, "후후, 천재 아리스님에게 이 정도 퍼즐은 식은 죽 먹기지"));
        yield return StartCoroutine(NormalChat("아리스", 1, "자... 가방아 주인님이 왔다"));
        standing1.SetActive(false);
        standing2.SetActive(true);
        yield return StartCoroutine(NormalChat("아리스", 1, "응? 가방이 왜 이리 지저분하지? 뭐야 이 기분 나쁜 거..."));
        standing2.SetActive(false);
        yield return StartCoroutine(FlashIn(flashin_background));
        background2.color = new Color(1, 1, 1, 1); // 배경 전환
        yield return StartCoroutine(NormalChat("아리스", 1, "꺄악!!"));
        standing3.SetActive(true);
        yield return StartCoroutine(NormalChat("아리스", 1, "엇,뭐야! 누구야?! "));
        standing3.SetActive(false);
        standing4.SetActive(true);
        yield return StartCoroutine(NormalChat("아리스", 1, "....? 뭐...뭐야 저거? 괴,괴물?"));
        standing4.SetActive(false);
        yield return StartCoroutine(NormalChat("기괴한 형상", 2, "........"));
        standing5.SetActive(true);
        yield return StartCoroutine(NormalChat("아리스", 1, "....."));
        standing5.SetActive(false);
        yield return StartCoroutine(NormalChat("기괴한 형상", 2, "캬아아아악!"));
        standing5.SetActive(true);
        yield return StartCoroutine(NormalChat("아리스", 1, "히이익! 도망가!! 사...살려주세요!"));
        standing5.SetActive(false);
        StartCoroutine(FadeOut(background3));
        standing6.SetActive(true);
        yield return StartCoroutine(NormalChat("아리스", 1, "하아!하아! ....따돌린것 같은데..."));
        yield return StartCoroutine(NormalChat("아리스", 1, "또 나올지도 몰라\n저기 동굴에 좀 숨어있다가 날이 밝으면 가야겠다"));
        standing6.SetActive(false);
        standing7.SetActive(true);
        yield return StartCoroutine(NormalChat("아리스", 1, "아?!"));
        standing7.SetActive(false);
        StartCoroutine(FadeIn(background4));
        yield return StartCoroutine(NormalChat("아리스", 1, "절벽? 갑자기?!"));
        yield return StartCoroutine(NormalChat("아리스", 1, "꺄아아아아아악!! 오늘 대체 뭐야!! 뭐냐---고오오--!!"));
        yield return StartCoroutine(NormalChat("나레이션", 0, "숲 속에서 괴물에게 쫒기던 아리스는 안전해 보이는 동굴로 도망쳤지만 사실은 이 모든 일의 원흉들이 있는 소굴로 스스로 들어가고 말았단다"));
        yield return StartCoroutine(NormalChat("나레이션", 0, "뒤틀리고 상식이라곤 통하지 않는 깊은 심연 속으로 말이야"));
        StartCoroutine(FadeOut(fadeout_background)); // 페이드 아웃 ->씬전환
		yield return new WaitForSeconds(0.80f);
		SceneManager.LoadScene("Stage3-1_Fail");

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

    IEnumerator FlashIn(Image Picture)
    {
        float a = 0;
        Debug.Log("진입");
        while(a<=2)
        {
            Picture.color = new Color(1, 1, 1, a);
            a += 0.1f;
            yield return new WaitForSeconds(0.005f);
        }
        yield return new WaitForSeconds(0.1f);
        Picture.color = new Color(1, 1, 1, 0);
    }

}
