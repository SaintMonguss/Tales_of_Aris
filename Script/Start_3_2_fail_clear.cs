using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Start_3_2_fail_clear : MonoBehaviour
{
	private GameObject main_camera;
	private GameObject text_canvas;
	private GameObject text_canvas2;
	private GameObject text_canvas3;
	private GameObject text_canvas4;
	private GameObject text_canvas5;
	private GameObject target;
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

	private GameObject destroy_object;
	private GameObject destroy_object2;

	//필요한 스탠딩 cg, 배경 갯수만큼 풀어서 사용할 것

	CrackSC CrackSC;
	bool finished = false; // 다 출력후에 엔터를 받기 위함
    public string writerText = "";
    bool isButtonClicked = false;
    

    //public List<KeyCode> skipButton;

    void Start()
    {
        BlinkArrowController = GameObject.Find("Blinker").GetComponent<BlinkArrowSC>(); // blink 타이밍을 위한 변수 받아오기
		destroy_object = GameObject.Find("poition");
		destroy_object2 = GameObject.Find("Last_Breakable");
		text_canvas = GameObject.Find("Canvas");
		target = GameObject.Find("Ophelia");
		CrackSC = GameObject.Find("GameManager").GetComponent<CrackSC>(); // 크랙 타이밍을 위한 스크립트 연결
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
		text_canvas.gameObject.SetActive(true);
		standing1.SetActive(true); // Ophelia_Surprise
		yield return StartCoroutine(NormalChat("오필리아", 1, "아! 저기 물약이 있어!"));
		standing1.SetActive(false);
		standing2.SetActive(true); // Ophelia_Smile
		yield return StartCoroutine(NormalChat("오필리아", 1, "뜸 들일 필요 없지!"));
		standing2.SetActive(false);

		text_canvas.gameObject.SetActive(false);
		target.gameObject.GetComponent<Moving_object_Op>().go_right();
		yield return new WaitForSeconds(1f);
		target.gameObject.GetComponent<Moving_object_Op>().go_right();
		yield return new WaitForSeconds(1f);
		target.gameObject.GetComponent<Moving_object_Op>().go_punch();
		destroy_object.SetActive(false);
		destroy_object2.SetActive(false);
		yield return new WaitForSeconds(2f);

		text_canvas.gameObject.SetActive(true);
		standing3.SetActive(true); // Aris(...)
		yield return StartCoroutine(NormalChat("아리스", 1, "......."));
		standing3.SetActive(false);

		standing4.SetActive(true); // Ophelia_pretend to be
		yield return StartCoroutine(NormalChat("오필리아", 1, "엣...."));
		standing4.SetActive(false);

		standing5.SetActive(true); // Ophelia_pretend to be
		yield return StartCoroutine(NormalChat("아리스", 1, "오필리~아!!!!"));
		standing5.SetActive(false);

		yield return StartCoroutine(CrackSC.Crack()); // 크랙 함수 호출
		StartCoroutine(FadeOut(fadeout_background)); // 페이드 아웃 ->씬전환
		yield return new WaitForSeconds(0.80f);
		SceneManager.LoadScene("Stage3-2_Success");

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
