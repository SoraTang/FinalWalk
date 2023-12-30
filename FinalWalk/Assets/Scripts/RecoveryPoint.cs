using UnityEngine;

public class RecoveryPoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag=="Cloud")
        {
            CloudController cloudController = other.GetComponent<CloudController>();

            if (cloudController != null)
            {
                // �ָ��ƵĴ�С
                cloudController.RestoreCloudSize();

                // ���ٻָ���
                Destroy(gameObject);
            }
        }
    }
}
