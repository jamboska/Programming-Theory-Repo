using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    // ENCAPSULATION
    [SerializeField] int index;
    private GameManager gameManager;

    public int Index { get => index; }

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void OnMouseDown()
    {
        gameManager.CellClicked(this);
    }
}
