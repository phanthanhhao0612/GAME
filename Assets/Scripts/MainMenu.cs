using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void OnPlayButtonClicked()
    {
        // Sử dụng scene index thay vì tên (Scene 1 là Battle)
        SceneManager.LoadScene(1);
    }
}