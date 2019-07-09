using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DirSave
{
    //第一步访问Txt文件
    string path;

    /// <summary>
    /// 文本的Data信息
    /// </summary>
    private List<string> _data = new List<string>();
    public List<string> Data
    {
        get
        {
            if(_data.Count == 0)
                ReadDirFromFIle();
            return _data;
        }
        //set { _data = value; }
    }

    /// <summary>
    /// DirSave单列
    /// </summary>
    private static DirSave _instance;
    public static DirSave Instance()
    {
        if (_instance == null)
            _instance = new DirSave();
        return _instance;
    }

    /// <summary>
    /// 关卡名
    /// </summary>
    private string _sceneName;


    /// <summary>
    /// 私有类型的
    /// 无参构造
    /// </summary>
    DirSave() { _sceneName = SceneManager.GetActiveScene().name; path = Application.dataPath + "/Resources/" + _sceneName+".txt"; ClearContent(); }
    //DirSave() { _sceneName = SceneManager.GetActiveScene().name; path = Application.dataPath + "/Resources/" + _sceneName+".txt"; /*ClearContent();*/}

    public void UpdateFile()
    { _sceneName = SceneManager.GetActiveScene().name; path = Application.dataPath + "/Resources/" + _sceneName + ".txt"; _data.Clear(); /*ClearContent();*/ }

    //********************************************策划看*********************************************************//
    //    上面的两句话，有ClearContent();的语句为覆盖，测试1周目用
    //     无为不覆盖，在一周目走完后换成没有ClearContent();的，可以测试二周目。
    //      测试二周目需要打开obj_zombie,关掉Obj_Player。
    //*************************************************************************************************************//



    /// <summary>
    /// 方向枚举
    /// </summary>
    public enum EDIR
    {
        eNone = -1,
        eUp,
        eDown,
        eLeft,
        eRight,
    }

    /// <summary>
    /// 保存文件
    /// </summary>
    /// <param name="eDir"></param>
    public void SaveDirToFile(EDIR eDir) 
    {
        UpdateFile();
        //文件读写流
        StreamReader sr = new StreamReader(path);
        //读取内容
        string result = sr.ReadToEnd();
        sr.Close();
        sr.Dispose();

        //文件流
        FileStream fs = File.OpenWrite(path);
        //第二步填充内容
        StringBuilder sb = new StringBuilder();
        sb.Append(result + eDir.GetHashCode() + ",");
        byte[] map = Encoding.UTF8.GetBytes(sb.ToString());
        fs.Write(map, 0, map.Length);
        fs.Close();
        fs.Dispose();
    }

    /// <summary>
    /// 返回方向文本内容
    /// </summary>
    /// <returns></returns>
    private void ReadDirFromFIle()
    {
        //文件读写流
        StreamReader sr = new StreamReader(path);
        //读取内容
        string result = sr.ReadToEnd();
        //逐行截取(这样截取的数据可能会有问题，如多一行或对一个空格，需要调整)
        // 可以自行百度方法解决，也可以按实际手动修改
        SplitString( result.Split(',') );
        
    }

    /// <summary>
    /// 读取文本的内容
    /// </summary>
    /// <param name="data"></param>
    private void SplitString(string[] data)
    {
        foreach (string item in data)
        {
            if(item != "")
                _data.Add(item);
        }
    }

    /// <summary>
    /// 覆盖清空TXT
    /// </summary>
    public void ClearContent()
    {
        if (ScenesManager.Instance().isPowerOn)
            return;
        FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write);
        fs.Close();
        fs.Dispose();
    }
}
