using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameGenerator : MonoBehaviour
{
    public int number;
    // linked to level
    [SerializeField] List<GameObject> pool;
    List<GameObject> availablePool = new List<GameObject>();
    [SerializeField] GameObject gameBoard;
    [SerializeField] GameObject gamePool;
    //where to store the collectable items

    GameController gameController;

    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.Find("_Manager").GetComponent<GameController>();
        FindAvaliableItemList();
        InstanciatePool();
        InstanciateBoard();
    }



    void FindAvaliableItemList()
    {
        foreach(GameObject _gameObject in pool)
        {
            if(_gameObject.GetComponent<FarrokhGames.Inventory.Examples.SizeInventoryExample>() != null)
            {
                ItemType thisItem = _gameObject.GetComponent<FarrokhGames.Inventory.Examples.SizeInventoryExample>()._allowedItem;
                if (gameController.availableItemTypes.Contains(thisItem))
                {
                    availablePool.Add(_gameObject);
                }
            }
        }
    }

    void InstanciatePool()
    {
        number = gameController.gameStage * 2;
        for(int i = 0; i < number; i++)
        {
            Instantiate(availablePool[Random.Range(0, availablePool.Count)],gamePool.transform);
        }
    }

    void InstanciateBoard()
    {
        int size = gameController.gameStage;

        gameBoard.GetComponent<FarrokhGames.Inventory.Examples.SizeInventoryExample>()._width = size;
        gameBoard.GetComponent<FarrokhGames.Inventory.Examples.SizeInventoryExample>()._height = size;
    }

}