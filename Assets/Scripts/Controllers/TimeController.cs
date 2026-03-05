using UnityEngine;
using System;

public class TimeController : MonoBehaviour
{
    public float secondsPerDay = 1f;  // 1 seconde réelle = 1 jour simulé

    TimeModel model;
    DateTime current;

    public void Init(TimeModel m)
    {
        model = m;
        current = DateTime.Now;
        model.SetTime(current);  // ← déclenche OnTimeChanged une première fois
    }

    void Update()
    {
        if (model == null) return;          // sécurité si Init pas encore appelé
        if (!model.IsPlaying) return;       // pause → on ne fait rien

        current = current.AddDays(Time.deltaTime * secondsPerDay);
        model.SetTime(current);             // ← déclenche OnTimeChanged
    }
}