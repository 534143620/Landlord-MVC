using strange.extensions.mediation.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StartView : View
{
    public Button Btn_JIABEI;
    public Button Btn_BUJIABEI;
    protected override void Awake()
    {
        Btn_JIABEI = transform.Find("Btn_JIABEI").GetComponent<Button>();
        Btn_BUJIABEI = transform.Find("Btn_BUJIABEI").GetComponent<Button>();
        base.Awake();
    }
}
