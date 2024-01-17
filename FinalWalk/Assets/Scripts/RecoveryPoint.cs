using UnityEngine;

public class RecoveryPoint : MonoBehaviour
{
    public GameObject explosionPrefab; // ��ըЧ����Ԥ����
    public float explosionDuration = 2f; // ��ըЧ������ʱ��

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Cloud")
        {
            CloudController cloudController = other.GetComponent<CloudController>();

            if (cloudController != null)
            {
                // ���ٻָ���
                Destroy(gameObject, explosionDuration);
                AudioManager.instance.PlayCollisionSound(2);
                // ��ʾ��ըЧ��
                ShowExplosionEffect();

                // �ָ��ƵĴ�С
                cloudController.RestoreCloudSize();


            }
        }
    }

    private void ShowExplosionEffect()
    {
        // ����б�ըЧ��Ԥ����
        if (explosionPrefab != null)
        {
            // ������ըЧ����ʵ��
            GameObject explosionObject = Instantiate(explosionPrefab, transform.position, Quaternion.identity);

            // ��һ��ʱ������ٱ�ըЧ����ʵ��
            Destroy(explosionObject, explosionDuration);
        }
    }
}
