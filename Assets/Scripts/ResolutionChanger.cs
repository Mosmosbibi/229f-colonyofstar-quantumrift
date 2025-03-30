using UnityEngine;
using UnityEngine.UI; // สำหรับคอมโพเนนต์ Button

public class ResolutionChanger : MonoBehaviour
{
    [SerializeField] private Button resolution800x600Button; // ปุ่มสำหรับ 800x600
    [SerializeField] private Button resolution1280x720Button; // ปุ่มสำหรับ 1280x720
    [SerializeField] private Button resolution1920x1080Button; // ปุ่มสำหรับ 1920x1080

    void Start()
    {
        // ตรวจสอบและเพิ่มตัวฟังเหตุการณ์ให้ปุ่มแต่ละปุ่ม
        if (resolution800x600Button != null)
        {
            resolution800x600Button.onClick.AddListener(() => SetResolution(800, 600));
        }
        else
        {
            Debug.LogError("ปุ่ม 800x600 ยังไม่ได้กำหนดใน Inspector!");
        }

        if (resolution1280x720Button != null)
        {
            resolution1280x720Button.onClick.AddListener(() => SetResolution(1280, 720));
        }
        else
        {
            Debug.LogError("ปุ่ม 1280x720 ยังไม่ได้กำหนดใน Inspector!");
        }

        if (resolution1920x1080Button != null)
        {
            resolution1920x1080Button.onClick.AddListener(() => SetResolution(1920, 1080));
        }
        else
        {
            Debug.LogError("ปุ่ม 1920x1080 ยังไม่ได้กำหนดใน Inspector!");
        }
    }

    void SetResolution(int width, int height)
    {
        // ตั้งค่าความละเอียดหน้าจอ (แบบ Fullscreen เป็นค่าเริ่มต้น)
        Screen.SetResolution(width, height, true);
        Debug.Log($"เปลี่ยนความละเอียดเป็น {width}x{height}");
    }

    void OnDestroy()
    {
        // ล้างตัวฟังเหตุการณ์เมื่อวัตถุถูกทำลาย
        if (resolution800x600Button != null)
        {
            resolution800x600Button.onClick.RemoveAllListeners();
        }
        if (resolution1280x720Button != null)
        {
            resolution1280x720Button.onClick.RemoveAllListeners();
        }
        if (resolution1920x1080Button != null)
        {
            resolution1920x1080Button.onClick.RemoveAllListeners();
        }
    }
}