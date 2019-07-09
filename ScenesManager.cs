using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager
{
    /// <summary>
    /// ScenesManager单例
    /// </summary>
    private static ScenesManager _instance;
    public static ScenesManager Instance()
    {
        if (_instance == null)
            _instance = new ScenesManager();
        return _instance;
    }

    /// <summary>
    /// 关卡名
    /// </summary>
    private string _sceneName;
    public string SceneName
    { get { return _sceneName; } }

    /// <summary>
    /// 是否是第二次进入关卡
    /// </summary>
    public bool isPowerOn;

    /// <summary>
    /// 无参构造
    /// </summary>
    ScenesManager() { _sceneName  = SceneManager.GetActiveScene().name; isPowerOn = false; }

    /// <summary>
    /// 重新加载当前SceneManager.LoadScene关卡
    /// </summary>
    public void SceneLoad()
    {
        //GameObject.FindGameObjectWithTag("bgm").GetComponent<bgmMgr>().fadeIn();
        _sceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(_sceneName);
        isPowerOn = true;
    }
    /// <summary>
    /// 重新加载当前SceneManager.LoadScene关卡
    /// <param name="idx">关卡下表</param>
    /// </summary>
    public void SceneLoad(int idx)

    {
        //GameObject.FindGameObjectWithTag("bgm").GetComponent<bgmMgr>().fadeIn();

        SceneManager.LoadScene(idx - 1);
        isPowerOn = false;
    }

    /// <summary>
    /// 加载关卡
    /// </summary>
    /// <param name="sceneName">关卡名</param>
    public void SceneLoad(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        isPowerOn = false;
        //DirSave.Instance().ClearContent();
    }



}
