using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplicationBase<T> : MonoSingleTon<T>
    where T:MonoBehaviour
{
   protected void RegisterController(string eventName, System.Type controllerType)
    {
        MVC.RegisterController(eventName,controllerType);
    }
   
    protected void SendEvent(string eventName,System.Object args=null)
    {
        MVC.SendEvent(eventName,args);
    }
    
}
