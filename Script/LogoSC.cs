using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogoSC : MonoBehaviour
{
    Color color;

    // Start is called before the first frame update
    void Start()
    {
       StartCoroutine("Fadein");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            SceneChage();
        }
    }

    IEnumerator Fadein() // 로고 페이드 인아웃 함수
    {
        yield return new WaitForSeconds(1f);
        var img = GetComponent<Image>();
        color = img.color;
        color.a = 0;

        while (color.a <= 1)
        {
            color.a += 0.05f;
            img.color = color;
            yield return new WaitForSeconds(0.05f);
        }
        yield return new WaitForSeconds(1f);
        while (color.a >=0)
        {
            color.a -= 0.05f;
            img.color = color;
            yield return new WaitForSeconds(0.05f);
        }
        yield return new WaitForSeconds(0.5f);
        SceneChage();
    }
    void SceneChage() // 씬전환
    {
        SceneManager.LoadScene("MainMenu");
    }
}
