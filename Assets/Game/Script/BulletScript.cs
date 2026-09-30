using UnityEngine;

public class BulletScript : MonoBehaviour {
    private Player playerScript;
    
    private void Awake() {
        playerScript =  FindAnyObjectByType<Player>();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerScript.DisableControls();
        }   
    }

    void Update()
    {
        Vector3 viewportPosition =
            Camera.main.WorldToViewportPoint(transform.position);

        if (viewportPosition.x < -0.4f ||viewportPosition.x > 1.4f || viewportPosition.y < -0.4f ||viewportPosition.y > 1.4f)
        {
            Destroy(gameObject);
        }
    }


}
