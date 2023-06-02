using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Serialization;

public class CoinManager : Singleton<CoinManager>
{
   [SerializeField] private int _coinAmount = 100;

    public int CoinAmount
    {
        get { return _coinAmount; }
        set
        {
            if (value < 0)
            {
                _coinAmount = 0;
                return;
            }
            _coinAmount = value;
        }
    }

    [SerializeField] private TMP_Text moneyAmountText;

    public bool SpendCoin(int amount)
    {
        if (CoinAmount - amount > 0)
        {
            CoinAmount -= amount;
            moneyAmountText.SetText( _coinAmount.ToString());
            return true;
        }
        else
        {
            return false;
        }
    }

    public void GainCoin(int amount)
    {
        CoinAmount += amount;
        moneyAmountText.SetText( _coinAmount.ToString());
        
        //Play Audio gain coin
    }

    private void Start()
    {
        moneyAmountText.SetText( _coinAmount.ToString());
    }
}