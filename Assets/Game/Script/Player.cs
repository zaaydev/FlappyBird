using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody2D playerRigidBody;
    private PlayerInputActions playerInputsActions;
    [SerializeField] private float jumpVelocity;
    private GameManager gameManagerScript;
    private bool isDead;

    private void Awake()
    {
        playerInputsActions = new PlayerInputActions();
        // is dead (disable) by default so we have to enable it

        gameManagerScript =  FindAnyObjectByType<GameManager>();
    }

    private void OnEnable() {
        playerInputsActions.Enable();
        
    }
    private void OnDisable() {
        playerInputsActions.Disable();
    }


    void Update()
    {
        if (playerInputsActions.PlayerMap.Jump.WasPressedThisFrame() && transform.position.y < 13.5f) {
            playerRigidBody.linearVelocity = new Vector2(0, 1f) * jumpVelocity;
        }

        if (!isDead && transform.position.y < -14.5f) {
            gameManagerScript.GameOverFunction();
            DisableControls();
            isDead = true;
        }

    }

    public void DisableControls() {
        playerInputsActions.Disable();
    }
}
