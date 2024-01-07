using UnityEngine;
using System.Collections;

public class ObjectButton : MonoBehaviour
{
    public Transform targetObject;
    public float moveDistance = 2f; // 移动距离
    public float moveSpeed = 2f; // 移动速度
    public Vector3 moveDirection = Vector3.right; // 移动方向，默认为右方向

    private bool isMoving = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Cloud") && !isMoving)
        {
            // 触发移动效果
            MoveObject();
        }
    }

    private void MoveObject()
    {
        isMoving = true;
        StartCoroutine(MoveSmoothly());
    }

    private IEnumerator MoveSmoothly()
    {
        float elapsedTime = 0f;
        Vector3 startingPosition = targetObject.position;
        Vector3 endPosition = startingPosition + moveDistance * moveDirection; // 计算终点位置

        // 移动到目标位置
        while (elapsedTime < 1f)
        {
            targetObject.position = Vector3.Lerp(startingPosition, endPosition, elapsedTime);
            elapsedTime += Time.deltaTime * moveSpeed;
            yield return null;
        }

        // 移动完成后，等待一段时间
        yield return new WaitForSeconds(1f);

        // 缓慢回到原始位置
        elapsedTime = 0f;
        while (elapsedTime < 1f)
        {
            targetObject.position = Vector3.Lerp(endPosition, startingPosition, elapsedTime);
            elapsedTime += Time.deltaTime * moveSpeed;
            yield return null;
        }

        // 移动完成后重置标志
        isMoving = false;
    }
}
