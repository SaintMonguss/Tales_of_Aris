using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Clear_3_2_Success : MonoBehaviour
{
	private GameObject main_camera;
	private GameObject text_canvas;
	public Text ChatText; // 내용
    public Text Talker; // 이름
    public int ID;
    BlinkArrowSC BlinkArrowController;
    public Image fadeout_background;
    //public Image flashin_background;

	public GameObject back_1;
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
	public GameObject standing8;

	//필요한 스탠딩 cg, 배경 갯수만큼 풀어서 사용할 것


	bool finished = false; // 다 출력후에 엔터를 받기 위함
    public string writerText = "";
    bool isButtonClicked = false;


    //public List<KeyCode> skipButton;

    void Start()
    {
        BlinkArrowController = GameObject.Find("Blinker").GetComponent<BlinkArrowSC>(); // blink 타이밍을 위한 변수 받아오기
		main_camera = GameObject.Find("Main_Camera");
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
		text_canvas.SetActive(true);
		standing1.SetActive(true); // Ophelia_smile
		yield return StartCoroutine(NormalChat("오필리아", 1, "헤헷! 이 몸의 파워로 없던 길도 만들어내는 능력을 보아라!"));
		standing1.SetActive(false);

		standing2.SetActive(true); // Aris_sigh
		yield return StartCoroutine(NormalChat("아리스", 1, "에휴 그렇게 함부로 밀지 말라고 했는데.."));
		standing2.SetActive(false);

		standing3.SetActive(true); // Ophelia_smile
		yield return StartCoroutine(NormalChat("오필리아", 1, "결과만 좋으면 다 좋은거 아니겠어?"));
		standing3.SetActive(false);

		standing4.SetActive(true); // Aris_normal
		yield return StartCoroutine(NormalChat("아리스", 1, "아무튼 간에 쿠키랑 물약을 얻었으니까"));
		standing4.SetActive(false);

		standing5.SetActive(true); // Aris_normal
		yield return StartCoroutine(NormalChat("오필리아", 1, "아리스. 내 어깨에 손대봐"));
		standing5.SetActive(false);

		standing6.SetActive(true); // Aris_normal
		yield return StartCoroutine(NormalChat("아리스", 1, "응? 자. 어깨에 손은 왜."));
		standing6.SetActive(false);

		standing7.SetActive(true); // Aris_normal
		yield return StartCoroutine(NormalChat("오필리아", 1, "그럼 쿠키부터 먹어보실까"));
		standing7.SetActive(false);

		standing8.SetActive(true); // Aris_normal
		yield return StartCoroutine(NormalChat("아리스", 1, "오필리..!! 꺄아아악!"));
		standing8.SetActive(false);
		StartCoroutine(FadeOut(fadeout_background)); // 페이드 아웃 ->씬전환

		back_1.SetActive(true);

		yield return StartCoroutine(NormalChat("오필리아", 1, "우오오왓! 진짜 순식간에 커졌잖아"));
		yield return StartCoroutine(NormalChat("아리스", 1, "살~~려~~줘~~!!!"));
		yield return StartCoroutine(NormalChat("오필리아", 1, "살고 싶으면 꽉 붙들어 매. 죄다 부수고 나갈테니깐!"));
		yield return StartCoroutine(NormalChat("아리스", 1, "무~식~한~년아~~!! 그만!!!"));
		yield return StartCoroutine(NormalChat("오필리아", 1, "간다!!"));
		yield return StartCoroutine(NormalChat("나레이션", 1, "어깨에 대롱대롱 매달려 있는 아리스의 모습이 얼마나 웃기던지.."));
		yield return StartCoroutine(NormalChat("나레이션", 1, "거대해진 오필리아는 자기의 앞길을 가로막는 모든걸 부수며 앞으로 나아갔어.."));
		yield return StartCoroutine(NormalChat("개발자", 1, "데모버전은 여기까지입니다."));
		#if UNITY_EDITOR
			UnityEditor.EditorApplication.isPlaying = false;    // 유니티 플레이어에서 끄기
		#else
                Application.Quit();
		#endif

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
