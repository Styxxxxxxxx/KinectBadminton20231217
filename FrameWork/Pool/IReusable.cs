using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 可复用接口
/// </summary>
public interface IReusable 
{
    /// <summary>
    /// 取出时调用
    /// </summary>
    public void OnSpawn();
    
    /// <summary>
    /// 回收时调用
    /// </summary>
    public void OnUnSpawn();
}
