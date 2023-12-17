using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 总对象池
/// </summary>
public class ObjectPool:MonoSingleTon<ObjectPool>
{
    /// <summary>
    /// 资源路径
    /// </summary>
    public string ResourcePath = "";
    
    /// <summary>
    /// 所有子对象池集合
    /// </summary>
    Dictionary<string,SubPool> m_pools = new Dictionary<string, SubPool>();
    
    /// <summary>
    /// 取对象
    /// </summary>
    /// <param name="name">要取出的子对象池名字</param>
    /// <returns>返回子对象池集合</returns>
    public GameObject Spawn(string name)
    {
        SubPool pool = null;
        
        //如果没有该集合
        if (!m_pools.ContainsKey(name))
        {
            //创建集合
            RegisterNew(name);
        }
        
        pool = m_pools[name];
        
        return pool.Spawn();
    }
    
    /// <summary>
    /// 回收对象
    /// </summary>
    /// <param name="go">要进行回收的子对象池</param>
    public void UnSpawn(GameObject go)
    {
        SubPool pool= null;
        
        //遍历所
        foreach (SubPool p in m_pools.Values)
        {
            //如果找到
            if (p.Contains(go))
            {
                pool = p;
                break;
            }
        }
        
        pool.UnSpawn(go);
    }
    
    //回收所有对象
    public void UnSpawnAll()
    {
        foreach (SubPool pool in m_pools.Values)
        {
            pool.UnSpawnAll();
        }
    }
    
    /// <summary>
    /// 创建新子对象池
    /// </summary>
    /// <param name="name"></param>
    void RegisterNew(string name)
    {
        //预设路径
        string path = "";
        
        if (string.IsNullOrEmpty(ResourcePath))
        {
            path = name;
        }
        else
        {
            path = ResourcePath + "/" + name;
        }
        
        //加载预设
        GameObject prefab = Resources.Load<GameObject>(path);
        
        //创建集合
        SubPool pool = new SubPool(prefab);
        
        //加入字典
        m_pools.Add(pool.Name,pool);
    }
}
