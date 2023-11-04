using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class HeartbeatSound : MonoBehaviour
{
    public AudioSource AudioSource;

    [HideInInspector]
    public List<float> PulseList;
    public float PulseInterval;
    public float MusicLength;
    public float RandomLevel;
    
    private float m_HeartBeatStartTime;
    private float m_CushionTime = 0.1f;

    void Start()
    {
        PulseList = new List<float>();
        PulseList.Add(0); // First pulse at time 0
        for (int i = 1; i * PulseInterval < MusicLength; i++)
        {
            PulseList.Add(i * PulseInterval);
            if (Random.Range(0f, 1f) > RandomLevel)
            {
                PulseList.Add(Random.Range(0f, MusicLength));
            }
        }

        PulseList.Sort();

        m_HeartBeatStartTime = Time.time;
    }

    void Update()
    {
        if (DetectPulse())
        {
            AudioSource.Play();
        }
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