using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITrade
{
    void UpdateCoinCount();
    bool TradeSucceed(int cost);
    bool TradeSucceed(int cost, CharacterList character);
    void TradeFail();
}
