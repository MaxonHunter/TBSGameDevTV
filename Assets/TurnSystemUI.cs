using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class TurnSystemUI : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI turnNumberText;
    [SerializeField] Button endTurnButton;

    private void Start() 
    {
        
        TurnSystem.Instance.OnNextTurn += TurnSystem_OnNextTurn;

        endTurnButton.onClick.AddListener(() =>
        {
            TurnSystem.Instance.NextTurn();
        });

        UpdateTurnText();
    }

    void UpdateTurnText()
    {
        turnNumberText.text = $"Turn: {TurnSystem.Instance.GetTurnNumber().ToString()}";
    }

    void TurnSystem_OnNextTurn(object sender, EventArgs e)
    {
        UpdateTurnText();
    }

}
