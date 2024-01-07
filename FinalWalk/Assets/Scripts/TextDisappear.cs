using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class TextFadeOut : MonoBehaviour
{
    public Text myText;
    public float fadeDuration = 1f;

    void Start()
    {
        // ��Start�����е���Invoke���ӳ�ִ��FadeOut����
        Invoke("FadeOut", 1f);
    }

    void FadeOut()
    {
        // ����Э����ִ��͸�����𽥽��͵�Ч��
        StartCoroutine(FadeText());
    }

    IEnumerator FadeText()
    {
        // ��ȡ��ʼ��ɫ��͸����
        Color startColor = myText.color;
        float timePassed = 0f;

        while (timePassed < fadeDuration)
        {
            // �����ֵ�������µ�͸����
            float alpha = Mathf.Lerp(startColor.a, 0f, timePassed / fadeDuration);
            myText.color = new Color(startColor.r, startColor.g, startColor.b, alpha);

            // �ȴ�һ֡
            yield return null;

            // ����ʱ��
            timePassed += Time.deltaTime;
        }

        // ͸�����𽥽�����ɺ����ִ�������������������Text���
        myText.gameObject.SetActive(false);
    }
}
