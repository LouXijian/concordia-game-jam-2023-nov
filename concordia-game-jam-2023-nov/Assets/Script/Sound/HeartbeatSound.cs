using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class HeartbeatSound : MonoBehaviour
{
    [HideInInspector]
    public List<float> PulseList;
    public float PulseInterfal = 0.5f;
    public float MusicLength = 100f;
    public float RandomLevel = 0.5f;
    private float m_HeartBeatStartTime;
    private float m_CushionTime = 0.1f;

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
        for (int i = 1; i < PulseList.Count; i++)
        {
            float currentElement = PulseList[i];
            float currentDifference = Math.Abs(Time.time - m_HeartBeatStartTime - currentElement);

            if (currentDifference < m_CushionTime)
            {
                return true;
            }
        }

        return false;
    }
}