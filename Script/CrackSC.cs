using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CrackSC : MonoBehaviour
{
    public GameObject crack1;
    public GameObject crack2;
    public GameObject crack3;
    public GameObject crack4;
    public Image crack_whiteout;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator Crack()
    {
        crack1.SetActive(true);
        yield return new WaitForSeconds(0.8f);
        crack2.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        crack3.SetActive(true);
        yield return new WaitForSeconds(0.6f);
        StartCoroutine(FadeIn(crack_whiteout));
        yield return new WaitForSeconds(0.4f);
        crack1.SetActive(false);
        crack2.SetActive(false);
        crack3.SetActive(false);
        crack4.SetActive(true);
        yield return new WaitForSeconds(1f);
        crack4.SetActive(false);
        crack_whiteout.color = new Color(0, 0, 0, 1);
    }
    IEnumerator FadeIn(Image picture)
    {
        float a = 0;
        while (a <= 2)
        {
            picture.color = new Color(1, 1, 1, a);
            a += 0.1f;
            yield return new WaitForSeconds(0.02f);
        }
    }

}
