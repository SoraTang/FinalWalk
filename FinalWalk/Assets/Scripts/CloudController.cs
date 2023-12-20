using UnityEngine;

public class CloudController : MonoBehaviour
{
    public float moveSpeed = 5f;  // �ƶ��ٶ�
    public float shrinkSpeed = 0.1f;  // ��С�ٶ�
    public float minSize = 0.1f;  // ��С�ߴ磬С�ڸóߴ�ʱ�ƶ���ʧ

    private float initialScale; // ��ʼ���ű���

    private void Start()
    {

        // �����ʼ���ű�����ȡ x �� y �н�С��һ����
        initialScale = Mathf.Min(transform.localScale.x, transform.localScale.y);
    }

    private void Update()
    {
        // ��ȡ�������
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // �ƶ��ƶ�
        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0f);
        transform.position += movement * moveSpeed * Time.deltaTime;

        // ����ˮƽ���뷽��ת�ƶ�
        if (horizontalInput < 0)
        {
            FlipCloud(true);
        }
        else if (horizontalInput > 0)
        {
            FlipCloud(false);
        }

        // ֻ�����ƶ���ʱ�����С�ƶ�
        if (movement.magnitude > 0)
        {
            ShrinkCloud();
        }
    }

    private void ShrinkCloud()
    {
        // ���㵱ǰ�ƶ�����
        float cloudArea = Mathf.Abs(transform.localScale.x * transform.localScale.y);

        // ����ȱ�����С�ı���
        float shrinkRatio = 1 - moveSpeed * shrinkSpeed * Time.deltaTime;

        // Ӧ�õȱ�����С��ÿ����
        transform.localScale = new Vector3(
            transform.localScale.x * shrinkRatio,
            transform.localScale.y * shrinkRatio,
            1f
        );

        // ����ƶ�С����С�ߴ磬���ٶ���
        if (cloudArea <= minSize)
        {
            Destroy(gameObject);
        }
    }

    private void FlipCloud(bool isFacingLeft)
    {
        // ���ݷ���ת�ƶ�
        Vector3 scale = transform.localScale;
        scale.x = isFacingLeft ? Mathf.Abs(scale.x) * -1 : Mathf.Abs(scale.x);
        transform.localScale = scale;
    }
}
