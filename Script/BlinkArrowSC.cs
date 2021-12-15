using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlinkArrowSC : MonoBehaviour
{
    float time;
    public GameObject ChatArrow;


    private void Start()
    {
        ChatArrow.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    { 
        if (time < 1f)
        {
            GetComponent<Image>().color = new Color(1, 1, 1, 1 - time);
        }
        else
        {
            GetComponent<Image>().color = new Color(1, 1, 1, time - 1); // 완전히 투명해지게 하기 위해
            if (time > 2f)
            {
                time = 0;
            }
        }

        time += Time.deltaTime;

    }

    public void turnOn()
    {
        time = 0;
        ChatArrow.SetActive(true);
    }

    public void turnOff()
    {
        ChatArrow.SetActive(false);
    }
}
