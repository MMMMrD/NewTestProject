using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeScene : MonoBehaviour
{

    public TMP_Text text;
    private float colorChange = 1;
    private bool upDown = true;
    public float multiply;
    public Image backGround;
    private float alpha = 0;


    void Update()
    {
        if (upDown)
        {
            colorChange -= Time.deltaTime * 0.5f;
            if (colorChange <= 0)
                upDown = false;
        }
        else
        {
            colorChange += Time.deltaTime * 0.5f;
            if (colorChange >= 1)
                upDown = true;
        }
        if (text != null)
            text.alpha = colorChange;
    }

    public void LoadScene()
    {
        StartCoroutine(loadlevel());
    }




    IEnumerator loadlevel()
    //����Э�����ͷ���loadlevel
    {
        //backGround.gameObject.SetActive(true);

        AsyncOperation operation = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        ////���ر�������ֵ +1�ĳ���SampleScene
        operation.allowSceneActivation = false;
        ////�Ȳ�������һ����
        while (!operation.isDone)
        {
            backGround.color = new Color(1, 1, 1, alpha += Time.deltaTime * 4);
            if (alpha >= 1)
            {
                operation.allowSceneActivation = true;
            }
            //    //slider.value = operation.progress;
            //    //operation.progress�����Ͼ�����ֵ
            //    //text.text = operation.progress * 100 + "%";

            //    //if (operation.progress >= 0.9f)
            //    //���ڸ÷������������������Ҫ�ֶ�����ֵ��Ϊ100%
            //    //{
            //    //slider.value = 1;
            //    //text.text = "Press any key";
            //    //    if (Input.anyKeyDown)
            //    //    {
            //    //        operation.allowSceneActivation = true;
            //    //        //�������ⰴť��ʼ������һ����
            //    //    }
            yield return null;
        }


    }


}
