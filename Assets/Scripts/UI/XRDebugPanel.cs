using UnityEngine;
using TMPro;
using System.Collections.Generic;

[AddComponentMenu("XR Solar System/XR Debug Panel")]
public class XRDebugPanel : MonoBehaviour
{
    public TextMeshProUGUI text;

    Queue<string> lines = new Queue<string>();
    public int maxLines = 15;

    void OnEnable()
    {
        Application.logMessageReceived += HandleLog;
    }

    void OnDisable()
    {
        Application.logMessageReceived -= HandleLog;
    }

    void HandleLog(string logString, string stackTrace, LogType type)
    {
        lines.Enqueue(logString);

        while (lines.Count > maxLines)
            lines.Dequeue();

        text.text = string.Join("\n", lines);
    }
}