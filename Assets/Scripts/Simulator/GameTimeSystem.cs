using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimeSystem : MonoBehaviour
{
    Player playerProfile;
    GameController gameController;
    public float gameTime = 0;
    public int currentDay = 0;
    [SerializeField] private Image windowView;
    [SerializeField] private Sprite day;
    [SerializeField] private Sprite night;

    private void Start()
    {
        playerProfile = GetComponent<Player>();
        gameController = GetComponent<GameController>();
    }
    // Start is called before the first frame update
    public void NewDay()
    {
        currentDay += 1;
        changeWindowView();
        playerProfile.UpdateActivePlayerConditions();
        playerProfile.CheckUndatedPlayerConditions(currentDay);
        gameController.NewDay();
        gameController.ReloadMiniGame();
    }

    public void Nap()
    {
        gameTime += 0.5f;
        if (Mathf.Floor(gameTime) - currentDay >= 0.99f)
            NewDay();
        else
            changeWindowView();
    }

    void changeWindowView()
    {
        if (gameTime - Mathf.Floor(gameTime) >= 0.5f)
        {
            windowView.sprite = night;
        }

        else
        {
            windowView.sprite = day;
        }
    }
}
