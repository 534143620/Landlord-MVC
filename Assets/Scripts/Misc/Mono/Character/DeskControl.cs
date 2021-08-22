using Lean.Pool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeskControl : CharacterBase
{
    public DeskUI deskUI;
    /// <summary>
    /// player computer 手牌
    /// </summary>
    List<Card> playercardList = new List<Card>();
    List<Card> computerLeftcardList = new List<Card>();
    List<Card> computerRightcardList = new List<Card>();

    public List<Card> PlayercardList { get => playercardList;}
    public List<Card> ComputerLeftcardList { get => computerLeftcardList;}
    public List<Card> ComputerRightcardList { get => computerRightcardList;}

    /// <summary>
    /// player computer 生成位置
    /// </summary>
    Transform playerPoint;
    public Transform PlayerPoint
    {
        get
        {
            if (playerPoint == null)
                playerPoint = transform.Find("PlayerPoint");
            return playerPoint;
        }
    }

    Transform computerLeftPoint;
    public Transform ComputerLeftPoint
    {
        get
        {
            if (computerLeftPoint == null)
                computerLeftPoint = transform.Find("ComputerLeftPoint");
            return computerLeftPoint;
        }
    }

    Transform computerRightPoint;
    public Transform ComputerRightPoint
    {
        get
        {
            if (computerRightPoint == null)
                computerRightPoint = transform.Find("ComputerRightPoint");
            return computerRightPoint;
        }
    }

    public void SetShowCard(Card card,int index)
    {
        deskUI.SetShowCard(card,index);
    }

    public void CreateCardUI(Card card, int index, bool isSelected,ShowPoint pos)
    {
        //对象池生成
        GameObject go = LeanPool.Spawn(prefab);
        go.name = characterType.ToString() + index.ToString();
        //设置位置和是否选中
        CardUI cardUI = go.GetComponent<CardUI>();
        cardUI.Card = card;
        cardUI.IsSelected = isSelected;
        switch (pos)
        {
            case ShowPoint.Desk:
                cardUI.SetPosition(CreatePoint, index);
                break;
            case ShowPoint.Player:
                cardUI.SetPosition(playerPoint, index);
                break;
            case ShowPoint.ComputerRight:
                cardUI.SetPosition(ComputerRightPoint, index);
                break;
            case ShowPoint.ComputerLeft:
                cardUI.SetPosition(computerLeftPoint, index);
                break;
            default:
                break;
        }
        //cardUI.SetPosition(CreatePoint, index);
    }

    public void AddCard(Card card, bool selected, ShowPoint pos)
    {
        switch (pos)
        {
            case ShowPoint.Desk:
                CardList.Add(card);
                card.BelongTo = characterType;  
                CreateCardUI(card, CardList.Count - 1, selected,pos);
                break;
            case ShowPoint.Player:
                PlayercardList.Add(card);
                card.BelongTo = characterType;  
                CreateCardUI(card, PlayercardList.Count - 1, selected, pos);
                break;
            case ShowPoint.ComputerRight:
                ComputerRightcardList.Add(card);
                card.BelongTo = characterType;  
                CreateCardUI(card, ComputerRightcardList.Count - 1, selected, pos);
                break;
            case ShowPoint.ComputerLeft:
                ComputerLeftcardList.Add(card);
                card.BelongTo = characterType;  
                CreateCardUI(card, ComputerLeftcardList.Count - 1, selected, pos);
                break;
            default:
                break;
        }
        //cardList.Add(card);
        //card.BelongTo = characterType;  //牌创建出来属于哪个角色
        //CreateCardUI(card, cardList.Count - 1, selected);
    }

    /// <summary>
    /// 桌面清空
    /// </summary>
    /// <param name="pos"></param>
    public void Clear(ShowPoint pos)
    {
        switch (pos)
        {
            case ShowPoint.Desk:
                CardList.Clear();
                CardUI[] cardUIs = CreatePoint.GetComponentsInChildren<CardUI>();
                for (int i = 0; i < cardUIs.Length; i++)      
                    cardUIs[i].Destroy();            
                break;
            case ShowPoint.Player:
                PlayercardList.Clear();
                CardUI[] cardUIPlayer = PlayerPoint.GetComponentsInChildren<CardUI>();
                for (int i = 0; i < cardUIPlayer.Length; i++)
                    cardUIPlayer[i].Destroy();
                break;
            case ShowPoint.ComputerRight:
                ComputerRightcardList.Clear();
                CardUI[] cardUIRight = ComputerRightPoint.GetComponentsInChildren<CardUI>();
                for (int i = 0; i < cardUIRight.Length; i++)
                    cardUIRight[i].Destroy();
                break;
            case ShowPoint.ComputerLeft:
                ComputerLeftcardList.Clear();
                CardUI[] cardUILeft = ComputerLeftPoint.GetComponentsInChildren<CardUI>();
                for (int i = 0; i < cardUILeft.Length; i++)
                    cardUILeft[i].Destroy();
                break;
            default:
                break;
        }
    }

}
