using UnityEngine;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour
{
    public GameObject gameOverPanel; // Assign a UI Panel from the scene to this
    public Text gameOverText; // Assign a UI Text inside the panel to display messages

    public void ShowGameOver(bool win)
    {
        gameOverPanel.SetActive(true);
        if (win)
            gameOverText.text = "Fortune is collected in its slumber. \nYou win!";
        else
            gameOverText.text = "Game Over. \nThe monster wakes up.";
    }
}
