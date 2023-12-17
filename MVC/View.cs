using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class View : MonoBehaviour
{
    public abstract string Name { get; }
    
    [HideInInspector]
    public List<string> attentionList= new List<string>();

    public abstract void HandleEvent(string eventName,object data = null);
    
    protected Model GetModel<T>()
        where T:Model
    {
        return MVC.GetModel<T>();
    }
    
    protected void SendEvent(string eventName,object data = null)
    {
        MVC.SendEvent(eventName,data);
    }
}
