using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class HeartbeatSound : MonoBehaviour
{
    public AudioClip HeartbeatClip; // Assign this in the inspector
    private AudioSource audioSource; // AudioSource component to play the sound

    [HideInInspector]
    public List<float> PulseList;
    public float PulseInterval = 2f; // Please note the typo correction: PulseInterfal -> PulseInterval
    public float MusicLength = 100f;
    public float RandomLevel = 1f;
    private float m_HeartBeatStartTime;
    private float m_CushionTime = 0.1f;
    public PlayerController Player;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = HeartbeatClip;
        audioSource.playOnAwake = false;

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
        PulseList.Sort(); // Ensure the list is sorted after adding random pulses

        m_HeartBeatStartTime = Time.time;

        Player.OnPlayerMove += PlayStepSound;
    }

    void Update()
    {
        if(DetectPulse())
        {
            audioSource.Play();
        }
    }

    void PlayStepSound()
    {
        Debug.Log("Step sound is played.");
    }

    public bool DetectPulse()
    {
        float timeSinceStart = Time.time - m_HeartBeatStartTime;
        // Check if the time since start is within any pulse window
        for (int i = 0; i < PulseList.Count; i++)
        {
            float pulseTime = PulseList[i];
            if (timeSinceStart >= pulseTime - m_CushionTime && timeSinceStart <= pulseTime + m_CushionTime)
            {
                return true;
            }
        }
        return false;
    }
}
