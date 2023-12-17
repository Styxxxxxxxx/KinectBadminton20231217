using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 模型基类
/// </summary>
public abstract class Model 
{
    /// <summary>
    /// 只读属性，模型名字
    /// </summary>
    public abstract string Name { get; }
    
    protected void SendEvent(string eventName,object data = null)
    {
        MVC.SendEvent(eventName,data);
    }
    
    
}
