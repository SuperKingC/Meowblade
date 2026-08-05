using System;
using Assets.Scripts.UI;
using UnityEngine;

namespace GvG2.Common.Models;

public class FlightTimeCounter : MonoBehaviour
{
	private int TargetTime = 0;

	private TextMesh[] Texts;

	public void Init(Ship parentShip)
	{
		Transform val = ((Component)this).transform.Find("counting/number");
		Texts = ((Component)val).GetComponentsInChildren<TextMesh>();
		SetText("");
		parentShip.OnUpdateFlightSchedule = (Action<Ship>)Delegate.Combine(parentShip.OnUpdateFlightSchedule, new Action<Ship>(OnUpdateFlightSchedule));
	}

	private void OnUpdateFlightSchedule(Ship ship)
	{
		TargetTime = ship.Details.FlightSchedule.EndTime;
	}

	private void SetText(string text)
	{
		TextMesh[] texts = Texts;
		foreach (TextMesh val in texts)
		{
			val.text = text;
		}
	}

	private void FixedUpdate()
	{
		if (TargetTime != -1)
		{
			int num = TargetTime - (int)GameController.Instance.GetServerTime();
			if (num < 0)
			{
				TargetTime = -1;
				num = 0;
			}
			SetText(UiHelper.ParseTime(num));
		}
	}
}
