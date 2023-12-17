using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameCommand : Controller
{
    public override void Execute(object args = null)
    { 
        // 注册模型
        
        
        // 注册命令
        RegisterController(Consts.E_EnterScene,typeof(EnterSceneCommand));
        
        RegisterController(Consts.E_ExitScene,typeof(ExitSceneCommand));
        
        
        // 进入开始界面
        GameMgr.Instance.LoadScene(0);
    }
}
