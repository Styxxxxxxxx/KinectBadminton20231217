using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 子对象池
/// </summary>
public class SubPool : MonoBehaviour
{
    //预设
    GameObject m_prefab;
    
    //集合
    List<GameObject> m_objects = new List<GameObject>();
    
    //名字
    public string Name
    {
        get { return m_prefab.name; }
    }
    
    //构造函数
    public SubPool(GameObject prefab)
    {
        this.m_prefab = prefab;
    }
    
    //取对象
    public GameObject Spawn()
    {
        //要返回的对象
        GameObject go = null;
        
        //遍历集合查找未激活的对象
        foreach (GameObject obj in m_objects)
        {
            if (!obj.activeSelf)
            {
                go = obj;
                break;
            }
        }
        
        //如果没找到 创建新对象
        if (go == null)
        {
            //实例化
            go = GameObject.Instantiate<GameObject>(m_prefab);
            
            //加入集合
            m_objects.Add(go);
        }
        
        //激活
        go.SetActive(true);
        
        //发送消息
        go.SendMessage("OnSpawn", SendMessageOptions.DontRequireReceiver);
        
        //返回
        return go;
    }
    
    //回收对象
    public void UnSpawn(GameObject go)
    {
        if (Contains(go))
        {
            //发送消息
            go.SendMessage("OnUnSpawn", SendMessageOptions.DontRequireReceiver);
            
            //隐藏
            go.SetActive(false);
        }
    }
    
    //回收所有对象
    public void UnSpawnAll()
    {
        foreach (GameObject obj in m_objects)
        {
            if (obj.activeSelf)
            {
                UnSpawn(obj);
            }
        }
    }
    
    //是否包含对象
    public bool Contains(GameObject go)
    {
        return m_objects.Contains(go);
    }
}
