using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardUI : MonoBehaviour
{
    Card card;
    Image image;
    bool isSelected;

    public Card Card
    {
        get => card;
        set
        {
            card = value;
            SetImage();
        }
    }

    /// <summary>
    /// 设置图片
    /// </summary>
    public void SetImage()
    {
        if(card.BelongTo == CharacterType.Player||card.BelongTo==CharacterType.Desk)
        {
            image.sprite = Resources.Load<Sprite>("Poker/"+card.CardName);
        }
        else //电脑的话 显示背面
        {
            image.sprite = Resources.Load<Sprite>("Poker/FixedBack");   
        }

    }

    /// <summary>
    /// 第一次地主牌
    /// </summary>
    public void SetImageAgain()
    {
        image.sprite = Resources.Load<Sprite>("Poker/CardBack");
    }
}
