using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSystemVisual : MonoBehaviour
{

    public static GridSystemVisual Instance { get; private set; }
    [SerializeField] Transform gridSystemVisualSinglePrefab;
    GridSystemSingleVisual[,] gridSystemSingleVisualArray;

    private void Awake() 
    {
        if(Instance != null)
        {
            Debug.LogError($"There's more than one GridSystemVisual {transform} {Instance}!");
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    private void Start() 
    {
        gridSystemSingleVisualArray = new GridSystemSingleVisual[
            LevelGrid.Instance.GetGridWidth(),
            LevelGrid.Instance.GetGridHeight()];

        for(int x = 0; x < LevelGrid.Instance.GetGridWidth(); x++)
        {
            for(int z = 0; z < LevelGrid.Instance.GetGridHeight(); z++)
            {
                GridPosition gridPosition = new GridPosition (x, z);
                Transform gridSystemSingleVisualTransform =
                    Instantiate(gridSystemVisualSinglePrefab, LevelGrid.Instance.GetWorldPosition(gridPosition), Quaternion.identity);

                gridSystemSingleVisualArray[x, z] = gridSystemSingleVisualTransform.GetComponent<GridSystemSingleVisual>();
            }
        }    
    }

    private void Update() 
    {
        UpdateGridVisual();    
    }

    public void HideAllGridPositions()
    {
        for(int x = 0; x < LevelGrid.Instance.GetGridWidth(); x++)
        {
            for(int z = 0; z < LevelGrid.Instance.GetGridHeight(); z++)
            {
                gridSystemSingleVisualArray[x, z].Hide();
            }
        }    

    }

    public void ShowGridPositionList(List<GridPosition> gridPositionList)
    {
        foreach(GridPosition gridPosition in gridPositionList)
        {
            gridSystemSingleVisualArray[gridPosition.x, gridPosition.z].Show();
        }
    }

    void UpdateGridVisual()
    {
        HideAllGridPositions();
        
        BaseAction selectedAction = UnitActionSystem.Instance.GetSelectedAction();
        
        ShowGridPositionList(selectedAction.GetValidActionGridPositionList());

    }

}
