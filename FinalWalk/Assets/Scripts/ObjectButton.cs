using UnityEngine;
using System.Collections;

public class ObjectButton : MonoBehaviour
{
    public Transform targetObject;
    public float moveDistance = 2f; // �ƶ�����
    public float moveSpeed = 2f; // �ƶ��ٶ�
    public Vector3 moveDirection = Vector3.right; // �ƶ�����Ĭ��Ϊ�ҷ���

    private bool isMoving = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Cloud") && !isMoving)
        {
            // �����ƶ�Ч��
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
        Vector3 endPosition = startingPosition + moveDistance * moveDirection; // �����յ�λ��

        // �ƶ���Ŀ��λ��
        while (elapsedTime < 1f)
        {
            targetObject.position = Vector3.Lerp(startingPosition, endPosition, elapsedTime);
            elapsedTime += Time.deltaTime * moveSpeed;
            yield return null;
        }

        // �ƶ���ɺ󣬵ȴ�һ��ʱ��
        yield return new WaitForSeconds(1f);

        // �����ص�ԭʼλ��
        elapsedTime = 0f;
        while (elapsedTime < 1f)
        {
            targetObject.position = Vector3.Lerp(endPosition, startingPosition, elapsedTime);
            elapsedTime += Time.deltaTime * moveSpeed;
            yield return null;
        }

        // �ƶ���ɺ����ñ�־
        isMoving = false;
    }
}
