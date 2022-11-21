using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UnitActionSystemUI : MonoBehaviour
{

    [SerializeField] Transform unitActionButtonPrefab;
    [SerializeField] Transform unitActionButtonContainer;
    [SerializeField] TextMeshProUGUI actionPointText;
    List<ActionButtonUI> actionButtonUIList;

    void Awake()
    {
        actionButtonUIList = new List<ActionButtonUI>();
    }


    private void Start()
    {
        UnitActionSystem.Instance.OnSelectedUnitChanged += UnitActionSystem_OnSelectedUnitChanged;
        UnitActionSystem.Instance.OnSelectedActionChanged += UnitActionSystem_OnSelectedActionChanged;
        UnitActionSystem.Instance.OnActionStarted += UnitActionSystem_OnActionStarted;
        TurnSystem.Instance.OnNextTurn += TurnSystem_OnNextTurn;
        Unit.OnAnyActionPointChange += Unit_OnAnyActionPointChange;

        CreateUnitActionButtons();
        UpdateSelectedVisual();
        UpdateActionPoints();
    }
    
    void CreateUnitActionButtons()
    {
        
        foreach(Transform buttonTransform in unitActionButtonContainer)
        {
            Destroy(buttonTransform.gameObject);
        }

        actionButtonUIList.Clear();
        
        Unit selectedUnit = UnitActionSystem.Instance.GetSelectedUnit();
        foreach(BaseAction baseAction in selectedUnit.GetBaseActionArray())
        {
            Transform actionButtonTransform = Instantiate(unitActionButtonPrefab, unitActionButtonContainer);
            ActionButtonUI actionButtonUI = actionButtonTransform.GetComponent<ActionButtonUI>();
            actionButtonUI.SetBaseAction(baseAction);

            actionButtonUIList.Add(actionButtonUI);
        }
    }

    void UnitActionSystem_OnSelectedUnitChanged(object sender, EventArgs e)
    {
        CreateUnitActionButtons();
        UpdateSelectedVisual();
        UpdateActionPoints();
    }

    void UnitActionSystem_OnSelectedActionChanged(object sender, EventArgs e) 
    {
        UpdateSelectedVisual();    
    }

    void UnitActionSystem_OnActionStarted(object sender, EventArgs e)
    {
        UpdateActionPoints();
    }

    void TurnSystem_OnNextTurn(object sender, EventArgs e)
    {
        UpdateActionPoints();
    }

    void Unit_OnAnyActionPointChange(object sender, EventArgs e)
    {
        UpdateActionPoints();
    }

    void UpdateSelectedVisual()
    {
        foreach(ActionButtonUI actionButtonUI in actionButtonUIList)
        {
            actionButtonUI.UpdateSelectedVisual();
        }
    }

    void UpdateActionPoints()
    {
        Unit selectedUnit = UnitActionSystem.Instance.GetSelectedUnit();
        actionPointText.text = $"Action Points: { selectedUnit.GetActionPoints().ToString() }";
    }

}
