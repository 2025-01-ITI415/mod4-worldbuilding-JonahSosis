using UnityEngine;
using static OpponentDataScript;

[RequireComponent(typeof(Rigidbody))]
public class MovementInverted : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody rb;
    private Vector3 moveDirection;
    public GameObject playerSprite;
    public GameObject playerRunningLeftSprite;    // Running left sprite
    public GameObject playerRunningRightSprite;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Inverted input
        float horizontal = -Input.GetAxis("Horizontal"); // A/D → inverted
        float vertical = -Input.GetAxis("Vertical");     // W/S → inverted

        moveDirection = new Vector3(horizontal, 0f, vertical).normalized;

        if (moveDirection.magnitude > 0f)
        {
            playerSprite.SetActive(false); // Hide idle sprite

            if (horizontal < 0f)
            {
                // Running to the left
                playerRunningLeftSprite.SetActive(true);
                playerRunningRightSprite.SetActive(false);
            }
            else if (horizontal > 0f)
            {
                // Running to the right
                playerRunningLeftSprite.SetActive(false);
                playerRunningRightSprite.SetActive(true);
            }
            else if (vertical != 0f)
            {
                // Moving up or down — activate right running sprite
                playerRunningLeftSprite.SetActive(false);
                playerRunningRightSprite.SetActive(true);
            }
        }
        else
        {
            playerSprite.SetActive(true);   // Show idle sprite
            playerRunningLeftSprite.SetActive(false);
            playerRunningRightSprite.SetActive(false);
        }
    }

    void FixedUpdate()
    {
        float horizontal = -Input.GetAxis("Horizontal");
        float vertical = -Input.GetAxis("Vertical");

        Vector3 move = new Vector3(horizontal, 0f, vertical).normalized;
        rb.velocity = move * speed;
    }
}

