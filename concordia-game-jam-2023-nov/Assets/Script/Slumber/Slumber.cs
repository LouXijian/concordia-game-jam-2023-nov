using UnityEngine;
using System.Collections;
using UnityEngine.Serialization;

public class Slumber : MonoBehaviour
{
    public int SlumberLevelMax = 100;
    public int SlumberLevel = 100;
    public HeartbeatSound Sound;
    public int SlumberLevelDamage = 5;
    public PlayerController Player;
    public GameOverController GameOverController; // add new component for craetion of gameOverScreen
    private Animator m_Animator;
    
    public delegate void SlumberValueChangeHandler();
    public event SlumberValueChangeHandler SlumberValueChange;

    void Start()
    {
        Player.OnPlayerMove += WakeningMonster;
        m_Animator = GetComponent<Animator>();
    }

    public void WakeningMonster()
    {
        if (!Sound.PlayerDetectPulse())
        {
            Debug.Log("Your step is heard!");
            SlumberLevel -= SlumberLevelDamage;
            SlumberValueChange?.Invoke();
            if (SlumberLevel <= 40)
            {
                m_Animator.SetTrigger("ClosedToHalfOpen");
                Debug.Log("The monster is waking up!");
            }

            if (SlumberLevel <= 0)
            {
                m_Animator.SetTrigger("HalfOpenToOpen");
                Debug.Log("Ouch! You woke up the monster!");
                GameOverController.ShowGameOver(false);  // false indicates a loss
                Player.enabled = false;
            }
        }
    }
}
