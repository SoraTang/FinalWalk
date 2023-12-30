using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    void Update()
    {
        // 检测按下 R 键
        if (Input.GetKeyDown(KeyCode.R))
        {
            // 重新加载当前场景
            ReloadScene();
        }
    }

    void ReloadScene()
    {
        // 获取当前场景的索引
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // 重新加载当前场景
        SceneManager.LoadScene(currentSceneIndex);
    }
}
