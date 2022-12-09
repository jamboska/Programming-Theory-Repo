using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject crossPrefab;
    [SerializeField] GameObject zeroPrefab;
    [SerializeField] GameObject gameOverScreen;
    [SerializeField] TextMeshProUGUI winnerText;

    [SerializeField] private GameObject[] cells;
    [SerializeField] private GameObject[] objects;
    private bool isPlayerMove;
    private bool gameIsOver;

    private void Start()
    {
        objects = new GameObject[9];
        cells = FindCells();

        isPlayerMove = true;
        gameIsOver = false;
    }

    // ABSTRACTION
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private GameObject[] FindCells()
    {
        GameObject[] cells = GameObject.FindGameObjectsWithTag("Cell");
        GameObject[] sortedCells = new GameObject[9];
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                if (cells[j].GetComponent<Cell>().Index == i + 1)
                {
                    sortedCells[i] = cells[j];
                }
            }
        }

        return sortedCells;
    }

    public void CellClicked(Cell cell)
    {
        if (!gameIsOver && isPlayerMove)
        {
            // если ячейка пустая
            if (objects[cell.Index - 1] == null)
            {
                createCrossOnCell(cell);
                isPlayerMove = false;

                CheckGameOver();

                if (!gameIsOver)
                {
                    CreateRandomZero();
                    CheckGameOver();
                }
            }
        }
    }

    // Проверяет есть в поле 3 символа в ряд. Если есть показывает экран "Game Over"
    // и возвращает true, иначе false.
    private bool CheckGameOver()
    {
        if (GetEmptyCellsNumber() == 0)
        {
            gameIsOver = true;
            gameOverScreen.SetActive(true);
            winnerText.text = "Out of cells.";
            return true;
        }

        string foundLine = FindLine();

        if (foundLine == "cross")
        {
            //Debug.Log("Player won.");
            gameIsOver = true;
            gameOverScreen.SetActive(true);
            winnerText.text = "Player won.";
            return true;
        }
        else if (foundLine == "zero")
        {
            //Debug.Log("Computer won.");
            gameIsOver = true;
            gameOverScreen.SetActive(true);
            winnerText.text = "Computer won.";
            return true;
        }

        return false;
    }

    // Находит линию из ноликов или крестиков. Возвращает "cross", "zero" или "noline".
    private string FindLine()
    {
        string result;

        // вертикальные
        result = CheckLine(1, 4, 7);
        if (result == "cross" || result == "zero") return result;

        result = CheckLine(2, 5, 8);
        if (result == "cross" || result == "zero") return result;

        result = CheckLine(3, 6, 9);
        if (result == "cross" || result == "zero") return result;

        // горизонтальные
        result = CheckLine(1, 2, 3);
        if (result == "cross" || result == "zero") return result;

        result = CheckLine(4, 5, 6);
        if (result == "cross" || result == "zero") return result;

        result = CheckLine(7, 8, 9);
        if (result == "cross" || result == "zero") return result;

        // диагональные
        result = CheckLine(1, 5, 9);
        if (result == "cross" || result == "zero") return result;

        result = CheckLine(3, 5, 7);
        if (result == "cross" || result == "zero") return result;

        return "noline";
    }

    // Returns "cross", "zero" or "noline".
    private string CheckLine(int cellIndex1, int cellIndex2, int cellIndex3)
    {
        if (objects[cellIndex1 - 1] != null && objects[cellIndex2 - 1] != null && objects[cellIndex3 - 1] != null)
        {
            string type1 = objects[cellIndex1 - 1].GetComponent<Symbol>().GetSymbolType();
            string type2 = objects[cellIndex2 - 1].GetComponent<Symbol>().GetSymbolType();
            string type3 = objects[cellIndex3 - 1].GetComponent<Symbol>().GetSymbolType();

            if (type1 == type2 && type2 == type3)
            {
                if (type1 == "cross")
                {
                    return "cross";
                }
                else
                {
                    return "zero";
                }
            }
        }

        return "noline";
    }

    private void createCrossOnCell(Cell cell)
    {
        GameObject cross = Instantiate(crossPrefab, cell.transform.position, crossPrefab.transform.rotation);
        objects[cell.Index - 1] = cross;
    }

    private void CreateRandomZero()
    {
        int randomIndex;

        while (true)
        {
            randomIndex = Random.Range(0, 9);
            if (objects[randomIndex] == null)
            {
                break;
            }
        }

        GameObject zeroObject = Instantiate(zeroPrefab, cells[randomIndex].transform.position, zeroPrefab.transform.rotation);
        objects[randomIndex] = zeroObject;

        isPlayerMove = true;
    }

    private int GetEmptyCellsNumber()
    {
        int amount = 0;
        for (int i = 0; i < objects.Length; i++)
        {
            if (objects[i] == null)
            {
                amount++;
            }
        }

        return amount;
    }

}
