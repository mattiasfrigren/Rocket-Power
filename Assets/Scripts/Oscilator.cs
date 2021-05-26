using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscilator : MonoBehaviour
{

    Vector3 startingPosition;
    [SerializeField] Vector3 momentVector;
    [SerializeField] float period = 2f;
     float momentFactor;
    // Start is called before the first frame update
    void Start()
    {
     startingPosition = transform.position;
   
    }

    // Update is called once per frame
    void Update()
    {
        if(period <= Mathf.Epsilon){return;}
        float cycles = Time.time /period; // growing over time
        float tau = Mathf.PI *2; //constat value of 6.283

        float rawSinWave = Mathf.Sin(cycles *tau); //going from -1  to 1
        
        momentFactor = (rawSinWave +1f) /2f; // recalculate to go from 0 to 1

        Vector3 offset = momentVector *momentFactor;
        transform.position = startingPosition + offset;
    }
}
