using strange.extensions.command.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCommand : Command
{
    [Inject]
    public IntegrationModel IntegrationModel { get; set; }
    /// <summary>
    /// 执行事件
    /// </summary>
    public override void Execute()
    {
        Tool.CreateUIPanel(PanelType.StartPanel);

        //初始化model
        IntegrationModel.InitIntegration();
    }
}
