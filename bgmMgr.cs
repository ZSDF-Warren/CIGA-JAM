using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bgmMgr : MonoBehaviour
{
    public Image img;
    public float Stime;
    public Color Cin;
    public Color Cout;
    private bool cin;
    private bool cout;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    private void Update()
    {
        if (cin)
            img.color = Color.Lerp(Cout, Cin, Time.time - Stime);
        else if (cout)
            img.color = Color.Lerp(Cin, Cout, Time.time - Stime);
    }

    public void fadeIn()
    {
        cin = true;
        Stime = Time.time;
    }

    public void fadeOut()
    {
        cout = true;
        Stime = Time.time;
    }
}
