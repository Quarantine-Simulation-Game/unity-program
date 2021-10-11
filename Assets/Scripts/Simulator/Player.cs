using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour
{
    GameController gameController;
    [Range(6,10)]
    public int energy = 6;
    public int coin = 0;
    // Energy indicates the size of board in the mini game
    [SerializeField] PlayerCondition[] playerConditions;

    // Start is called before the first frame update
    void Start()
    {
        gameController = GetComponent<GameController>();
        foreach (PlayerCondition _condition in playerConditions)
        {
            if(_condition.isActive == true)
            {
                _condition.NewDay();
            }
        }
        AmendAvailableItemTypes();

    }


    public void UpdateActivePlayerConditions()
    {
        foreach (PlayerCondition _condition in playerConditions)
        {
            _condition.NewDay();
        }
    }

    public void CheckUndatedPlayerConditions(int day)
    {
        foreach (PlayerCondition _condition in playerConditions)
        {
            if (_condition.requiredLevel <= day)
            {
                _condition.isActive = true;
                _condition.Visualizer.SetActive(true);
            }
        }
        AmendAvailableItemTypes();
    }

    void AmendAvailableItemTypes()
    {
     //   string debug = "";
        {
            foreach (PlayerCondition _condition in playerConditions)
            {
                if (_condition.isActive == true)
                {
                    gameController.availableItemTypes.Add(_condition.name);
                  //  debug += " " + _condition.name;

                }
            }
        }
      //  Debug.Log(debug);
    }
    

    public void ChangeToCondition(ItemType name, float value)
    {
        foreach (PlayerCondition _condition in playerConditions)
        {
            if (name.Equals(_condition.name))
            {
                _condition.ChangeToNextDayChange(value);
            }
        }
    }

    public void DebugCondition()
    {
        foreach (PlayerCondition _condition in playerConditions)
        {
            string debug = "";
            debug = debug + "name: " + _condition.name + "  next Value: " +_condition.nextDayChangeValue;
        }
    }

    public PlayerCondition FindCondition(ItemType name)
    {
        foreach (PlayerCondition _condition in playerConditions)
        {
            if (name.Equals(_condition.name))
            {
                return _condition;
            }
        }

        return null;
    }
}
