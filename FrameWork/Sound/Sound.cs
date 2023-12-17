using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoSingleTon<Sound>
{
    public string ResourcePath = "";

    private AudioSource m_bgSound;
    
    private AudioSource m_effectSound;
    
    public float BgVolume
    {
        get
        {
            return m_bgSound.volume;
        }
        set
        {
            m_bgSound.volume = value;
        }
    }
    
    public float EffectVolume
    {
        get
        {
            return m_effectSound.volume;
        }
        set
        {
            m_effectSound.volume = value;
        }
    }

    protected override void Awake()
    {
        base.Awake();
        
        //创建背景音乐
        m_bgSound = gameObject.AddComponent<AudioSource>();
        
        //创建音效
        m_effectSound = gameObject.AddComponent<AudioSource>();
        
        //设置音效播放模式
        m_effectSound.playOnAwake = false;
        
        //设置背景音乐循环播放
        m_bgSound.loop = true;
    }
    
    public void PlayBg(string audioName)
    {
        string oldName;

        if (m_bgSound.clip==null)
        {
            oldName="";
        }
        else
        {
            oldName = m_bgSound.clip.name;
        }

        if (oldName!=audioName)
        {
            string path;

            if (string.IsNullOrEmpty(ResourcePath))
            {
                path = "";
            }
            else
            {
                path=ResourcePath+"/"+audioName;
            }
            
            //加载背景音乐
            AudioClip clip = Resources.Load<AudioClip>(path);
            
            //播放
            if (clip!=null)
            {
                m_bgSound.clip = clip;
                m_bgSound.Play();
            }
        }
    }
    
    //停止播放
    public void StopBg()
    {
        m_bgSound.Stop();
    }
    
    //播放音效
    public void PlayEffect(string audioName)
    {
        string path;

        if (string.IsNullOrEmpty(ResourcePath))
        {
            path = "";
        }
        else
        {
            path=ResourcePath+"/"+audioName;
        }
        
        //加载音效
        AudioClip clip = Resources.Load<AudioClip>(path);
        
        //播放
        if (clip!=null)
        {
            m_effectSound.PlayOneShot(clip);
        }
    }
}
