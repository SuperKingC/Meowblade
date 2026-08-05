using HotFix.Sources.Base.Scripts.MainCity;
using Shift.Legion.Common.Managers;
using UI;
using UnityEngine;

namespace Shift.Legion.Common.Models;

public class PVPEntrance : Building
{
	public object Controller;

	public PVPEntrance(GameManagers managers)
		: base(managers, "18")
	{
	}

	public void InitBuildingGameObject(GameObject _gameObject)
	{
		if (Object.op_Implicit((Object)(object)_gameObject.transform.Find("Building18")))
		{
			GameObject gameObject = ((Component)_gameObject.transform.Find("Building18")).gameObject;
			gameObject.AddComponent<PVPEntranceController>();
			gameObject.AddComponent<HitArea>();
			HitArea component = gameObject.GetComponent<HitArea>();
			component.hitData.name = "PVPEntrance";
			component.hitData.id = "18";
			component.repairBuildTime = 5f;
			component.hitData.builders = ((Component)gameObject.transform.Find("Builders")).gameObject;
			Transform[] array = (Transform[])(object)new Transform[5];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = component.hitData.builders.transform.Find("workPoints").GetChild(i);
			}
			component.hitData.points = array;
			GameObject = gameObject;
		}
	}
}
