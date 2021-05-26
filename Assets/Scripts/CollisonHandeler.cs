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
   private void Start() {
       audioSource = GetComponent<AudioSource>();
   }
 private void OnCollisionEnter(Collision other) {
     
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
     if(!isTransitioning){
         audioSource.Stop();
         deathPartical.Play();
     GetComponent<Movment>().enabled = false;
     audioSource.PlayOneShot(deathSound);
     Invoke("RestartLevel",delay);
     }
     isTransitioning = true;
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
     if(!isTransitioning){
         audioSource.Stop();
         successPartical.Play();
     audioSource.PlayOneShot(successLevel);
GetComponent<Movment>().enabled = false;
     Invoke("LoadNextLevel",delay);
     }
     isTransitioning = true;
 }
}
