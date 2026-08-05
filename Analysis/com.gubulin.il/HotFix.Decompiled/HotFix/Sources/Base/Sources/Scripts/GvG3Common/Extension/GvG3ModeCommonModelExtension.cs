using System;
using System.Collections.Generic;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Helper;
using Shift.Legion.GvG.Common.Models.GvGMode3.Collecting;
using Shift.Legion.Helpers;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3Common.Extension;

public static class GvG3ModeCommonModelExtension
{
	public static int GetFlightSpeed(this RealTimeShipSummarySpeedModel model, int workerNum)
	{
		double num = ObserverConfigHelper.DefaultsConfig.FlightSpeed;
		double num2 = Math.Pow(1.05, workerNum);
		return (int)(num * (double)model.Total * num2);
	}

	public static string ToIslandLogProcessId(this string message)
	{
		if (string.IsNullOrEmpty(message))
		{
			return string.Empty;
		}
		List<object> list = JsonHelper.ToObject<List<object>>(message);
		return list[1].ToString();
	}
}
