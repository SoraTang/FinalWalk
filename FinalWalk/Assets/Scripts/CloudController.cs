using UnityEngine;
using UnityEngine.UI;

public class CloudController : MonoBehaviour
{
    public float moveSpeed = 5f;  // 移动速度
    public float shrinkSpeed = 0.1f;  // 缩小速度
    public float minSize = 0.1f;  // 最小尺寸，小于该尺寸时云朵消失
    public Text restartText; // 对应UI Text对象

    private float initialScalex;
    private float initialScaley;

    private void Start()
    {
        // 保存初始缩放比例
        initialScalex = transform.localScale.x;
        initialScaley = transform.localScale.y;

        // 隐藏重新开始文本
        if (restartText != null)
        {
            restartText.gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0f);
        transform.position += movement * moveSpeed * Time.deltaTime;

        if (horizontalInput < 0)
        {
            FlipCloud(true);
        }
        else if (horizontalInput > 0)
        {
            FlipCloud(false);
        }

        if (movement.magnitude > 0)
        {
            ShrinkCloud();
        }
    }

    private void ShrinkCloud()
    {
        float cloudArea = Mathf.Abs(transform.localScale.x * transform.localScale.y);
        float shrinkRatio = 1 - moveSpeed * shrinkSpeed * Time.deltaTime;

        transform.localScale = new Vector3(
            transform.localScale.x * shrinkRatio,
            transform.localScale.y * shrinkRatio,
            1f
        );

        if (cloudArea <= minSize)
        {
            // 云消失后显示重新开始文本
            if (restartText != null)
            {
                restartText.gameObject.SetActive(true);
            }

            // 销毁云对象
            Destroy(gameObject);
        }
    }

    public void RestoreCloudSize()
    {
        transform.localScale = new Vector3(initialScalex, initialScaley, 1f);
    }

    private void FlipCloud(bool isFacingLeft)
    {
        Vector3 scale = transform.localScale;
        scale.x = isFacingLeft ? Mathf.Abs(scale.x) * -1 : Mathf.Abs(scale.x);
        transform.localScale = scale;
    }
}
