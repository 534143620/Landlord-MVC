﻿using strange.extensions.context.impl;
using strange.extensions.context.api;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameContext : MVCSContext
{
    public GameContext(MonoBehaviour view, bool autoMapping) : base(view, autoMapping)
    {

    }

    protected override void mapBindings()
    {
        Debug.Log("start");
        //model
        injectionBinder.Bind<IntegrationModel>().To<IntegrationModel>().ToSingleton();

        //command

        //view 
        commandBinder.Bind(ContextEvent.START).To<StartCommand>().Once();
    }
}