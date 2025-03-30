using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    // ฟังก์ชัน OnTriggerEnter ถูกเรียกเมื่อมีวัตถุเข้ามาชน
    private void OnTriggerEnter(Collider other)
    {
        // ตรวจสอบว่าผู้เล่นชนเส้นชัย
        if (other.CompareTag("Player"))
        {
            // เปลี่ยนไปยัง Scene ที่ต้องการ เช่น "NextScene"
            SceneManager.LoadScene("End");
        }
    }
}