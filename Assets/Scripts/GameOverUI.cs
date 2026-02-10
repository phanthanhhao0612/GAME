using UnityEngine;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private Canvas gameOverCanvas;
    [SerializeField] private Image panelBackground;
    [SerializeField] private Text titleText;
    [SerializeField] private Button returnButton;

    private void Start()
    {
        if (gameOverCanvas != null)
        {
            gameOverCanvas.enabled = false;
        }
        if (returnButton != null)
        {
            returnButton.onClick.AddListener(OnReturnButtonClicked);
        }
    }

    public void ShowGameOver()
    {
        if (gameOverCanvas != null)
        {
            gameOverCanvas.enabled = true;
            if (titleText != null)
            {
                titleText.text = "GAME OVER";
                titleText.color = Color.red;
            }
        }
    }

    public void ShowGameWin()
    {
        if (gameOverCanvas != null)
        {
            gameOverCanvas.enabled = true;
            if (titleText != null)
            {
                titleText.text = "YOU WIN!";
                titleText.color = Color.green;
            }
        }
    }

    public void OnReturnButtonClicked()
    {
        Debug.Log("Return to Main Menu clicked");
        GameManager.Instance.ReturnToMainMenu();
    }
}
