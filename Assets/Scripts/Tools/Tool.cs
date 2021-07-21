using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Tool 
{
    static Transform uiParent;

    public static Transform UiParent
    {
        get
        {
            if (uiParent == null)
                uiParent = GameObject.Find("Canvas").transform;
            return uiParent;
        } 
    }

    /// <summary>
    /// 生成Panel
    /// </summary>
    /// <param name="type">面板类型</param>
    /// <returns></returns>
    public static GameObject CreateUIPanel(PanelType type)
    {
        GameObject go = Resources.Load<GameObject>(type.ToString());
        if(go == null)
        {
            Debug.Log(type.ToString() + "不存在");
            return null;
        }
        else
        {
            GameObject panel = GameObject.Instantiate(go);
            panel.name = type.ToString();
            panel.transform.SetParent(UiParent,false);
            return go;
        }
    }

    ///如何对类进行简单的排序
    /// <summary>
    /// 排序  
    /// </summary>
    /// <param name="cards">要排序的牌</param>
    /// <param name="asc">升序</param>
    public static void Sort(List<Card>cards,bool asc)
    {
        cards.Sort((Card a,Card b) => 
        {
            if (asc)
                return a.Cardweight.CompareTo(b.Cardweight);
            else
                return -a.Cardweight.CompareTo(b.Cardweight);
        });
    }

    //如何获取牌的大小，此处并不是很懂，感觉有BUG后续
    /// <summary>
    /// 获取牌的大小
    /// </summary>
    /// <param name="cards">出的牌</param>
    /// <param name="cardType">出牌类型</param>
    /// <returns></returns>
    public static int GetWegiht(List<Card>cards,CardType cardType)
    {
        int totalWeight = 0;

        if(cardType == CardType.ThreeAndOne || cardType == CardType.ThreeAndTwo)
        {
            for (int i = 0; i < cards.Count; i++)
            {
                if (cards[i].Cardweight == cards[i + 1].Cardweight && cards[i].Cardweight == cards[i + 2].Cardweight)
                {
                    totalWeight += (int)cards[i].Cardweight;
                    totalWeight *= 3;
                    break;
                }
            }
        }else if (cardType == CardType.Straight || cardType == CardType.DoubleStraight)
        {
            totalWeight = (int)cards[0].Cardweight;
        }
        else
        {
            for (int i = 0; i < cards.Count; i++)
            {
                totalWeight += (int)cards[i].Cardweight;
            }
        }
        return totalWeight;
    }
}
