using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Start_3_2_Success_real : MonoBehaviour
{
	private GameObject main_camera;
	private GameObject text_canvas;
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
	public GameObject standing17;
	public GameObject standing18;
	public GameObject standing19;

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
		StartCoroutine(FadeOut_Black(background1)); // 페이드 아웃 ->씬전환*/
		text_canvas.SetActive(false);
		main_camera.GetComponent<Cam_manager_stage3_2_Success>().StartCoroutine("Show_Night_Coroutine");
		yield return new WaitForSeconds(10f);
		text_canvas.SetActive(true);

		standing1.SetActive(true); // Ophelia_Surprise
		yield return StartCoroutine(NormalChat("오필리아",1,"아! 저기 물약이 있어!"));
		standing1.SetActive(false);

		standing2.SetActive(true); // Ophelia_smile
		yield return StartCoroutine(NormalChat("오필리아", 1, "뜸 들일 필요 없지 간..!!"));
		standing2.SetActive(false);

		standing3.SetActive(true); // Aris_surprise
		yield return StartCoroutine(NormalChat("아리스", 1, "자.. 잠깐 기다려!"));
		standing3.SetActive(false);

		standing4.SetActive(true); // Ophelia_Surprise
		yield return StartCoroutine(NormalChat("오필리아", 1, "깜짝이야!!"));
		standing4.SetActive(false);

		standing5.SetActive(true); // Ophelia_Complicated
		yield return StartCoroutine(NormalChat("오필리아", 1, "뭐.. 이상한 거라도 봤어?"));
		standing5.SetActive(false);

		standing6.SetActive(true); // Aris_normal
		yield return StartCoroutine(NormalChat("아리스", 1, "저쪽에 지나갈 수 있을 것 같아."));
		standing6.SetActive(false);

		standing7.SetActive(true); // Ophelia_pretend
		yield return StartCoroutine(NormalChat("오필리아", 1, "저쪽엔 그냥 벽뿐인데..?"));
		standing7.SetActive(false);

		standing8.SetActive(true); // Aris_Elation
		yield return StartCoroutine(NormalChat("아리스", 1, "잔말 말고 기다려봐!"));
		standing8.SetActive(false);

		standing9.SetActive(true); // Ophelia_complicated
		yield return StartCoroutine(NormalChat("오필리아", 1, "알았어!"));
		standing9.SetActive(false);

		standing10.SetActive(true); // Aris_angry
		yield return StartCoroutine(NormalChat("아리스", 1, "벽 부수지말고!!"));
		standing10.SetActive(false);

		standing11.SetActive(true); // Ophelia_angry
		yield return StartCoroutine(NormalChat("오필리아", 1, "흥! 안심하고 가라고!"));
		standing11.SetActive(false);

		text_canvas.SetActive(false);
		main_camera.GetComponent<Cam_manager_stage3_2_Success>().StartCoroutine("Now_Game_Start");
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
