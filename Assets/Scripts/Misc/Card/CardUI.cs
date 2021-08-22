using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardUI : MonoBehaviour
{
    Card card;
    Image image;
    Button btn;
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
    /// 是否被点击
    /// </summary>
    public bool IsSelected {
        get
        {
            return isSelected;
        }

        set
        {
            if (card.BelongTo != CharacterType.Player || isSelected == value)
                return;


            if (value)
                transform.localPosition += Vector3.up * 10;
            else
                transform.localPosition -= Vector3.up * 10;

            isSelected = value;
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

    /// <summary>
    /// 设置为位置以及偏移
    /// </summary>
    /// <param name="parent">父物体</param>
    /// <param name="index">子物体索引</param>
    public void SetPosition(Transform parent,int index)
    {
        transform.SetParent(parent, false);
        transform.SetSiblingIndex(index);

        if(card.BelongTo == CharacterType.Desk || card.BelongTo == CharacterType.Player)
        {
            transform.localPosition = Vector3.right * index;

            //防止还原
            if(isSelected)
                transform.localPosition += Vector3.up * 10;

            if(card.BelongTo == CharacterType.ComputerLeft || card.BelongTo == CharacterType.ComputerRight)
            {
                transform.localPosition = Vector3.down * 8 + Vector3.left * 8;
            }
        }
    }

    /// <summary>
    /// 初始化数据
    /// </summary>
    public void OnSpawn()
    {
        image = GetComponent<Image>();
        btn = GetComponent<Button>();
        btn.onClick.AddListener(onClickBtn);
    }

    private void onClickBtn()
    {
        if (card.BelongTo == CharacterType.Player)
            IsSelected = !IsSelected;
    }

    /// <summary>
    /// 回收数据
    /// </summary>
    public void OnDespawn()
    {
        btn.onClick.RemoveListener(onClickBtn);
        isSelected = false;
        image.sprite = null;
        card = null;
    }

    public void Destroy()
    {
        Lean.Pool.LeanPool.Despawn(gameObject);
    }
}
