using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MiniGameController : MonoBehaviour
{
    [SerializeField] GameObject gameBoard;
    FarrokhGames.Inventory.InventoryManager inventory;
    GameController gameController; // process coins
    Player playerProfile; // process daily changes

    int coin = 0;

    [SerializeField] List<FarrokhGames.Inventory.Examples.ItemDefinition> itemDefinitions = new List<FarrokhGames.Inventory.Examples.ItemDefinition>();
    List<FarrokhGames.Inventory.Examples.ItemDefinition> itemCollected = new List<FarrokhGames.Inventory.Examples.ItemDefinition>();
    // deal with the content of inventory, allitems is iinventoryitem class, which does not contain itemtype

    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.Find("_Manager").GetComponent<GameController>();
        playerProfile = GameObject.Find("_Manager").GetComponent<Player>();
        inventory = gameBoard.GetComponent<FarrokhGames.Inventory.Examples.SizeInventoryExample>().inventory;
    }

    public void ContinueBtn()
    {
        ItemCollect();
        CalculateCoin();
        CalculateConditionChange();
        playerProfile.DebugCondition();
        gameController.ReloadMainScene();
    }

    void ItemCollect()
    {
        string debug= "";
        itemCollected = new List<FarrokhGames.Inventory.Examples.ItemDefinition>();
        inventory = gameBoard.GetComponent<FarrokhGames.Inventory.Examples.SizeInventoryExample>().inventory;
        foreach (FarrokhGames.Inventory.IInventoryItem element in inventory.allItems)
        {
            foreach (FarrokhGames.Inventory.Examples.ItemDefinition item in itemDefinitions)
            {
                if (element.name.Equals(item.name))
                {
                    itemCollected.Add(item);
                    debug += item.name + " ";
                }
            }
        }
        Debug.Log(debug);
    }
    void CalculateCoin()
    {
        foreach (FarrokhGames.Inventory.Examples.ItemDefinition item in itemCollected)
        {
            if (item.name.Equals("coin"))
            {
                coin += 1;
            }
        }
        playerProfile.coin += coin;
    }

    void CalculateConditionChange()
    {
        foreach (FarrokhGames.Inventory.Examples.ItemDefinition item in itemCollected)
        {
            playerProfile.ChangeToCondition(item.Type, 0.5f);
        }

    }
}
