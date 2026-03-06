using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class XRDebugPanel : MonoBehaviour
{
    [Header("Références")]
    public TextMeshProUGUI text;
    public TimeController timeController;

    [Header("Configuration")]
    public int maxLines = 15;
    public float refreshRate = 0.5f;

    [Header("Filtres")]
    public string[] ignoredMessages = new string[]
    {
        "audio listener",
        "Audio listener",
        "There are 2 audio",
        "XR Plug-in Management",
        "Fallback handler"
    };

    Queue<string> lines = new Queue<string>();
    float _timer;

    void OnEnable()
    {
        Application.logMessageReceived += HandleLog;
        Debug.Log("[PERF] DebugOverlay actif");
    }

    void OnDisable()
    {
        Application.logMessageReceived -= HandleLog;
    }

    void Update()
    {
        _timer += Time.deltaTime;

        if (_timer >= refreshRate)
        {
            _timer = 0f;
            RefreshHeader();
        }
    }

    void RefreshHeader()
    {
        if (text == null) return;

        float fps = 1f / Time.deltaTime;
        float frameTime = Time.deltaTime * 1000f;

        string speed = timeController != null
            ? "x" + timeController.GetSpeed()
            : "x?";

        string date = timeController != null
            ? timeController.GetCurrentDate()
            : "--";

        string paused = timeController != null && timeController.IsPaused()
            ? "| PAUSE"
            : "> PLAY";

        string header =
            "--- DEBUG ---\n" +
            "FPS : " + fps.ToString("F0") +
            "  FrameTime : " + frameTime.ToString("F1") + "ms\n" +
            "Date : " + date + "  Vitesse : " + speed + "  " + paused + "\n" +
            "--- LOGS ---\n";

        string logs = string.Join("\n", lines);
        text.text = header + logs;
    }

    void HandleLog(string logString, string stackTrace, LogType type)
    {
        if (text == null) return;

        // ── Filtres fixes ──
        if (logString.Contains("audio listener")) return;
        if (logString.Contains("Audio listener")) return;
        if (logString.Contains("There are 2 audio")) return;
        if (logString.Contains("AudioListener")) return;
        if (logString.Contains("XR Plug-in")) return;
        if (logString.Contains("Fallback handler")) return;
        if (logString.Contains("Updating planets")) return; 

        // ── Filtres configurables depuis l'Inspecteur ──
        if (ignoredMessages != null)
        {
            foreach (string ignored in ignoredMessages)
            {
                if (!string.IsNullOrEmpty(ignored) && logString.Contains(ignored))
                    return;
            }
        }

        string prefix = type == LogType.Warning  ? "[WARN] " :
                        type == LogType.Error    ? "[ERR]  " :
                        "";

        lines.Enqueue(prefix + logString);

        while (lines.Count > maxLines)
            lines.Dequeue();
    }
}