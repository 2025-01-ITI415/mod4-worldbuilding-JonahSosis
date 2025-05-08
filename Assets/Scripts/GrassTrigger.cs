using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static OpponentDataScript;

public class GrassTrigger : MonoBehaviour
{
    public BattleManager battleManager;
    public OpponentManager opponentManager;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("grass has been entered");

            int chance = Random.Range(1, 11); // 1 to 10 inclusive
            if (chance == 1)
            {
                Debug.Log("Battle started from grass!");
                OpponentData opponent = opponentManager.GetRandomOpponent();
                battleManager.StartBattle(opponent);
            }
        }
    }
}
