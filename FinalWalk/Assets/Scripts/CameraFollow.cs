using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;  // Ҫ�����Ŀ�꣨�ƶ䣩

    public float smoothSpeed = 0.125f;  // ����ƽ����

    private void LateUpdate()
    {
        if (target != null)
        {
            // �����µ������λ��
            Vector3 desiredPosition = new Vector3(target.position.x, target.position.y, transform.position.z);

            // ʹ�� SmoothDamp ����ƽ�����ƶ������
            transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        }
    }
}
