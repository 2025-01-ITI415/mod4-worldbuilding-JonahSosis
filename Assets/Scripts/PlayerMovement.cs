using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public GameObject playerSprite;
    public GameObject playerRunningLeftSprite;    // Running left sprite
    public GameObject playerRunningRightSprite;
    public bool canMove = true;
    void Update()
    {
        if (!canMove) return;

        float horizontal = Input.GetAxis("Horizontal"); // A/D or Left/Right
        float vertical = Input.GetAxis("Vertical");     // W/S or Up/Down

        Vector3 move = new Vector3(horizontal, 0f, vertical);
        transform.Translate(move * speed * Time.deltaTime, Space.World);
        if (move.magnitude > 0f)
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
}
