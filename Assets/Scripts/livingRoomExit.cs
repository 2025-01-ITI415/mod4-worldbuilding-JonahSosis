using UnityEngine;
using UnityEngine.SceneManagement;

public class LivingRoomExit : MonoBehaviour
{
    public GameObject interactionUI;
    public GameObject motherUI;
    public GameObject motherObjectUI;
    public string sceneToLoad = "town 1";

    private bool playerInZone = false;
    private bool motherUIShownOnce = false;
    private bool motherUIActive = false;

    void Update()
    {
        if (!playerInZone) return;

        if (!motherUIShownOnce && Input.GetKeyDown(KeyCode.Space))
        {
            motherUI.SetActive(true);
            motherObjectUI.SetActive(true);
            interactionUI.SetActive(false);
            motherUIActive = true;
            motherUIShownOnce = true;
        }
        else if (motherUIActive && Input.anyKeyDown)
        {
            motherUI.SetActive(false);
            motherObjectUI.SetActive(false);
            motherUIActive = false;
        }
        else if (motherUIShownOnce && !motherUIActive && Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Only show interaction UI if mom message hasn't just been shown
            if (!motherUIActive)
                interactionUI.SetActive(true);

            playerInZone = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            interactionUI.SetActive(false);
            motherUI.SetActive(false);
            playerInZone = false;
            motherUIActive = false; // Reset flag so message doesn’t reopen visually
        }
    }
}
