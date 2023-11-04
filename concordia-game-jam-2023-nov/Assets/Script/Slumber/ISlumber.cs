using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ISlumber 
{
    public int SlumberLevel;
    public int SlumberLevelMax = 100;
    public ISound Sound;
    public int SlumberLevelDamage = 5;
}
