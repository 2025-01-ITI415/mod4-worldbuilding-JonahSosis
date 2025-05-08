using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static OpponentDataScript;

public class MoveUIController : MonoBehaviour
{
    public GameObject moveBar;
    public GameObject movesButton;
    public TMP_Text[] moveButtonLabels;
    public Button[] moveButtons;
    
    public void ShowMoveBar()
    {
        moveBar.SetActive(true);
        movesButton.SetActive(false);
    }

    // Called when "Back" button is pressed
    public void HideMoveBar()
    {
        moveBar.SetActive(false);
        movesButton.SetActive(true);
    }
}
