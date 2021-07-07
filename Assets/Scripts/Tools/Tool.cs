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
}
