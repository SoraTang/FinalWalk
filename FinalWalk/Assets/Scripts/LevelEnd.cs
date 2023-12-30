using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEnd : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Cloud"))
        {
            // 在这里执行玩家到达终点时的操作
            Debug.Log("Level Complete!");

            // 例如，加载下一个关卡，你需要确保在Build Settings中设置了相应的场景顺序
            LoadNextLevel();
        }
    }

    void LoadNextLevel()
    {
        // 获取当前场景的索引
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // 加载下一个场景，如果没有下一个场景，可以在Build Settings中设置相应的场景顺序
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
}
