using UnityEngine;
using UnityEngine.SceneManagement; // สำหรับเปลี่ยนฉาก
using TMPro;

public class CountdownTimer : MonoBehaviour
{
    [SerializeField] private TMP_Text timerText; // แสดงเวลา
    [SerializeField] private TMP_Text resultText; // แสดงผลลัพธ์ (ชนะ/แพ้)
    [SerializeField] private string nextSceneName = "NextScene"; // ชื่อฉากถัดไปเมื่อชนะ
    private float timeRemaining = 80f; // 1 นาที 20 วินาที
    private bool isTimerRunning = false;
    private bool hasReachedFinishLine = false; // ตัวแปรตรวจสอบว่าเข้าเส้นชัยหรือยัง

    void Start()
    {
        if (timerText == null || resultText == null)
        {
            Debug.LogError("TMP_Text สำหรับ timerText หรือ resultText ไม่ได้ถูกกำหนดใน Inspector!");
        }
        else
        {
            isTimerRunning = true;
            resultText.text = ""; // ล้างข้อความผลลัพธ์ตอนเริ่ม
            UpdateTimerDisplay();
        }
    }

    void Update()
    {
        if (isTimerRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                UpdateTimerDisplay();
            }
            else
            {
                // เวลาหมด
                timeRemaining = 0;
                isTimerRunning = false;
                UpdateTimerDisplay();
                CheckGameResult();
            }
        }
    }

    void UpdateTimerDisplay()
    {
        int minutes = Mathf.FloorToInt(timeRemaining / 60);
        int seconds = Mathf.FloorToInt(timeRemaining % 60);
        if (timerText != null)
        {
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }

    // ตรวจสอบผลลัพธ์เมื่อเวลาหมดหรือเข้าเส้นชัย
    void CheckGameResult()
    {
        if (!hasReachedFinishLine)
        {
            // เวลาหมดและยังไม่ถึงเส้นชัย = แพ้
            resultText.text = "You Lose!";
            Debug.Log("แพ้: เวลาหมดก่อนถึงเส้นชัย");
        }
        // ถ้าถึงเส้นชัยก่อนหมดเวลา จะจัดการใน OnTriggerEnter
    }

    // ตรวจจับการเข้าเส้นชัย (ใช้ Trigger Collider)
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Finish") && isTimerRunning)
        {
            // เข้าเส้นชัยก่อนหมดเวลา = ชนะ
            isTimerRunning = false; // หยุดนับเวลา
            hasReachedFinishLine = true;
            resultText.text = "You Win!";
            Debug.Log("ชนะ: เข้าเส้นชัยสำเร็จ!");
            
            // ไปยังฉากถัดไปหลังจาก 2 วินาที (เพื่อให้เห็นข้อความชนะก่อน)
            Invoke("GoToNextScene", 2f);
        }
    }

    void GoToNextScene()
    {
        SceneManager.LoadScene(nextSceneName);
    }

    public void ResetTimer()
    {
        timeRemaining = 80f;
        isTimerRunning = true;
        hasReachedFinishLine = false;
        resultText.text = "";
    }
}