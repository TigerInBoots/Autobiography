using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

public class Movement : MonoBehaviour
{

    //Tuning Parameters
    [SerializeField] float mainThrust = 1500f;
    [SerializeField] float rotateSpeed = 10f;
    [SerializeField] AudioClip mainFlight;

    [SerializeField] ParticleSystem thrustParticles;

    //CACHE (readability/speed)
    Rigidbody rb;
    AudioSource audioSource;

    //STATE

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

//Processing Methods from here

    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            StartThrusting();
        }

        else
        {
            StopThrusting();
        }
    }

        void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            //rotate left
            ApplyRotation(-rotateSpeed);
        }

        else if (Input.GetKey(KeyCode.D))
        {
            //rotate right
            ApplyRotation(rotateSpeed);
        }
    }

//Logic Methods from here:

    void StartThrusting()
    {
        rb.AddRelativeForce(Vector3.down * mainThrust * Time.deltaTime);

        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(mainFlight);
        }

        if (!thrustParticles.isPlaying)
        {
            thrustParticles.Play();
        }
    }

        void StopThrusting()
    {
        //StartCoroutine(FadeMixerGroup.StartFade(AudioMixer FlippingPages, String masterVolume, float 3, float 0));
        //^ is an attempt to fade... did not work.
        //using https://johnleonardfrench.com/how-to-fade-audio-in-unity-i-tested-every-method-this-ones-the-best/#:~:text=There%27s%20no%20separate%20function%20for,script%20will%20do%20the%20rest.
        audioSource.Stop();
        thrustParticles.Stop();
    }

    void ApplyRotation(float rotationThisFrame)
    {
        rb.freezeRotation = true; //freeze rotation to rotate manually
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        rb.freezeRotation = false;
    }
}