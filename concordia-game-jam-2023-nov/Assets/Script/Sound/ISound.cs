using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ISound
{
    public List<float> PulseList;
    
    public abstract bool DetectPulse();
}
