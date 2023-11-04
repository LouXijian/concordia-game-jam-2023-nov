using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slumber : ISlumber
{
    public void WakeningMonster()
    {
        if (!Sound.DetectPulse())
        {
            SlumberLevel -= SlumberLevelDamage;
        }
    }
}
