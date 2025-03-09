using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Store : MonoBehaviour
{
    public bool skipTimer = false;
    public bool tripleEggs = false;

    public float winsMultiplier = 1f;
    public float powerMultiplier = 1f;
    public int coins = 1000;
    
    public TextMeshProUGUI coinText;
    public TextMeshProUGUI winsMultiplierText;
    public TextMeshProUGUI powerMultiplierText;
    public TextMeshProUGUI skipTimerText;
    public TextMeshProUGUI tripleEggsText;

    private void Update()
    {
        coinText.text = coins.ToString();
        winsMultiplierText.text = winsMultiplier.ToString();
        powerMultiplierText.text = powerMultiplier.ToString();
        skipTimerText.text = skipTimer.ToString();
        tripleEggsText.text = tripleEggs.ToString();
    }

    #region покупка множителя силы

    public void Buy2XPower()
    {
        if (coins >= 29)
        {
            coins -= 29;
            if (powerMultiplier == 1f)
            {
                powerMultiplier = 2f;
            }
            else
            {
                powerMultiplier += 2f;
            }
        }
    }

    public void Buy3XPower()
    {
        if (coins >= 34)
        {
            coins -= 34;
            if (powerMultiplier == 1f)
            {
                powerMultiplier = 3f;
            }
            else
            {
                powerMultiplier += 3f;
            }
        }
    }

    #endregion

    #region Покупка множителя побед

    public void Buy2XWins()
    {
        if (coins >= 29)
        {
            coins -= 29;
            if (winsMultiplier == 1f)
            {
                winsMultiplier = 2f;
            }
            else
            {
                winsMultiplier += 2f;
            }
        }
    }

    public void Buy3XWins()
    {
        if (coins >= 34)
        {
            coins -= 34;
            if (winsMultiplier == 1f)
            {
                winsMultiplier = 3f;
            }
            else
            {
                winsMultiplier += 3f;
            }
        }
    }

    #endregion

    public void BuySkipTimer()
    {
        if (!skipTimer && coins >= 19)
        {
            coins -= 19;
            skipTimer = true;
        }
    }

    public void BuyTripleEggs()
    {
        if (!tripleEggs && coins >= 25)
        {
            coins -= 25;
            tripleEggs = true;
        }
    }

    public void BuyVIP()
    {
        if (coins >= 29)
        {
            coins -= 29;
            if (winsMultiplier == 1f)
            {
                winsMultiplier = 1 * 1.5f ;
            }
            else
            {
                winsMultiplier = winsMultiplier * 1.5f;
            }

            if (powerMultiplier == 1f)
            {
                powerMultiplier = 1 * 1.5f;
            }
            else
            {
                powerMultiplier = powerMultiplier * 1.5f;
            }
        }
    }

    public void BuyPRO()
    {
        if (coins >= 39)
        {
            coins -= 39;
            if (winsMultiplier == 1f)
            {
                winsMultiplier = 2f;
            }
            else
            {
                winsMultiplier += 2f;
            }

            if (powerMultiplier == 1f)
            {
                powerMultiplier = 2f;
            }
            else
            {
                powerMultiplier += 2f;
            }
        }
    }

    public void BuyMVP()
    {
        if (coins >= 49)
        {
            coins -= 49;
            if (winsMultiplier == 1f)
            {
                winsMultiplier = 3f;
            }
            else
            {
                winsMultiplier += 3f;
            }

            if (powerMultiplier == 1f)
            {
                powerMultiplier = 3f;
            }
            else
            {
                powerMultiplier += 3f;
            }
        }
    }
}
