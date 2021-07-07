using strange.extensions.mediation.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMediator : EventMediator
{
    [Inject]
    public StartView StartView { get; set; }

    public override void OnRegister()
    {
        StartView.Btn_JIABEI.onClick.AddListener(OnJiaBeiClick);
        StartView.Btn_BUJIABEI.onClick.AddListener(OnBuJiaBeiClick);
    }

    public override void OnRemove()
    {
        StartView.Btn_JIABEI.onClick.RemoveListener(OnJiaBeiClick);
        StartView.Btn_BUJIABEI.onClick.RemoveListener(OnBuJiaBeiClick);
    }

    private void OnJiaBeiClick()
    {
        //1. 改model
        //2. 删除面板
        dispatcher.Dispatch(CommandEvent.ChangeMulitiple, 1);
        Destroy(StartView.gameObject);
        Debug.Log("1");
    }

    private void OnBuJiaBeiClick()
    {
        dispatcher.Dispatch(CommandEvent.ChangeMulitiple, 2);
        Destroy(StartView.gameObject);
        Debug.Log("2");
    }
}
