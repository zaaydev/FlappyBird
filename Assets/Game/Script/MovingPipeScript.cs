using UnityEngine;

public class MovingPipeScript : MonoBehaviour
{
    [SerializeField] private float movementSpeed;

    private GameManager gameManagerScript;
    private Player playerScript;
    private float pipesDeadZone = -40f;

    private void Awake() {
        gameManagerScript =  FindAnyObjectByType<GameManager>();
        playerScript =  FindAnyObjectByType<Player>();

    }

    private void OnCollisionEnter2D(Collision2D other) {
       if (other.gameObject.CompareTag("Player")) {
        gameManagerScript.GameOverFunction();
        playerScript.DisableControls();
       }

        
    }

    void Update()
    {
        transform.position = transform.position + Vector3.left * movementSpeed * Time.deltaTime;

        if (transform.position.x < pipesDeadZone) {
            Destroy(gameObject); 
        }
    }
}
