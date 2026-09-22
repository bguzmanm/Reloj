using UnityEngine;
using System;

public class Clock : MonoBehaviour {

    [SerializeField]
    Transform hoursPivot, minutesPivot, secondsPivot;

    const float hoursToDegrees = 30f, minutesToDegrees = 6f, secondsToDegrees = 6f;

    void Update () {
        var time = DateTime.Now;
        hoursPivot.localRotation =
            Quaternion.Euler(0f, 0f, hoursToDegrees * time.Hour);
        minutesPivot.localRotation =
            Quaternion.Euler(0f, 0f, minutesToDegrees * time.Minute);
        secondsPivot.localRotation =
            Quaternion.Euler(0f, 0f, secondsToDegrees * time.Second);
    }
}