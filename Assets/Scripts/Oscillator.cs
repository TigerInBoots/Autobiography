using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{

    Vector3 startingPosition;
    [SerializeField] Vector3 movementVector;
    [SerializeField] [Range(0,1)] float movementFactor;
    [SerializeField] float period = 2f;

    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        if (period <= Mathf.Epsilon) {return;}
        
        float cycles = Time.time / period; //amount of x second intervals
        const float tau = Mathf.PI * 2; //2 times pi
        float rawSinWave = Mathf.Sin(cycles * tau); //going from -1 to 1

        movementFactor = (rawSinWave + 1f) / 2f; //going from 0 to 1

        Vector3 offset = movementVector * movementFactor; //offset is amount moved
        transform.position = startingPosition + offset; //end position
    }
}
