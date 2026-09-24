using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody2D playerRigidBody;
    private PlayerInputActions playerInputsActions;

    private void Awake()
    {
        playerInputsActions = new PlayerInputActions();
        // is dead (disable) by default so we have to enable it

        playerInputsActions.Enable();
    }


    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInputsActions.PlayerMap.Jump.WasPressedThisFrame()) {
            playerRigidBody.linearVelocity = new Vector2(0, 6);

            Debug.Log("Clicked!");
        }
    }
}
