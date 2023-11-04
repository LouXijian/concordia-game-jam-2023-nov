using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slumber : MonoBehaviour
{
    public int SlumberLevel;
    public int SlumberLevelMax = 100;
    public ISound Sound;
    public int SlumberLevelDamage = 5;
    public PlayerController Player;
    
    void Start()
    {
        Player.OnPlayerMove += WakeningMonster;
    }
    
    public void WakeningMonster()
    {
        if (!Sound.DetectPulse())
        {
            SlumberLevel -= SlumberLevelDamage;
        }
    }
}
