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

    public int maxEnergy = 50;
    public int currentEnergy;
    public EnergyBar energyBar;

    private static bool newDay;


    // Start is called before the first frame update
    void Start()
    {
        currentHunger = maxHunger;
        hungerBar.SetMaxHunger(maxHunger);

        currentSanity = maxSanity;
        sanityBar.SetMaxSanity(maxSanity);

        currentPower = maxPower;
        powerBar.SetMaxPower(maxPower);

        currentEnergy = maxEnergy;
        energyBar.SetMaxEnergy(maxEnergy);



    }

    // Update is called once per frame
    void Update()
    {
        newDay = DayChange.newDay;
        if (newDay)
        {
            loseHunger(1);
            DayChange.newDay = false;
        }

    }

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

    void loseEnergy(int energy)
    {
        currentEnergy -= energy;

        energyBar.SetEnergy(currentEnergy);
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

    void gainEnergy(int energy)
    {
        currentEnergy += energy;

        energyBar.SetEnergy(currentEnergy);
    }
}
