using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public int maxHunger = 50;
    public int currentHunger;
    public HungerBar hungerBar;

    public int maxSanity = 50;
    public int currentSanity;
    public SanityBar sanityBar;

    public int maxPower = 50;
    public int currentPower;
    public PowerBar powerBar;

    // Start is called before the first frame update
    void Start()
    {
        currentHunger = maxHunger;
        hungerBar.SetMaxHunger(maxHunger);

        currentSanity = maxSanity;
        sanityBar.SetMaxSanity(maxSanity);

        currentPower = maxPower;
        powerBar.SetMaxPower(maxPower);




    }

    // Update is called once per frame

    void loseHunger(int hunger)
    {
        currentHunger -= hunger;

        hungerBar.SetHunger(currentHunger);
    }

    void loseSanity(int sanity)
    {
        currentSanity -= sanity;

        sanityBar.SetSanity(currentSanity);
    }

    void losePower(int power)
    {
        currentPower -= power;

        powerBar.SetPower(currentPower);
    }



    void gainHunger(int hunger)
    {
        currentHunger += hunger;

        hungerBar.SetHunger(currentHunger);
    }

    void gainSanity(int sanity)
    {
        currentSanity += sanity;

        sanityBar.SetSanity(currentSanity);
    }

    void gainPower(int power)
    {
        currentPower += power;

        powerBar.SetPower(currentPower);
    }

}
