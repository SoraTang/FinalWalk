using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance; // 单例模式

    public AudioClip collisionSound1; // 不同碰撞的声音1
    public AudioClip collisionSound2; // 不同碰撞的声音2

    private AudioSource audioSource;

    private void Awake()
    {
        // 实现单例模式
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
        // 根据索引播放不同的碰撞声音
        AudioClip selectedSound = (soundIndex == 1) ? collisionSound1 : collisionSound2;

        if (selectedSound != null)
        {
            audioSource.PlayOneShot(selectedSound);
        }
    }
}
