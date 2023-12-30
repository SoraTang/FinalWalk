using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    void Update()
    {
        // ��ⰴ�� R ��
        if (Input.GetKeyDown(KeyCode.R))
        {
            // ���¼��ص�ǰ����
            ReloadScene();
        }
    }

    void ReloadScene()
    {
        // ��ȡ��ǰ����������
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // ���¼��ص�ǰ����
        SceneManager.LoadScene(currentSceneIndex);
    }
}
