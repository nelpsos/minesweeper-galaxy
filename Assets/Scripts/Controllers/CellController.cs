using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellController : MonoBehaviour
{
    public Define.CellState CellState { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        Managers.Input.MouseAction -= OnMouseClicked;
        Managers.Input.MouseAction += OnMouseClicked;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetCellState(int mineCount)
    {
        CellState = (Define.CellState)mineCount;

        SetColor(CellState);    
    }

    public void SetCellState(Define.CellState cellState)
    {
        CellState = cellState;

        SetColor(CellState);
    }

    public void SetColor(Define.CellState cellState)
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer == null)
            Debug.Assert(true, "Set Color Function - GetCompoent Fail");

        spriteRenderer.color = Util.GetCellStateColor(cellState);
    }

    void OnMouseClicked(Define.MouseEvent evt)
    {

    }
}
