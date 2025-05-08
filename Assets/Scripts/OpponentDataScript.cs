using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpponentDataScript : MonoBehaviour
{
    [System.Serializable]
    public class Move
    {
        public string moveName;
        public int damage;
    }

    [System.Serializable]
    public class OpponentData
    {
        public string name;
        public int level;
        public int health;
        public Sprite sprite;
        public List<Move> moves;

        [System.NonSerialized] // So Unity doesn't try to serialize runtime data
        public int currentHealth; // Runtime health (gets set at battle start)

        // Add TakeDamage method to handle damage
        public void TakeDamage(int amount)
        {
            currentHealth -= amount;
            currentHealth = Mathf.Clamp(currentHealth, 0, health);  // Ensures health doesn't go below 0
        }
    }
}

