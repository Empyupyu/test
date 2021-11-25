using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    [SerializeField] private Cell _Cell;
    private Cell[,] _ActiveCells;
    public Cell[,] ActiveCells => _ActiveCells;
  
    public void Generetor(LevelDate level)
    {
        if (_ActiveCells != null) Clear();
    
        _ActiveCells = new Cell[level.Column, level.Row];

        Vector2 centre;
        centre.x = -(level.Row / 2f * _Cell.Size.x) + _Cell.Size.x / 2f;
        centre.y = -(level.Column / 2f * _Cell.Size.y) + _Cell.Size.y / 2f;     

        for (int y = 0; y < _ActiveCells.GetLength(0); y++)
        {
            for (int x = 0; x < _ActiveCells.GetLength(1); x++)
            {
               var cell = Instantiate(_Cell, transform);
         
                Vector2 cellPosiition = new Vector2(transform.position.x + centre.x + _Cell.Size.x * x, transform.position.y + centre.y + _Cell.Size.y * y);
                cell.transform.position = cellPosiition;

                _ActiveCells[y,x] = cell;           
            }
        }
    }
    public void Disable()
    {
        foreach (var cell in _ActiveCells)
        {
            cell.Card.Disable();
        }
    }
    private void Clear()
    {
        foreach (var cell in _ActiveCells)
        {
            Destroy(cell.gameObject);
        }      
    }  
}
