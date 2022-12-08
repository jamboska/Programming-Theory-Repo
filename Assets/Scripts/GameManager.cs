using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject crossPrefab;
    [SerializeField] GameObject zeroPrefab;

    private GameObject[] objects;
    private bool isPlayerMove;

    private void Start()
    {
        objects = new GameObject[9];

        isPlayerMove = true;
    }

    public void CellClicked(Cell cell)
    {
        if (isPlayerMove)
        {
            objects[cell.index - 1] = Instantiate(crossPrefab, cell.transform.position, crossPrefab.transform.rotation);
            //isPlayerMove = false;

            //CreateRandomZero();
        }
    }

    private void CreateRandomZero()
    {
        int randomIndex;

        while (true)
        {
            randomIndex = Random.Range(0, 9);
            //if (random)
        }
        

    }

}
