using UnityEngine;
using TMPro;
using UnityEngine.UI;
using static OpponentDataScript;

public class BattleUIManager : MonoBehaviour
{
    public GameObject moveBar;
    public GameObject movesButton;
    public TMP_Text[] moveButtonLabels;
    public Button[] moveButtons;
    public Image opponentSpriteImage;
    public Image protagonistSpriteImage;
    public Slider playerHealthBar;
    public Slider opponentHealthBar;
    public PlayerData playerData;
    private bool isPlayerTurn = true;  // Track whose turn it is


    public void SetOpponent(OpponentData opponent)
    {
        if (opponent == null)
        {
            Debug.LogError("Opponent is null in SetOpponent!");
            return;
        }

        opponentSpriteImage.sprite = opponent.sprite;
        protagonistSpriteImage.sprite = protagonistSpriteImage.sprite; // Ensure this is correct
        protagonistSpriteImage.enabled = true;

        // Update health bars
        playerHealthBar.maxValue = playerData.maxHealth;
        playerHealthBar.value = playerData.currentHealth;
        opponentHealthBar.maxValue = opponent.health;
        opponentHealthBar.value = opponent.currentHealth;

        // Set moves to buttons based on whose turn it is
        if (isPlayerTurn)  // **Changed line**: check if it's the player's turn
        {
            // Show the player's moves
            for (int i = 0; i < moveButtonLabels.Length; i++)
            {
                if (i < playerData.moves.Count)
                {
                    moveButtonLabels[i].text = playerData.moves[i].moveName + " (" + playerData.moves[i].damage + ")";
                }
                else
                {
                    moveButtonLabels[i].text = "";  // Clear extra buttons
                }
            }
        }
        else  // **Changed line**: check if it's the opponent's turn
        {
            // Show the opponent's moves
            for (int i = 0; i < moveButtonLabels.Length; i++)
            {
                if (i < opponent.moves.Count)
                {
                    moveButtonLabels[i].text = opponent.moves[i].moveName + " (" + opponent.moves[i].damage + ")";
                }
                else
                {
                    moveButtonLabels[i].text = "";  // Clear extra buttons
                }
            }
        }
    }




    public void UpdatePlayerHealth(int health)
    {
        playerHealthBar.value = health;
    }

    public void UpdateOpponentHealth(int health)
    {
        opponentHealthBar.value = health;
    }

    public void ShowMoveBar()
    {
        moveBar.SetActive(true);
        movesButton.SetActive(false);
    }

    public void HideMoveBar()
    {
        moveBar.SetActive(false);
        movesButton.SetActive(true);
    }

    public void EndTurn()
    {
        // Hide move bar after player's turn
        HideMoveBar();

        // Proceed with opponent's turn logic
        // You can call a method to execute the opponent's turn here
    }

}
