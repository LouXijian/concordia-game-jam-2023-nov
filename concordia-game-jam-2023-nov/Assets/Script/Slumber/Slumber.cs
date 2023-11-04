using UnityEngine;
using System.Collections;

public class Slumber : MonoBehaviour
{
    public int SlumberLevel;
    public int SlumberLevelMax = 100;
    public HeartbeatSound Sound;
    public int SlumberLevelDamage = 5;
    public PlayerController Player;
    
    private float lastPulseTime = 0f;
    private float pulseInterval = 2f; // You should set this to the interval of your heartbeat sounds.

    void Start()
    {
        Player.OnPlayerMove += WakeningMonster;
        SlumberLevel = SlumberLevelMax;
        // You might need to initialize or get the pulse interval from the Sound instance.
        // pulseInterval = Sound.GetPulseInterval();
        lastPulseTime = Time.time; // Assuming the pulse starts at the beginning.
    }
    
    public void WakeningMonster()
    {
        // Check if the current time is within the interval after the last pulse
        if (Time.time >= lastPulseTime + pulseInterval && !Sound.DetectPulse())
        {
            Debug.Log("Your step is heard!");
            SlumberLevel -= SlumberLevelDamage;

            // Reset the last pulse time
            lastPulseTime = Time.time;

            CheckSlumberStatus();
        }
    }

    private void CheckSlumberStatus()
    {
        if (SlumberLevel <= 60)
        {
            Debug.Log("The monster is waking up!");
        }
        if (SlumberLevel <= 0)
        {
            Debug.Log("Ouch! You woke up the monster!");
        }
    }
}
