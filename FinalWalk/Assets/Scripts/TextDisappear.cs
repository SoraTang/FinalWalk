using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class TextFadeOut : MonoBehaviour
{
    public Text myText;
    public float fadeDuration = 1f;

    void Start()
    {
        // 在Start方法中调用Invoke来延迟执行FadeOut方法
        Invoke("FadeOut", 1f);
    }

    void FadeOut()
    {
        // 启动协程来执行透明度逐渐降低的效果
        StartCoroutine(FadeText());
    }

    IEnumerator FadeText()
    {
        // 获取初始颜色和透明度
        Color startColor = myText.color;
        float timePassed = 0f;

        while (timePassed < fadeDuration)
        {
            // 计算插值并设置新的透明度
            float alpha = Mathf.Lerp(startColor.a, 0f, timePassed / fadeDuration);
            myText.color = new Color(startColor.r, startColor.g, startColor.b, alpha);

            // 等待一帧
            yield return null;

            // 更新时间
            timePassed += Time.deltaTime;
        }

        // 透明度逐渐降低完成后可以执行其他操作，比如禁用Text组件
        myText.gameObject.SetActive(false);
    }
}
