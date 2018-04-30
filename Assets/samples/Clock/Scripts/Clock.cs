using System;
using UnityEngine;

public class Clock : MonoBehaviour {
	
	public Transform hoursTransform;
	public Transform minutesTransform;
	public Transform secondsTransform;

	public bool continuous;

	private const float degreesPerHour = 30f;
	private const float degreesPerMinute = 6f;
	private const float degreesPerSecond = 6f;

	void Awake(){
		DateTime time = DateTime.Now;
		SetTime(time.Hour, time.Minute, time.Second);
	}

	void Update(){
		if(continuous){
			UpdateContinuous();
		}else{
			UpdateDiscrete();
		}
	}

	void UpdateContinuous(){
		TimeSpan time = DateTime.Now.TimeOfDay;
		SetTime((float)time.TotalHours, (float)time.TotalMinutes, (float)time.TotalSeconds);
	}

	void UpdateDiscrete(){
		DateTime time = DateTime.Now;
		SetTime(time.Hour, time.Minute, time.Second);
	}

	void SetTime(float hours, float minutes, float seconds){
		hoursTransform.localRotation = Quaternion.Euler(0, hours * degreesPerHour, 0);
		minutesTransform.localRotation = Quaternion.Euler(0, minutes * degreesPerMinute, 0);
		secondsTransform.localRotation = Quaternion.Euler(0, seconds * degreesPerSecond, 0);
	}
}