using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Start_3_2_fail : MonoBehaviour
{
	private GameObject main_camera;
	private GameObject text_canvas;
	private GameObject text_canvas2;
	private GameObject text_canvas3;
	private GameObject text_canvas4;
	private GameObject text_canvas5;
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
	public GameObject standing4;
	public GameObject standing5;
	public GameObject standing6;
	public GameObject standing7;
	public GameObject standing8;
	public GameObject standing9;
	public GameObject standing10;
	public GameObject standing11;
	public GameObject standing12;
	public GameObject standing13;
	public GameObject standing14;
	public GameObject standing15;
	public GameObject standing16;



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
		text_canvas2 = GameObject.Find("Text_Background");
		text_canvas3 = GameObject.Find("Blinker");
		text_canvas4 = GameObject.Find("Talker");
		text_canvas5 = GameObject.Find("Text");
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

		if (ID == 2) // 학원장
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
		text_canvas.gameObject.SetActive(false);
		main_camera.GetComponent<Cam_manager_stage3_2_Fail>().StartCoroutine("Show_Night_Coroutine");
		yield return new WaitForSeconds(10f);
		text_canvas.gameObject.SetActive(true);

		standing1.SetActive(true); // Ophelia_angry
        yield return StartCoroutine(NormalChat("오필리아", 1, "그러니까 아까 여기 왔을 때는 이 문도 없었고 말도 안했다니깐!?"));
        standing1.SetActive(false);

		standing2.SetActive(true); // Aris_sigh
		yield return StartCoroutine(NormalChat("아리스", 1, "아무리 그래도 너무 대충 본거 아니야?"));
		standing2.SetActive(false);

		standing3.SetActive(true); // Ophelia_angry
		yield return StartCoroutine(NormalChat("오필리아", 1, "야! 문짝! 아까 너 없었잖아! 말 좀 해봐!!"));
		standing3.SetActive(false);

		standing4.SetActive(true); // Aris_surprise
		yield return StartCoroutine(NormalChat("아리스", 1, "문짝 부숴지겠어! 그만해!"));
		standing4.SetActive(false);

		standing5.SetActive(true); // Aris_sigh
		yield return StartCoroutine(NormalChat("아리스", 1, "에휴, 일단 지금 상황을 정리해보자."));
		standing5.SetActive(false);

		standing6.SetActive(true); // Aris_normal
		yield return StartCoroutine(NormalChat("아리스", 1, "일단, 여기서 다시 나갈 길은 당장에 저 문짝인데.. 저 문짝이 말하는게"));
		standing6.SetActive(false);

		standing7.SetActive(true); // Ophelia_angry
		yield return StartCoroutine(NormalChat("오필리아", 1, "뭐 먹으면 커지는 쿠키랑, 마시면 작아지는 물약이 이 세상에 어디있냐고.."));
		standing7.SetActive(false);

		standing8.SetActive(true); // Aris_smile
		yield return StartCoroutine(NormalChat("아리스", 1, "일단 다시 주변을 돌아다니면서 무언가 있나 찾아보자. 뭔가 단서가 나올지 몰라."));
		standing8.SetActive(false);

		standing9.SetActive(true); // Ophelia_complicated
		yield return StartCoroutine(NormalChat("오필리아", 1, "아까 봤을땐 아무것도 없었는데.."));
		standing9.SetActive(false);

		standing10.SetActive(true); // Aris(...)
		yield return StartCoroutine(NormalChat("아리스", 1, "..."));
		standing10.SetActive(false);

		standing11.SetActive(true); // Ophelia_pretend to 
		yield return StartCoroutine(NormalChat("오필리아", 1, "아! 예! 예! 다시 찾아보겠습니다."));
		standing11.SetActive(false);

		standing12.SetActive(true); // Ophlelia_smile
		yield return StartCoroutine(NormalChat("오필리아", 1, "아까 말 안해둔게 있는데, 전환의 문자는 스페이스바야! 잘 기억해둬!"));
		standing12.SetActive(false);

		standing13.SetActive(true); // Aris_angry
		yield return StartCoroutine(NormalChat("아리스", 1, "마구마구 전환하지 말라고 오필리아!"));
		standing13.SetActive(false);

		standing14.SetActive(true); // Aris_normal
		yield return StartCoroutine(NormalChat("아리스", 1, "그리고 텔레파시로 자주 연락하고!"));
		standing14.SetActive(false);

		standing15.SetActive(true); // Ophelia_complicated
		yield return StartCoroutine(NormalChat("오필리아", 1, "잔소리쟁이.. 알았어!"));
		standing15.SetActive(false);

		standing16.SetActive(true); // Aris_angry
		yield return StartCoroutine(NormalChat("오필리아", 1, "다 들리거든!"));
		standing16.SetActive(false);

		main_camera.GetComponent<Cam_manager_stage3_2_Fail>().StartCoroutine("Now_Game_Start");
		text_canvas.gameObject.SetActive(false);
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
