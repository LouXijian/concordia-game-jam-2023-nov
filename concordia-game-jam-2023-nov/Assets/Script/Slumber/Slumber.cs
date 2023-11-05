using UnityEngine;
using System.Collections;

public class Slumber : MonoBehaviour
{
    public int SlumberLevel;
    public int SlumberLevelMax = 100;
    public HeartbeatSound Sound;
    public int SlumberLevelDamage = 5;
    public PlayerController Player;
    public GameOverController gameOverController; // add new component for craetion of gameOverScreen
    private Animator m_Animator;

    void Start()
    {
        Player.OnPlayerMove += WakeningMonster;
        SlumberLevel = SlumberLevelMax;
        m_Animator = GetComponent<Animator>();
    }

    public void WakeningMonster()
    {
        if (!Sound.PlayerDetectPulse())
        {
            Debug.Log("Your step is heard!");
            SlumberLevel -= SlumberLevelDamage;
            if (SlumberLevel <= 40)
            {
                m_Animator.SetTrigger("ClosedToHalfOpen");
                Debug.Log("The monster is waking up!");
            }

            if (SlumberLevel <= 0)
            {
                m_Animator.SetTrigger("HalfOpenToOpen");
                Debug.Log("Ouch! You woke up the monster!");
                gameOverController.ShowGameOver(false);  // false indicates a loss

            }
        }
    }
}
