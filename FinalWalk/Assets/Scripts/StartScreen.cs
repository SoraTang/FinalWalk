using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour
{
    private bool keyPressed = false;

    void Update()
    {
        // 检测是否有"W", "A", "S", 或 "D"键被按下
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
        {
            keyPressed = true;
        }

        // 如果键被按下，并且已经过了3秒
        if (keyPressed && Time.timeSinceLevelLoad > 8f)
        {
            // 切换到第一个场景（假设第一个场景的 Build Index 为 1）
            SceneManager.LoadScene(1);
        }
    }
}
