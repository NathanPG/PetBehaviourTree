using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Panda;

public class Log : MonoBehaviour
{
    public GameObject textPre;
    public ScrollRect scrollRect;

    [Task]
    public bool AddTextToLog(string LogText)
    {
        GameObject temp = Instantiate(textPre, scrollRect.content, false);
        temp.GetComponentInChildren<Text>().text = LogText;
        //scrollRect.verticalNormalizedPosition = 0;
        //LayoutRebuilder.MarkLayoutForRebuild(scrollRect.content);
        //LayoutRebuilder.ForceRebuildLayoutImmediate(scrollRect.content);
        return true;
    }

    private void Start()
    {
        AddTextToLog("Game Starts!");
        AddTextToLog("Meet your new friend, Boggie!");
    }
}
