using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movment : MonoBehaviour
{
    [SerializeField] float mainThrust =100f;
    [SerializeField] float rotationSpeed =100f;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
       rb = GetComponent<Rigidbody>();
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
       }
       else if(Input.GetKey(KeyCode.D)){
      ApplyRotation(-rotationSpeed);
       }
    }
    void ProcessUp(){
     
     if(Input.GetKey(KeyCode.Space)){
     rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
       }
    }
    void ApplyRotation( float rotationThisFrame){
        rb.freezeRotation = true; // freezing rotation to manually move
     transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
     rb.freezeRotation = false;
    }
}







