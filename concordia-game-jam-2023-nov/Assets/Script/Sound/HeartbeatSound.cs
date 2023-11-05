using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class HeartbeatSound : MonoBehaviour
{
    public AudioSource AudioSource;

    [HideInInspector]
    public List<float> PulseList;
    public float MusicLength;
    
    float m_PulseInterval = 2f;
    float m_RandomLevel = 1f;
    float m_HeartBeatStartTime;
    float m_CushionTime = 0.4f;
    float m_SoundOffset = 0.4f;

    void Start()
    {
        PulseList = new List<float>();
        PulseList.Add(0); // First pulse at time 0
        for (int i = 1; i * m_PulseInterval < MusicLength; i++)
        {
            PulseList.Add(i * m_PulseInterval);
            if (Random.Range(0f, 1f) > m_RandomLevel)
            {
                PulseList.Add(Random.Range(0f, MusicLength));
            }
        }

        PulseList.Sort();

        m_HeartBeatStartTime = Time.time;
    }

    void Update()
    {
        if (MonsterDetectPulse())
        {
            AudioSource.Play();
        }
    }

    public bool PlayerDetectPulse()
    {
        for (int i = 1; i < PulseList.Count; i++)
        {
            float currentElement = PulseList[i];
            float currentDifference = Math.Abs(Time.time - m_SoundOffset - m_HeartBeatStartTime - currentElement);

            if (currentDifference < m_CushionTime)
            {
                return true;
            }
        }

        return false;
    }
    
    public bool MonsterDetectPulse()
    {
        var currentTime = Time.time;
        for (int i = 1; i < PulseList.Count; i++)
        {
            float currentElement = PulseList[i];
            var currentDifference = Math.Abs(currentTime - m_HeartBeatStartTime - currentElement);

            if (currentDifference < 0.01f)
            {
                return true;
            }
        }

        return false;
    }
}