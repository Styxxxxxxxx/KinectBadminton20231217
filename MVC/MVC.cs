using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// MVC框架的核心类
/// </summary>
public static class MVC
{
   /// <summary>
   /// 存储所有的模型
   /// </summary>
   public static Dictionary<string, Model> Models = new Dictionary<string, Model>();

   /// <summary>
   /// 存储所有的视图
   /// </summary>
   public static Dictionary<string, View> Views = new Dictionary<string, View>();

   /// <summary>
   /// 存储所有的控制器
   /// </summary>
   public static Dictionary<string, Type> ComandMap= new Dictionary<string, Type>();
   
   /// <summary>
   /// 注册模型
   /// </summary>
   /// <param name="model">要注册的模型</param>
   public static void RegisterModel(Model model)
   {
      Models[model.Name] = model;
   }
   
   /// <summary>
   /// 注册视图
   /// </summary>
   /// <param name="view">要注册的视图</param>
   public static void RegisterView(View view)
   {
      Views[view.Name] = view;
   }
   
   /// <summary>
   /// 注册事件
   /// </summary>
   /// <param name="eventName">事件名称</param>
   /// <param name="controllerType">事件类型</param>
   public static void RegisterController(string eventName,Type controllerType)
   {
      ComandMap[eventName] = controllerType;
   }

   
   /// <summary>
   /// 获取模型
   /// </summary>
   /// <typeparam name="T">模型类型</typeparam>
   /// <returns>返回所需模型</returns>
   public static Model GetModel<T>() where T : Model
   {
      foreach (var VARIABLE in Models.Values)
      {
         if (VARIABLE is T)
         {
            return VARIABLE;
         }
      }

      return null;
   }
   
   /// <summary>
   /// 获取视图
   /// </summary>
   /// <param name="modelName">视图名称</param>
   /// <typeparam name="T">视图类型</typeparam>
   /// <returns>返回所需视图</returns>
   public static View GetView<T>() where T : View
   {
      foreach (var VARIABLE in Views.Values)
      {
         if (VARIABLE is T)
         {
            return VARIABLE;
         }
      }
      
      return null;
   }
   
   public static void SendEvent(string eventName,object data = null)
   {
      // 控制器响应事件
      if (ComandMap.ContainsKey(eventName))
      {
         Type t = ComandMap[eventName];
         Controller controller = Activator.CreateInstance(t) as Controller;
         controller.Execute(data);
      }
      
      // 视图响应事件
      foreach (var VARIABLE in Views.Values)
      {
         if (VARIABLE.attentionList.Contains(eventName))
         {
            // 视图响应事件
            VARIABLE.HandleEvent(eventName, data);
         }
      }
   }
}
