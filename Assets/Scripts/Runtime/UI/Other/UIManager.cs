
using System.Collections.Generic;
using UnityEngine;

public static class  UIManager 
{
    private  static   Stack<Transform> uiS  = new ();
    
    public static void OpenUI(Transform UI)
    {
        if (uiS.Count != 0)
        {
           uiS.Peek().transform.gameObject.SetActive(false);
           if(uiS.Peek() == UI) return;
        }
       
        UI.gameObject.SetActive(true);
        uiS.Push(UI);
    }

    public static void HideUI(Transform UI)
    {
        if (uiS.Count == 0) return;
        uiS.Peek().transform.gameObject.SetActive(false);
        uiS.Pop();
        if(uiS.Count == 0) return;
        uiS.Peek().transform.gameObject.SetActive(true);
    }

    public static void GetCountStack()
    {
        Debug.Log(uiS.Count);
    }

    public static void Destroy()
    {
        uiS = new();
    }
    
}
