using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(ParticleSystem))]
public class Timer : MonoBehaviour
{
    float startingPosition;
    [SerializeField] float timeToBurn = 5f;
    [SerializeField] float fireVector;
    float timeFactor;
    ParticleSystem ps;

    float reloadDelay = 2.5f;
    [SerializeField] AudioClip crashSound;
    [SerializeField] ParticleSystem crashParticles;

    AudioSource audioSource;

    bool isTransitioning = false;

    // Start is called before the first frame update
    void Start()
    {
        ParticleSystem ps = GetComponent<ParticleSystem>();
        var em = ps.emission;
        em.enabled = true;
        
        startingPosition = 0f; //need to change to: get starting position of flames
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ParticleSystem ps = GetComponent<ParticleSystem>();
        var em = ps.emission;

        //Time.time / timeToBurn = value from 0 to 1
        timeFactor = Time.time / timeToBurn;

        float offset = fireVector * timeFactor;
        em.rateOverTime = startingPosition + offset; //need to change to: change position of flames

        if (timeFactor >= 1)
            {
                if (!isTransitioning)
                {
                    StartCrashSequence();
                }
            }
    }

    void StartCrashSequence()
    {
        isTransitioning = true;
        audioSource.Stop();
        GetComponent<Movement>().enabled = false;
        crashParticles.Play();
        audioSource.PlayOneShot(crashSound);
        Invoke("ReloadLevel", reloadDelay);
    }

    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        //Gets current scene Index.
        SceneManager.LoadScene(currentSceneIndex);
        //Loads current scene Index
    }
}

//I have no idea how to fix this
//The goal would be to set teh book on fire slowlyby increasing the emission rate
