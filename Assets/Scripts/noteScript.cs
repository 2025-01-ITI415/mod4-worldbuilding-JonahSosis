using UnityEngine;

public class noteScript : MonoBehaviour
{
    public GameObject uiScreen1;     // First UI screen
    public GameObject letterScreen;  // Second UI screen (the "letter")

    private bool playerInZone = false;
    private bool letterOpen = false;

    void Update()
    {
        if (playerInZone)
        {
            // Show the letter when Space is pressed
            if (!letterOpen && Input.GetKeyDown(KeyCode.Space))
            {
                letterScreen.SetActive(true);
                letterOpen = true;
            }
            // Close the letter when any key is pressed (except Space to avoid instant toggle)
            else if (letterOpen && Input.anyKeyDown)
            {
                letterScreen.SetActive(false);
                letterOpen = false;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            uiScreen1.SetActive(true);
            playerInZone = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            uiScreen1.SetActive(false);
            letterScreen.SetActive(false);
            playerInZone = false;
            letterOpen = false;
        }
    }
}

