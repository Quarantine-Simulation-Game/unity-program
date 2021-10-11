using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public int gameStage;
    public int day;
    [SerializeField] GameObject canvas;
    public List<ItemType> availableItemTypes;
    Player playerProfile;
    GameTimeSystem gameTimeSystem;

    
    [SerializeField] TextVisualization textField_day;
    [SerializeField] TextVisualization textField_coin;
   
    
    private static GameController playerInstance;
    void Awake()
    {
        DontDestroyOnLoad(this);

        if (playerInstance == null)
        {
            playerInstance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        availableItemTypes.Add(ItemType.Any);
        playerProfile = GetComponent<Player>();
        gameTimeSystem = GetComponent<GameTimeSystem>();
        NewDay();
    }

    public void NewDay()
    {
        gameStage = playerProfile.energy;
        day = gameTimeSystem.currentDay;
        textField_day.TextUpdate(day+"");
    }
    // Update is called once per frame

    public void ReloadMainScene()
    {
        SceneManager.LoadScene(1);
        canvas.SetActive(true);
        textField_coin.TextUpdate(playerProfile.coin + "");
        playerProfile.UpdateActivePlayerConditions();
    }
    public void ReloadMiniGame()
    {
        SceneManager.LoadScene(2);
        canvas.SetActive(false);
    }
    public void HomeBtn()
    {
        SceneManager.LoadScene(0);
    }

    public void UpdateCoin()
    {
        textField_coin.TextUpdate(playerProfile.coin + "");
    }
}
