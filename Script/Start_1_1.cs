using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Start_1_1 : MonoBehaviour
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
		
		yield return StartCoroutine(NormalChat("나레이션", 0, "음.. 어디서 부터 얘기를 해야할까?\n 내가 인간계에 떨어졌을때 부터 시작할까?"));
        yield return StartCoroutine(NormalChat("나레이션", 0, "아니면, 그 무녀의 집에 살고 있을때?"));
        yield return StartCoroutine(NormalChat("나레이션", 0, "아니야. 우연치 않게 휘말린 그 마법사가 꼬맹이 시절 학교에 있었을 때 이야기부터 하는게 좋겠다.\n"));
		yield return StartCoroutine(NormalChat("나레이션", 0, "어느 산속에 있는 숲속 마을, 그곳에 작은 학교에 있었던 꼬마 마법사 아리스의 이야기를 시작 해볼까?\n"));


		StartCoroutine(FadeOut_Black(background1)); // 페이드 아웃 ->씬전환*/

		
		yield return new WaitForSeconds(0.8f);
		text_canvas.gameObject.SetActive(false);
		
		main_camera.GetComponent<Cam_manager_stage1>().StartCoroutine("Show_Night_Coroutine");

		yield return new WaitForSeconds(10f);
		text_canvas.gameObject.SetActive(true);
		standing1.SetActive(true); // Teacher_angry.png
        yield return StartCoroutine(NormalChat("학원장", 2, "아리스..! 아리스! 너 이 녀석!"));
        standing1.SetActive(false);
        standing2.SetActive(true); // Aris_wakeup_normal
		yield return StartCoroutine(NormalChat("아리스", 1, "으에에...."));
        standing2.SetActive(false);
        standing3.SetActive(true); // Aris_surprise normal
		yield return StartCoroutine(NormalChat("아리스", 1, "헉!"));
		standing3.SetActive(false);
		standing4.SetActive(true); // Teach_angry.png
		yield return StartCoroutine(NormalChat("학원장", 2, "너 이녀석.. 어디갔나 했더니 수업을 땡땡이 치고 태평하게 자고 있어!?"));
		standing4.SetActive(false);
		standing5.SetActive(true); // Aris_pretend to be indifferent normal
		yield return StartCoroutine(NormalChat("아리스", 1, "아니.. 그게.. 에헤헤."));
		standing5.SetActive(false);
		standing6.SetActive(true); // Teacher_sigh.png
		yield return StartCoroutine(NormalChat("학원장", 2, "오늘 하도 잠잠해서 별일 없이 지나가나 했다.."));
		standing6.SetActive(false);
		standing7.SetActive(true); // Teacher_danhobak.png
		yield return StartCoroutine(NormalChat("학원장", 2, "오늘 수업 땡땡이 친 벌로 다음 수업 준비를 돕도록 해."));
		standing7.SetActive(false);
		standing8.SetActive(true); // Aris_pretend to be indifferent normal
		yield return StartCoroutine(NormalChat("아리스", 1, "그 정도로 봐주신다면 저야 감사하죠 헤헤"));
		standing8.SetActive(false);
		standing9.SetActive(true); // Teacher_danhobak
		yield return StartCoroutine(NormalChat("학원장", 2, "오늘 밤에 산에 올라가서 달맞이 꽃을 개화시킨 상태로 가져올 것."));
		standing9.SetActive(false);
		standing10.SetActive(true); // Aris_surprise_normal
		yield return StartCoroutine(NormalChat("아리스", 1, "밤에 산에 올라가서 캐라구요? 너무해요!"));
		standing10.SetActive(false);
		standing11.SetActive(true); // Teacher_smile
		yield return StartCoroutine(NormalChat("학원장", 2, "봉사활동 일주일 할래? 아니면 오늘 밤에 가서 몇송이 채취 해올래?"));
		standing11.SetActive(false);
		standing12.SetActive(true); // Aris_pretned to be indifferent normal
		yield return StartCoroutine(NormalChat("아리스", 1, "당장 몇송이 채취해올게요!"));
		standing12.SetActive(false);

		
		standing13.SetActive(true); // Aris_Elation normal
		yield return StartCoroutine(NormalChat("아리스", 1, "이동 주문 문자는 위, 아래, 왼쪽, 오른쪽으로 조작할 수 있어"));
		standing13.SetActive(false);
		standing14.SetActive(true); // Aris_Elation normal
		yield return StartCoroutine(NormalChat("아리스", 1, "물체에 대한 상호작용 마법의 문자는 Z야"));
		standing14.SetActive(false);
		standing15.SetActive(true); // Aris_Elation normal
		yield return StartCoroutine(NormalChat("아리스", 1, "혹시나 볼일이 있으면 마법의 문자 ESC를 사용하면 돼."));
		standing15.SetActive(false);
		main_camera.GetComponent<Cam_manager_stage1>().StartCoroutine("Now_Game_Start");
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
