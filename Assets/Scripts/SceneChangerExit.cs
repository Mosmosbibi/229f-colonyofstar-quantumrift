using UnityEngine;
using UnityEngine.SceneManagement; // Namespace สำหรับ SceneManager
using UnityEngine.UI;

public class SceneChangerExit : MonoBehaviour  



{
    [SerializeField] private Button changeSceneButton;
    [SerializeField] private string sceneName = "FirsrUXUI";

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
        SceneManager.LoadScene("FirsrUXUI"); // ใช้ SceneManager โดยตรง
    }

    void OnDestroy()
    {
        if (changeSceneButton != null)
        {
            changeSceneButton.onClick.RemoveListener(ChangeScene);
        }
    }
}