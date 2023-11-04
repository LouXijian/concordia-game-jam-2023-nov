using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HeartbeatSound : MonoBehaviour
{
    [HideInInspector]
    public List<float> PulseList;
    public float PulseInterfal = 0.5f;
    public float MusicLength = 100f;
    public float RandomLevel = 0.5f;
    private float m_HeartBeatStartTime;

    void Start()
    {
        for (int i = 0; i * PulseInterfal < MusicLength; i++)
        {
            PulseList.Add(i * PulseInterfal);
            if (Random.Range(0f, 1f) > RandomLevel)
            {
                PulseList.Add(Random.Range(0f, MusicLength));
            }
        }
        m_HeartBeatStartTime = Time.time;
    }

    public bool DetectPulse()
    {
        var currentTime = Time.time;
        return PulseList.Any(pulse => pulse == currentTime - m_HeartBeatStartTime);
    }
}