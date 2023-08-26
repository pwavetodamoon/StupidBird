using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;
using UnityEngine.SocialPlatforms.Impl;
using System;

public class LogicScript : MonoBehaviour
{
    public int PlayerScore; // Biến lưu điểm người chơi
    public Text TextScore; // Biến dùng connect với Text của UI và cập nhật UI đó ( Tham chiếu )
    public AudioSource ScoreSound;
    public GameObject gameOver;
    public Text HighScore;
    public Text bestScore;
    

    int highscore;
 
    //[ContextMenu("Point")] // Dùng để chạy thử
    public void CalScore() // Hàm CalScore có từ khóa public bởi vì:
                           // Để hàm này có thể gọi và sử dụng ở một script khác
    {
        PlayerScore = PlayerScore + 1; // Tính cập nhật điểm vào PlayerScore

        // (Tham chiếu tới UI đc gán) . thuộc text = Điểm đã tính
        TextScore.text = PlayerScore.ToString();
        ScoreSound.Play();

    }
    public void ResetGame() // Tạo Hàm Reset lại game như ban đầu
    {
        // Sử dụng hàm "LoadScene(truyển tham số)" từ lớp "SceneManager"
        // Hàm "GetActiveScene()" trả về một đối tượng "Scene"
        // Hàm "GetActiveScene()name" còn dùng để gọi cảnh đang hoạt động hiện tại
        SceneManager.LoadScene("StartScene");
    }

    public void GameOver()
    {
        gameOver.SetActive(true); // Function GameOver dùng để Active Scene GameOver
                                  // Mặc định Scene OFF
        SetPoint();
        Time.timeScale = 0;// Hàm này điều chỉnh tốc độ thời gian của toàn bộ trò chơi.
    }
    void SetPoint()
    {
        highscore = PlayerPrefs.GetInt("HighScore", 0);
        if (PlayerScore > highscore)
        {
            highscore = PlayerScore;
            PlayerPrefs.SetInt("HighScore", highscore);
        }
        HighScore.text = "SCORE: " + PlayerScore.ToString();
        bestScore.text = "BEST SCORE: " + highscore.ToString();
    }
    public void ExitGame()
    {
        Application.Quit();
    }

}
