using UnityEngine;

public class RecoveryPoint : MonoBehaviour
{
    public GameObject explosionPrefab; // 爆炸效果的预制体
    public float explosionDuration = 2f; // 爆炸效果持续时间

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Cloud")
        {
            CloudController cloudController = other.GetComponent<CloudController>();

            if (cloudController != null)
            {
                // 销毁恢复点
                Destroy(gameObject, explosionDuration);
                AudioManager.instance.PlayCollisionSound(2);
                // 显示爆炸效果
                ShowExplosionEffect();

                // 恢复云的大小
                cloudController.RestoreCloudSize();


            }
        }
    }

    private void ShowExplosionEffect()
    {
        // 如果有爆炸效果预制体
        if (explosionPrefab != null)
        {
            // 创建爆炸效果的实例
            GameObject explosionObject = Instantiate(explosionPrefab, transform.position, Quaternion.identity);

            // 在一定时间后销毁爆炸效果的实例
            Destroy(explosionObject, explosionDuration);
        }
    }
}
