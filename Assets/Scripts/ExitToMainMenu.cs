using UnityEngine;
using UnityEngine.SceneManagement; // สำหรับการจัดการฉาก
using UnityEngine.UI; // สำหรับคอมโพเนนต์ Button

public class ExitToMainMenu : MonoBehaviour
{
    [SerializeField] private Button exitToMainButton; // ปุ่มสำหรับกลับไปหน้าหลัก
    [SerializeField] private string mainMenuSceneName = "MainMenu"; // ชื่อฉากหน้าหลัก

    void Start()
    {
        // ตรวจสอบว่าปุ่มถูกกำหนดหรือไม่
        if (exitToMainButton != null)
        {
            // เพิ่มตัวฟังเหตุการณ์เมื่อคลิกปุ่ม
            exitToMainButton.onClick.AddListener(GoToMainMenu);
        }
        else
        {
            Debug.LogError("ปุ่มกลับไปหน้าหลักยังไม่ได้กำหนดใน Inspector!");
        }
    }

    void GoToMainMenu()
    {
        // โหลดฉากหน้าหลัก
        SceneManager.LoadScene(mainMenuSceneName);
        Debug.Log("กลับไปยังฉากหน้าหลัก: " + mainMenuSceneName);
    }

    void OnDestroy()
    {
        // ล้างตัวฟังเหตุการณ์เมื่อวัตถุถูกทำลาย
        if (exitToMainButton != null)
        {
            exitToMainButton.onClick.RemoveListener(GoToMainMenu);
        }
    }
}