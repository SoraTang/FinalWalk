using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour
{
    private bool keyPressed = false;

    void Update()
    {
        // ����Ƿ���"W", "A", "S", �� "D"��������
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
        {
            keyPressed = true;
        }

        // ����������£������Ѿ�����3��
        if (keyPressed && Time.timeSinceLevelLoad > 8f)
        {
            // �л�����һ�������������һ�������� Build Index Ϊ 1��
            SceneManager.LoadScene(1);
        }
    }
}
