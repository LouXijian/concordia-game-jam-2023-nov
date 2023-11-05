using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    public Text messageText;
    

    private void Start()
    {
        // Initially hide the game over panel
        gameObject.SetActive(false);
    }

    public void ShowGameOver(bool didWin)
    {
        gameObject.SetActive(true);

        if (didWin)
        {
            messageText.text = "Congratulations! You collected all the coins!";
        }
        else
        {
            messageText.text = "Game Over! You woke up the monster!";
        }
    }

    
}
