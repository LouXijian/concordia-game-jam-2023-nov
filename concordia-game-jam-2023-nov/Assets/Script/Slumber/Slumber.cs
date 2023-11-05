using UnityEngine;
using System.Collections;

public class Slumber : MonoBehaviour
{
    public int SlumberLevel;
    public int SlumberLevelMax = 100;
    public HeartbeatSound Sound;
    public int SlumberLevelDamage = 5;
    public PlayerController Player;
    private Animator m_Animator;
    //public GameObject GameOverPanel;

    private float m_PulseInterval = 2f; // You should set this to the interval of your heartbeat sounds.

    void Start()
    {
        Player.OnPlayerMove += WakeningMonster;
        SlumberLevel = SlumberLevelMax;
        m_Animator = GetComponent<Animator>(); // Initialize the reference
    }

    public void WakeningMonster()
    {
        if (!Sound.DetectPulse())
        {
            Debug.Log("Your step is heard!");
            SlumberLevel -= SlumberLevelDamage;
            if (SlumberLevel <= 60)
            {
                m_Animator.SetTrigger("ClosedToHalfOpen");
                Debug.Log("The monster is waking up!");

            }

            if (SlumberLevel <= 0)
            {
                m_Animator.SetTrigger("HalfOpenToOpen");
                Debug.Log("Ouch! You woke up the monster!");
                // game over when the monster wakes up
                GameOverPanel.ShowGameOver(false);
            }
        }
    }
}
