using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SuccessClear_3_1 : MonoBehaviour
{

    public Text ChatText; // 내용
    public Text Talker; // 이름
    public int ID;
    BlinkArrowSC BlinkArrowController;
    public Image fadeout_background;
    //public Image flashin_background;

    public Image background1;
    /*public Image background2;
    public Image background3;
    public Image background4;
    public Image background5;*/

    public GameObject standing1;
    public GameObject standing2;
    /*public GameObject standing3;
    public GameObject standing4;
    public GameObject standing5;
    public GameObject standing6;
    public GameObject standing7;*/

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

        if (ID == 1)//아리스,오필리아
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
        yield return StartCoroutine(NormalChat("오필리아", 1, "저거 사람인가...?"));
        standing1.SetActive(true);
        yield return StartCoroutine(NormalChat("오필리아", 1, "진짜잖아! 이런데 나 말고 또 사람이 있다니!"));
        standing1.SetActive(false);
        yield return StartCoroutine(NormalChat("아리스", 1, "....."));
        yield return StartCoroutine(NormalChat("오필리아", 1, "얘, 얘! 일어나봐!!"));
        yield return StartCoroutine(NormalChat("오필리아", 1, "주,죽은건가...?"));
        standing2.SetActive(true);
        yield return StartCoroutine(NormalChat("아리스", 1, "으...으으...머리 아파..."));
        standing2.SetActive(false);
        yield return StartCoroutine(NormalChat("아리스", 1, "살아있구나! 정신이 들어?"));
        yield return StartCoroutine(NormalChat("나레이션", 0, "이렇게 이 이야기의 주인공이 되는 두 꼬맹이들은 만났고..."));
        yield return StartCoroutine(NormalChat("나레이션", 0, "사람이 이런 이상한 곳에서 다른 사람을 만나면 친해지기 마련이란다"));
        yield return StartCoroutine(NormalChat("나레이션", 0, "두 꼬맹이는 금세 의기투합하고 어떻게 여기서 나갈지 고민하기 시작했지"));
        StartCoroutine(FadeOut(fadeout_background)); // 페이드 아웃 ->씬전환
		SceneManager.LoadScene("Stage3-2_Fail");
	}

    IEnumerator FadeIn(Image picture)
    {
        float a = 0;
        while (a <= 2)
        {
            picture.color = new Color(1, 1, 1, a);
            a += 0.1f;
            yield return new WaitForSeconds(0.05f);
        }
    }

    IEnumerator FadeOut(Image picture)
    {
        float a = 0;
        while (a <= 2)
        {
            picture.color = new Color(0, 0, 0, a);
            a += 0.1f;
            yield return new WaitForSeconds(0.05f);
        }
    }

    IEnumerator FlashIn(Image Picture)
    {
        float a = 0;
        Debug.Log("진입");
        while (a <= 2)
        {
            Picture.color = new Color(1, 1, 1, a);
            a += 0.1f;
            yield return new WaitForSeconds(0.005f);
        }
        yield return new WaitForSeconds(0.1f);
        Picture.color = new Color(1, 1, 1, 0);
    }

}
