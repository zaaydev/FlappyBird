using UnityEngine;

public class ScoreTriggerScript : MonoBehaviour
{
    private GameManager gameManagerScriptRef;
   
    void Awake()
    {
        gameManagerScriptRef =  FindAnyObjectByType<GameManager>();
    }

    private void OnTriggerExit2D(Collider2D other) {
        gameManagerScriptRef.IncreamentScore(1);
        
    }
    
}
