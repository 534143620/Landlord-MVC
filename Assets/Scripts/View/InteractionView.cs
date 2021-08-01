using strange.extensions.mediation.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InteractionView : View
{
    private Button Player;

    private Button Grab;
    private Button DisGrab;

    private Button Deal;
    private Button Pass;

    protected override void Awake()
    {
        Player = transform.Find("Player").GetComponent<Button>();
        Grab = transform.Find("Grab").GetComponent<Button>();
        DisGrab = transform.Find("DisGrab").GetComponent<Button>();
        Deal = transform.Find("Deal").GetComponent<Button>();
        Pass = transform.Find("Pass").GetComponent<Button>();
        base.Awake();
    }

    /// <summary>
    /// 全部隐藏
    /// </summary>
    public void DeactiveAll()
    {
        Player.gameObject.SetActive(false);
        Grab.gameObject.SetActive(false);
        DisGrab.gameObject.SetActive(false);
        Deal.gameObject.SetActive(false);
        Pass.gameObject.SetActive(false);
    }
    /// <summary>
    /// 显示发牌
    /// </summary>
    public void ActivePlay()
    {
        Player.gameObject.SetActive(true);
        Grab.gameObject.SetActive(false);
        DisGrab.gameObject.SetActive(false);
        Deal.gameObject.SetActive(false);
        Pass.gameObject.SetActive(false);
    }

    /// <summary>
    /// 显示抢地主
    /// </summary>
    public void ActiveGrabAndDisGrab()
    {
        Player.gameObject.SetActive(false);
        Grab.gameObject.SetActive(true);
        DisGrab.gameObject.SetActive(true);
        Deal.gameObject.SetActive(false);
        Pass.gameObject.SetActive(false);
    }
    /// <summary>
    /// 显示出牌按钮
    /// </summary>
    public void ActiveDealAndPass(bool isActive = true)
    {
        Player.gameObject.SetActive(false);
        Grab.gameObject.SetActive(false);
        DisGrab.gameObject.SetActive(false);
        Deal.gameObject.SetActive(true);
        Pass.gameObject.SetActive(true);
        Pass.interactable = isActive;   //有时候会不能Pass
    }

}
