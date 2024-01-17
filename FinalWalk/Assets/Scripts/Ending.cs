using UnityEngine;
using UnityEngine.UI;

public class Ending : MonoBehaviour
{
    public Image fadeImage;
    public Text displayText;
    public float fadeSpeed = 0.5f;
    public float delayTime = 2f;

    private bool isColliding = false;
    private float currentAlpha = 0f;
    private float timer = 0f;

    private void Update()
    {
        if (isColliding)
        {
            // 逐渐增加图片透明度
            currentAlpha = Mathf.Lerp(currentAlpha, 1f, fadeSpeed * Time.deltaTime);
            fadeImage.color = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, currentAlpha);

            // 倒计时
            timer += Time.deltaTime;

            // 在延迟时间后显示文本
            if (timer >= delayTime)
            {
                displayText.enabled = true;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Cloud"))
        {
            isColliding = true;
        }
    }
}
