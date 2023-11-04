using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slumber : MonoBehaviour
{
    public int SlumberLevel;
    public int SlumberLevelMax = 100;
    public HeartbeatSound Sound;
    public int SlumberLevelDamage = 5;
    public PlayerController Player;
    
    void Start()
    {
        Player.OnPlayerMove += WakeningMonster;
        SlumberLevel = SlumberLevelMax;
    }
    
    public void WakeningMonster()
    {
        if (!Sound.DetectPulse())
        {
            Debug.Log("Your step is heard!");
            SlumberLevel -= SlumberLevelDamage;
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
}
