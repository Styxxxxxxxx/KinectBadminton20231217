using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// 全局唯一单例控制器
/// </summary>
[RequireComponent(typeof(ObjectPool))]
[RequireComponent(typeof(Sound))]
[RequireComponent(typeof(StaticData))]
public class GameMgr : ApplicationBase<GameMgr>
{
    /// <summary>
    /// 全局唯一的对象池
    /// </summary>
    [HideInInspector]
    public ObjectPool objectPool= null;
    
    /// <summary>
    /// 全局唯一的声音管理器
    /// </summary>
    [HideInInspector]
    public Sound sound = null;
    
    /// <summary>
    /// 全局唯一的常量管理器
    /// </summary>
    [HideInInspector]
    public StaticData staticData = null;

    private void Start()
    {
        // Game对象不会被销毁 
        // 作为全局唯一的游戏管理器一直存在
        DontDestroyOnLoad(this.gameObject);
        
        // 初始化全局唯一的声音管理器
        sound=Sound.Instance;
        
        // 初始化全局唯一的对象池管理器
        objectPool=ObjectPool.Instance;
        
        // 初始化全局唯一的常量管理器
        staticData=StaticData.Instance;
        
        // 注册启动命令
        RegisterController(Consts.E_StartGame,typeof(StartGameCommand));
        
        // 启动游戏
        SendEvent(Consts.E_StartGame);
        
        Debug.Log("GameMgr Start");
    }
    
    /// <summary>
    /// 加载场景
    /// </summary>
    /// <param name="sceneIndex">要加载的场景序号</param>
    public void LoadScene(int sceneIndex)
    {
        // 退出当前场景
        
        // 事件参数
        SceneArgs sceneArgs=new SceneArgs();

        // 将当前场景序号赋值给事件参数
        sceneArgs.SceneIndex = SceneManager.GetActiveScene().buildIndex;
        
        // 发送退出场景事件
        SendEvent(Consts.E_ExitScene,sceneArgs);
        
        // 加载新场景
        
        SceneManager.LoadScene(sceneIndex,LoadSceneMode.Single);

        //AsyncOperation ao= SceneManager.LoadSceneAsync(sceneIndex,LoadSceneMode.Single)
        
    }
    
    public void OnSceneWasLoaded(int sceneIndex)
    {
        Debug.Log($"On Scene was Loaded:{sceneIndex}");
        
        SceneArgs sceneArgs=new SceneArgs();
        
        sceneArgs.SceneIndex = sceneIndex;
        
        SendEvent(Consts.E_EnterScene,sceneArgs);
    }
}
