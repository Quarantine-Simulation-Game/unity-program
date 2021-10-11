using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakePurchase : MonoBehaviour
{
    Player playerProfile;
    GameController gameController;
    // Start is called before the first frame update
    void Start()
    {
        playerProfile = GameObject.Find("_Manager").GetComponent<Player>();
        gameController = GameObject.Find("_Manager").GetComponent<GameController>();
    }

    // Update is called once per frame
    public void PurchaseBoardUpgrade()
    {
        if(playerProfile.coin - 3 > 0 && gameController.gameStage+1<10)
        {
            playerProfile.coin = playerProfile.coin - 3;
            gameController.UpdateCoin();
            gameController.gameStage += 1;
            playerProfile.energy += 1;
        }
    }
}
