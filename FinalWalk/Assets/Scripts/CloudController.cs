using UnityEngine;
using UnityEngine.UI;

public class CloudController : MonoBehaviour
{
    public float moveSpeed = 5f;  // �ƶ��ٶ�
    public float shrinkSpeed = 0.1f;  // ��С�ٶ�
    public float minSize = 0.1f;  // ��С�ߴ磬С�ڸóߴ�ʱ�ƶ���ʧ
    public Text restartText; // ��ӦUI Text����

    private float initialScalex;
    private float initialScaley;

    private void Start()
    {
        // �����ʼ���ű���
        initialScalex = transform.localScale.x;
        initialScaley = transform.localScale.y;

        // �������¿�ʼ�ı�
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
            // ����ʧ����ʾ���¿�ʼ�ı�
            if (restartText != null)
            {
                restartText.gameObject.SetActive(true);
            }

            // �����ƶ���
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
