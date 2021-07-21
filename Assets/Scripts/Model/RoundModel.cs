using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// 回合数据
/// </summary>
public class RoundModel
{
    public static event Action PlayerHander;
    public static event Action ComputerHander;

    int currentWeight;
    int currentLength;
    CardType currentType;
    CharacterType biggestCharacter;
    CharacterType currentCharacter;

    /// <summary>
    /// 最大出牌的出牌大小
    /// </summary>
    public int CurrentWeight { get => currentWeight; set => currentWeight = value; }
    /// <summary>
    /// 出牌长度
    /// </summary>
    public int CurrentLength { get => currentLength; set => currentLength = value; }
    /// <summary>
    ///  最大出牌者
    /// </summary>
    public CharacterType BiggestCharacter { get => biggestCharacter; set => biggestCharacter = value; }
    /// <summary>
    /// 现在该谁出牌
    /// </summary>
    public CharacterType CurrentCharacter { get => currentCharacter; set => currentCharacter = value; }
    /// <summary>
    /// 现在出牌类型
    /// </summary>
    public CardType CurrentType { get => currentType; set => currentType = value; }

    public void InitRound()
    {
        this.currentType = CardType.None;
        this.currentWeight = -1;
        this.currentLength = -1;
        this.biggestCharacter = CharacterType.Desk;
        this.currentCharacter = CharacterType.Desk;
    }

    /// <summary>
    /// 抢地主的人触发
    /// </summary>
    /// <param name="cType"></param>
    public void Start(CharacterType cType)
    {
        this.biggestCharacter = cType;
        this.currentCharacter = cType;
        BeginWidth(cType);
    }

    /// <summary>
    /// 出牌
    /// </summary>
    /// <param name="cType"></param>
    public void BeginWidth(CharacterType cType)
    {
        if(cType == CharacterType.Player)
        {
            //玩家出牌
            if (PlayerHander != null)
                PlayerHander();
        }
        else
        {
            //电脑出牌
            if (ComputerHander != null)
                ComputerHander();
        }
    }

    /// <summary>
    /// 轮换出牌
    /// </summary>
    public void Turn()
    {
        currentCharacter++;
        if (currentCharacter == CharacterType.Desk || currentCharacter == CharacterType.Library)
            currentCharacter = CharacterType.Player;
        BeginWidth(currentCharacter);
    }



}
