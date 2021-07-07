using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntegrationModel 
{
    /// <summary>
    /// 底分
    /// </summary>
    public int BasePoint;
    /// <summary>
    /// 倍数
    /// </summary>
    public int Mulitiple;
    /// <summary>
    /// 一轮积分
    /// </summary>
    public int Result
    {
        get
        {
            return (Mulitiple * BasePoint);
        }
    }

    public int PlayerIntegtation
    {
        get => playerIntegtation;
        set
        {
            if (value < 0)
                playerIntegtation = 0;
            else
                playerIntegtation = value;
        }
    }
    public int ComputerLeftIntegration
    {
        get => computerLeftIntegration;
        set
        {
            if (value < 0)
                computerLeftIntegration = 0;
            else
                computerLeftIntegration = value;
        }
    }
    public int ComputerRightIntegration
    {
        get => computerRightIntegration;
        set
        {
            if (value < 0)
                computerRightIntegration = 0;
            else
                computerRightIntegration = value;
        }
    }

    private int playerIntegtation;

    private int computerLeftIntegration;

    private int computerRightIntegration;

    public void InitIntegration()
    {
        Mulitiple = 1;
        BasePoint = 100;
        PlayerIntegtation = 1000;
        ComputerLeftIntegration = 1000;
        ComputerRightIntegration = 1000;
    }
}
