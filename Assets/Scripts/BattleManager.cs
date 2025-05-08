using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static OpponentDataScript;

public class BattleManager : MonoBehaviour
{
    public GameObject battleUI;
    private GameObject player;
    public PlayerData playerData;
    public OpponentManager opponentManager;
    public BattleUIManager battleUIManager;

    private OpponentData currentOpponent;

    private bool isPlayerTurn = true;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        battleUI.SetActive(false); // Make sure it starts hidden
    }

    // Start a battle with a random opponent
    public void StartBattle(OpponentData opponent)
    {
        currentOpponent = opponent;
        currentOpponent.currentHealth = currentOpponent.health;
        playerData.currentHealth = playerData.maxHealth;

        // Update health bars
        battleUIManager.UpdatePlayerHealth(playerData.currentHealth);
        battleUIManager.UpdateOpponentHealth(currentOpponent.currentHealth);

        player.GetComponent<PlayerMovement>().canMove = false;
        battleUI.SetActive(true);

        // Set opponent in the UI
        battleUIManager.SetOpponent(currentOpponent);

        // Player goes first
        isPlayerTurn = true;

        
    }
    public void ExecuteMove1()
    {
        Move move = playerData.GetMove(0);  // Assuming the first move is at index 0
        if (move != null)
        {
            currentOpponent.TakeDamage(move.damage);
            battleUIManager.UpdateOpponentHealth(currentOpponent.currentHealth);
            isPlayerTurn = false;  // Switch to opponent's turn
            battleUIManager.HideMoveBar();
            StartCoroutine(EnemyTurn());
        }
    }

    public void ExecuteMove2()
    {
        Move move = playerData.GetMove(1);  // Assuming the second move is at index 1
        if (move != null)
        {
            currentOpponent.TakeDamage(move.damage);
            battleUIManager.UpdateOpponentHealth(currentOpponent.currentHealth);
            isPlayerTurn = false;  // Switch to opponent's turn
            battleUIManager.HideMoveBar();
            StartCoroutine(EnemyTurn());
        }
    }

    public void ExecuteMove3()
    {
        Move move = playerData.GetMove(2);  // Assuming the third move is at index 2
        if (move != null)
        {
            currentOpponent.TakeDamage(move.damage);
            battleUIManager.UpdateOpponentHealth(currentOpponent.currentHealth);
            isPlayerTurn = false;  // Switch to opponent's turn
            battleUIManager.HideMoveBar();
            StartCoroutine(EnemyTurn());
        }
    }

    public void ExecuteMove4()
    {
        Move move = playerData.GetMove(3);  // Assuming the fourth move is at index 3
        if (move != null)
        {
            currentOpponent.TakeDamage(move.damage);
            battleUIManager.UpdateOpponentHealth(currentOpponent.currentHealth);
            isPlayerTurn = false;  // Switch to opponent's turn
            battleUIManager.HideMoveBar();
            StartCoroutine(EnemyTurn());
        }
    }
    

    private IEnumerator EnemyTurn()
    {
        yield return new WaitForSeconds(1f);  // Add a small delay to simulate the opponent's turn

        // Opponent randomly picks a move
        int moveIndex = Random.Range(0, currentOpponent.moves.Count);
        Move opponentMove = currentOpponent.moves[moveIndex];

        // Deal damage to the player
        playerData.TakeDamage(opponentMove.damage);
        battleUIManager.UpdatePlayerHealth(playerData.currentHealth);

        // After the opponent's turn, check if the battle is over
        if (currentOpponent.currentHealth > 0 && playerData.currentHealth > 0)
        {
            isPlayerTurn = true;  // Switch back to player's turn
            battleUIManager.ShowMoveBar();  // Show move bar for player again
        }
        else
        {
            EndBattle();
        }
    }


    // End the battle
    public void EndBattle()
    {
        battleUI.SetActive(false);
        player.GetComponent<PlayerMovement>().canMove = true;

        // Check who won
        if (playerData.currentHealth > 0)
        {
            // Player wins
            Debug.Log("Player Wins!");
        }
        else
        {
            // Opponent wins
            Debug.Log("Opponent Wins!");
        }
    }
}
