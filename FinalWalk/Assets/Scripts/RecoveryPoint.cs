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
                // 恢复云的大小
                cloudController.RestoreCloudSize();

                // 销毁恢复点
                Destroy(gameObject);
            }
        }
    }
}
