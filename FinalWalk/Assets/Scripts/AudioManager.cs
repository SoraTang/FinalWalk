using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance; // ����ģʽ

    public AudioClip collisionSound1; // ��ͬ��ײ������1
    public AudioClip collisionSound2; // ��ͬ��ײ������2

    private AudioSource audioSource;

    private void Awake()
    {
        // ʵ�ֵ���ģʽ
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        audioSource = GetComponent<AudioSource>();
    }

    public void PlayCollisionSound(int soundIndex)
    {
        // �����������Ų�ͬ����ײ����
        AudioClip selectedSound = (soundIndex == 1) ? collisionSound1 : collisionSound2;

        if (selectedSound != null)
        {
            audioSource.PlayOneShot(selectedSound);
        }
    }
}
