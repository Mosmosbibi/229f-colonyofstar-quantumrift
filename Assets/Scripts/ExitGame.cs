using UnityEngine;
using UnityEngine.UI; // จำเป็นสำหรับคอมโพเนนต์ Button

public class ExitGame : MonoBehaviour
{
    [SerializeField] private Button exitButton; // กำหนดปุ่มของคุณใน Inspector

    void Start()
    {
        // ตรวจสอบว่าปุ่มถูกกำหนดหรือไม่
        if (exitButton != null)
        {
            // เพิ่มตัวฟังเหตุการณ์เมื่อคลิกปุ่ม
            exitButton.onClick.AddListener(Exit);
        }
        else
        {
            Debug.LogError("ปุ่มออกเกมยังไม่ได้ถูกกำหนดใน Inspector!");
        }
    }

    void Exit()
    {
        // ออกจากเกม
        Application.Quit();
        
        // ถ้าทดสอบใน Editor จะแสดงข้อความนี้ใน Console
#if UNITY_EDITOR
        Debug.Log("ออกจากเกมเรียบร้อยแล้ว (ใน Editor)");
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

    // ล้างตัวฟังเหตุการณ์เมื่อวัตถุถูกทำลาย
    void OnDestroy()
    {
        if (exitButton != null)
        {
            exitButton.onClick.RemoveListener(Exit);
        }
    }
}