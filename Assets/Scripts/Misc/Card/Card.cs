﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 每一张牌持有的数据
/// </summary>
public class Card
{
    string cardName;
    Weight cardweight;
    Colors cardColor;
    CharacterType belongTo;

    public string CardName { get => cardName; }
    public Weight Cardweight { get => cardweight;}
    public Colors CardColor { get => cardColor;}
    public CharacterType BelongTo { get => belongTo; set => belongTo = value; }

    /// <summary>
    /// 初始化参数
    /// </summary>
    /// <param name="name">卡牌名字</param>
    /// <param name="color">卡牌花色</param>
    /// <param name="weight">卡牌大小</param>
    /// <param name="type">归属于谁</param>
    public Card(string name,Colors color,Weight weight,CharacterType type)
    {
        this.cardName = name;
        this.cardColor = color;
        this.cardweight = weight;
        this.belongTo = type;
    }
}
