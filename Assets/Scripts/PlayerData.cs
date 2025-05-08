using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static OpponentDataScript;

public class PlayerData : MonoBehaviour
{
    [Header("Player Stats")]
    public int maxHealth = 100;
    public int currentHealth;

    [Header("Player Moves")]
    public List<Move> moves = new List<Move>();  // Change to Move instead of PlayerMove

    void Start()
    {
        // Initialize health
        currentHealth = maxHealth;

        // Example move setup (can also be done in Inspector)
        if (moves.Count == 0)
        {
            moves.Add(new Move { moveName = "Slash", damage = 0 });
            moves.Add(new Move { moveName = "Fireball", damage = 15 });
            moves.Add(new Move { moveName = "Heal", damage = -10 }); // negative for healing
            moves.Add(new Move { moveName = "Shield Bash", damage = 8 });
        }
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
    }

    public void Heal(int amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
    }

    public Move GetMove(int index)
    {
        if (index >= 0 && index < moves.Count)
        {
            return moves[index];
        }
        return null;
    }

    void Awake()  // Use Awake instead of Start so it runs earlier
    {
        currentHealth = maxHealth;
    }
}

