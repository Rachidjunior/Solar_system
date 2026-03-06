using UnityEngine;
using System;

public class TimeController : MonoBehaviour
{
    public float secondsPerDay = 1f;

    TimeModel model;
    DateTime current;

    public void Init(TimeModel m)
    {
        model = m;
        current = DateTime.Now;
        model.SetTime(current);
        Debug.Log("[TIME] TimeController initialise : " + current.ToString("dd/MM/yyyy"));
    }

    void Update()
    {
        if (model == null) return;
        if (!model.IsPlaying) return;

        current = current.AddDays(Time.deltaTime * secondsPerDay);
        model.SetTime(current);
    }

    public string GetCurrentDate()
    {
        return current.ToString("dd MMM yyyy");
    }

    public float GetSpeed()
    {
        return secondsPerDay;
    }

    public bool IsPaused()
    {
        return !model.IsPlaying;
    }

    public void SetSpeed(float speed)
    {
        secondsPerDay = speed;
        Debug.Log("[TIME] Vitesse → x" + speed);
    }

    public void SetPaused(bool paused)
    {
        if (model == null) return;

        if (paused) model.Pause();
        else model.Play();

        Debug.Log("[TIME] Pause → " + paused);
    }
}