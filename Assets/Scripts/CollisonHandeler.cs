using UnityEngine;
using UnityEngine.SceneManagement;
public class CollisonHandeler : MonoBehaviour
{

   [SerializeField] float delay =1f;
   [SerializeField] AudioClip successLevel;
   [SerializeField] AudioClip deathSound;
   [SerializeField] ParticleSystem successPartical;
   [SerializeField] ParticleSystem deathPartical;
   
   AudioSource audioSource;

   bool isTransitioning = false;
   bool collisionIsDisabled = false;
   private void Start() {
       audioSource = GetComponent<AudioSource>();
   }
   private void Update() {
       RespondToDebugKeys();
   }

   void RespondToDebugKeys() {
       if (Input.GetKeyDown(KeyCode.L))
       {
           LoadNextLevel();
       }
       else if(Input.GetKeyDown(KeyCode.C)){
           collisionIsDisabled = !collisionIsDisabled;
       }
   }
 private void OnCollisionEnter(Collision other) {
     if (isTransitioning || collisionIsDisabled)
     {return;
     }
     
     switch(other.gameObject.tag){

         case "Finish":
         StartSuccessSequence();
         break;
         
         case "Friendly": 
         Debug.Log("friendly bumb");
         break;

         default:
         StartCrashSequence(); 
         break;

     }
     
 }

 void StartCrashSequence(){
    isTransitioning = true;
         audioSource.Stop();
         deathPartical.Play();
     GetComponent<Movment>().enabled = false;
     audioSource.PlayOneShot(deathSound);
     Invoke("RestartLevel",delay);
     
 }

 void RestartLevel(){
     int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
     SceneManager.LoadScene(currentSceneIndex);
 }   

 void LoadNextLevel(){

     int nextSceneIndex = SceneManager.GetActiveScene().buildIndex +1;
     if(nextSceneIndex == SceneManager.sceneCountInBuildSettings){
         nextSceneIndex =0;
     }
     SceneManager.LoadScene(nextSceneIndex);
 }

 void StartSuccessSequence(){
   isTransitioning = true;
         audioSource.Stop();
         successPartical.Play();
     audioSource.PlayOneShot(successLevel);
GetComponent<Movment>().enabled = false;
     Invoke("LoadNextLevel",delay);
    
 }
}
