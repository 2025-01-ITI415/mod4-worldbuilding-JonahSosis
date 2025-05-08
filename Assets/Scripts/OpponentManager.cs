using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static OpponentDataScript;

public class OpponentManager : MonoBehaviour
{
    // Start is called before the first frame update
    public List<OpponentData> opponentPool;

    public OpponentData GetRandomOpponent()
    {
        int index = Random.Range(0, opponentPool.Count);
        return opponentPool[index];
    }
}
