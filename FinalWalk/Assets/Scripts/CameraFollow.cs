using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;  // 要跟随的目标（云朵）

    public float smoothSpeed = 0.125f;  // 跟随平滑度

    private void LateUpdate()
    {
        if (target != null)
        {
            // 计算新的摄像机位置
            Vector3 desiredPosition = new Vector3(target.position.x, target.position.y, transform.position.z);

            // 使用 SmoothDamp 函数平滑地移动摄像机
            transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        }
    }
}
