using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    [SerializeField] private Transform target; // อ้างอิงถึง GameObject ของผู้เล่น
    [SerializeField] private float distance = 5f; // ระยะห่างจากผู้เล่น
    [SerializeField] private float height = 2f; // ความสูงจากผู้เล่น
    [SerializeField] private float mouseSensitivity = 100f; // ความไวเมาส์
    [SerializeField] private float minVerticalAngle = -30f; // มุมต่ำสุด (ลง)
    [SerializeField] private float maxVerticalAngle = 60f; // มุมสูงสุด (ขึ้น)

    private float currentX = 0f; // การหมุนแนวนอน (รอบแกน Y)
    private float currentY = 0f; // การหมุนแนวตั้ง (รอบแกน X)

    void Start()
    {
        if (target == null)
        {
            Debug.LogError("Target (ผู้เล่น) ไม่ได้ถูกกำหนดใน Inspector!");
            return;
        }
        // ซ่อนและล็อกเคอร์เซอร์
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void LateUpdate()
    {
        if (target == null) return;

        // รับอินพุตจากเมาส์
        currentX += Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        currentY -= Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // จำกัดมุมแนวตั้ง
        currentY = Mathf.Clamp(currentY, minVerticalAngle, maxVerticalAngle);

        // แปลงมุมเป็น Quaternion
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);

        // คำนวณตำแหน่งกล้อง
        Vector3 direction = new Vector3(0, 0, -distance); // ระยะห่างจากผู้เล่น
        Vector3 position = target.position + rotation * direction + Vector3.up * height;

        // อัปเดตตำแหน่งและการหมุนของกล้อง
        transform.position = position;
        transform.LookAt(target.position + Vector3.up * height); // มองไปที่ผู้เล่น (ปรับความสูง)
    }

    void OnDestroy()
    {
        // คืนค่าเคอร์เซอร์เมื่อออก
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}