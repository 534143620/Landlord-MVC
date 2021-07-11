using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Consts
{
  
}
public enum PanelType
{
    StartPanel
}
public enum CommandEvent
{
    ChangeMulitiple
}

public enum ViewEvent
{
    ChangeMulitiple
}

/// <summary>
/// 持有牌的角色
/// </summary>
public enum CharacterType
{
    Library,
    Player,
    ComputerLeft,
    ComputerRight,
    Desk
}

/// <summary>
/// 牌的花色
/// </summary>
public enum Colors
{
    None,   //小王 大王
    Club,   //梅花 
    Heart,  //红桃
    Spade,  //黑桃
    Square  //方块    
}

/// <summary>
/// 牌的大小
/// </summary>
public enum Weight 
{
    Three,
    Four,
    Five,
    Six,
    Seven,
    Eight,
    Nine,
    Ten,
    Jack,
    Queen,
    King,
    One,
    Two,
    SJoker,
    LJoker
}

/// <summary>
/// 牌的类型
/// </summary>
public enum CardType
{
    Single,     //单
    Double,     //对
    Straight,   //顺子
    DoubleStraight,   //双顺   55 66 
    TripleStraight,   //飞机  555666
    Three,            //三不带  333
    ThreeAndOne,      //三带一  3331
    ThreeAndTwo,      //三带二  33311
    Boom,             //炸弹 
    JokerBoom         //王炸

}

/// <summary>
/// 牌的身份
/// </summary>
public enum Identity
{
    Farmer,
    Landlord
}
