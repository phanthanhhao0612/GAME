using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    
    private bool isGameOver = false;
    public bool IsGameOver => isGameOver;

    private void Awake()
    {
        // Singleton pattern
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    private void Update()
    {
        if (isGameOver) return;
        
        // Kiểm tra player còn sống không
        PlayerHealth playerHealth = FindObjectOfType<PlayerHealth>();
        if (playerHealth == null)
        {
            // Player đã chết
            OnGameOver();
        }
        
        // Kiểm tra có quái nào còn sống không
        EnemyHealth[] enemies = FindObjectsOfType<EnemyHealth>();
        if (enemies.Length == 0)
        {
            // Tất cả quái đã chết
            OnGameWin();
        }
    }

    public void OnGameOver()
    {
        if (isGameOver) return;
        
        isGameOver = true;
        Debug.Log("Game Over - Player Died!");
        
        // Hiển thị UI Game Over
        GameOverUI gameOverUI = FindObjectOfType<GameOverUI>();
        if (gameOverUI != null)
        {
            gameOverUI.ShowGameOver();
        }
        
        // Dừng time (optional)
        Time.timeScale = 0f;
    }

    public void OnGameWin()
    {
        if (isGameOver) return;
        
        isGameOver = true;
        Debug.Log("Game Win - All enemies defeated!");
        
        // Hiển thị UI Win
        GameOverUI gameOverUI = FindObjectOfType<GameOverUI>();
        if (gameOverUI != null)
        {
            gameOverUI.ShowGameWin();
        }
        
        // Dừng time (optional)
        Time.timeScale = 0f;
    }

    public void ReturnToMainMenu()
    {
        // Reset time trước khi chuyển scene
        Time.timeScale = 1f;
        
        // Chuyển về Main Menu (Scene 0)
        SceneManager.LoadScene(0);
    }
}
