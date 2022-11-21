using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TurnSystem : MonoBehaviour
{

   public static TurnSystem Instance { get; private set; }
   public event EventHandler OnNextTurn;
   
    int turnNumber = 1;

    void Awake()
    {
        if(Instance != null)
        {
            Debug.Log($"There's more than one TurnSystem! { transform }, { Instance }");
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    public void NextTurn()
    {
        turnNumber++;
        OnNextTurn?.Invoke(this, EventArgs.Empty);
    }

    public int GetTurnNumber()
    {
        return turnNumber;
    }

}
