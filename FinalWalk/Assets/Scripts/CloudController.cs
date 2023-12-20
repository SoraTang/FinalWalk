using UnityEngine;

public class CloudController : MonoBehaviour
{
    public float moveSpeed = 5f;  // 移动速度
    public float shrinkSpeed = 0.1f;  // 缩小速度
    public float minSize = 0.1f;  // 最小尺寸，小于该尺寸时云朵消失

    private float initialScale; // 初始缩放比例

    private void Start()
    {

        // 保存初始缩放比例（取 x 和 y 中较小的一个）
        initialScale = Mathf.Min(transform.localScale.x, transform.localScale.y);
    }

    private void Update()
    {
        // 获取玩家输入
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // 移动云朵
        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0f);
        transform.position += movement * moveSpeed * Time.deltaTime;

        // 根据水平输入方向翻转云朵
        if (horizontalInput < 0)
        {
            FlipCloud(true);
        }
        else if (horizontalInput > 0)
        {
            FlipCloud(false);
        }

        // 只有在移动的时候才缩小云朵
        if (movement.magnitude > 0)
        {
            ShrinkCloud();
        }
    }

    private void ShrinkCloud()
    {
        // 计算当前云朵的面积
        float cloudArea = Mathf.Abs(transform.localScale.x * transform.localScale.y);

        // 计算等比例缩小的比例
        float shrinkRatio = 1 - moveSpeed * shrinkSpeed * Time.deltaTime;

        // 应用等比例缩小到每个轴
        transform.localScale = new Vector3(
            transform.localScale.x * shrinkRatio,
            transform.localScale.y * shrinkRatio,
            1f
        );

        // 如果云朵小于最小尺寸，销毁对象
        if (cloudArea <= minSize)
        {
            Destroy(gameObject);
        }
    }

    private void FlipCloud(bool isFacingLeft)
    {
        // 根据方向翻转云朵
        Vector3 scale = transform.localScale;
        scale.x = isFacingLeft ? Mathf.Abs(scale.x) * -1 : Mathf.Abs(scale.x);
        transform.localScale = scale;
    }
}
