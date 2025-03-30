using UnityEngine;
using UnityEngine.SceneManagement; // Namespace สำหรับ SceneManager
using UnityEngine.UI;

public class SceneChangerMenu1 : MonoBehaviour
{
    [SerializeField] private Button changeSceneButton;
    [SerializeField] private string sceneName = "NextScene";

    void Start()
    {
        if (changeSceneButton != null)
        {
            changeSceneButton.onClick.AddListener(ChangeScene);
        }
        else
        {
            Debug.LogError("ปุ่มเปลี่ยนฉากยังไม่ได้ถูกกำหนดใน Inspector!");
        }
    }

    void ChangeScene()
    {
        SceneManager.LoadScene(sceneName); // ใช้ SceneManager โดยตรง
    }

    void OnDestroy()
    {
        if (changeSceneButton != null)
        {
            changeSceneButton.onClick.RemoveListener(ChangeScene);
        }
    }
}