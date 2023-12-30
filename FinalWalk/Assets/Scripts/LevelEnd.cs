using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEnd : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Cloud"))
        {
            // ������ִ����ҵ����յ�ʱ�Ĳ���
            Debug.Log("Level Complete!");

            // ���磬������һ���ؿ�������Ҫȷ����Build Settings����������Ӧ�ĳ���˳��
            LoadNextLevel();
        }
    }

    void LoadNextLevel()
    {
        // ��ȡ��ǰ����������
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // ������һ�����������û����һ��������������Build Settings��������Ӧ�ĳ���˳��
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
}
