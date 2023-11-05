using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OpeningScreen : MonoBehaviour
{
    private Button m_PlayButton;
    // Start is called before the first frame update
    void Start()
    {
        m_PlayButton = GetComponentInChildren<Button>();
        m_PlayButton.onClick.AddListener(LoadFirstScene);
    }

    // Update is called once per frame
    void LoadFirstScene()
    {
        SceneManager.UnloadScene(SceneManager.GetActiveScene());
        SceneManager.LoadScene("Level 1");
    }
}
