using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movment : MonoBehaviour
{
   [SerializeField] AudioClip mainEngine;
    [SerializeField] float mainThrust =100f;
    [SerializeField] float rotationSpeed =100f;
    Rigidbody rb;
    AudioSource audioSource;
    [SerializeField] ParticleSystem mainEnginepartical;
    [SerializeField] ParticleSystem leftEnginepartical;
    [SerializeField] ParticleSystem rightEnginepartical;
        // Start is called before the first frame update
    void Start()
    {
       rb = GetComponent<Rigidbody>();
       audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
       ProcessInput();
    }


    void ProcessInput(){
        ProcessRotation();
        ProcessUp();
    }

    void ProcessRotation(){
     
     if(Input.GetKey(KeyCode.A)){
         ApplyRotation(rotationSpeed);
         if(!rightEnginepartical.isPlaying){
            rightEnginepartical.Play();
         }    
       }
       else if(Input.GetKey(KeyCode.D)){
      ApplyRotation(-rotationSpeed);
      if(!leftEnginepartical.isPlaying){
         leftEnginepartical.Play();
      }
       }
       else{
          rightEnginepartical.Stop();
          leftEnginepartical.Stop();
       }
    }
    void ProcessUp(){
     
     if(Input.GetKey(KeyCode.Space)){
        
     rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
     if(!audioSource.isPlaying){
        audioSource.PlayOneShot(mainEngine);
     }
     if(!mainEnginepartical.isPlaying){
     mainEnginepartical.Play();
     }
       }
       else{
          audioSource.Stop();
          mainEnginepartical.Stop();
       }
   
    }

    void ApplyRotation( float rotationThisFrame){
        rb.freezeRotation = true; // freezing rotation to manually move
     transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
     rb.freezeRotation = false;
    }
}







