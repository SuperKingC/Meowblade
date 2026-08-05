using System;
using System.Collections.Generic;
using GameMaths;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Services;

namespace Shift.Legion.Common.Models;

public class MoveCameraActionHandler : IStoryActionHandler
{
	public string ActionId()
	{
		return "MoveCamera";
	}

	public Action Handle(GameManagers managers, string actionName, string actionPayload, CustomTaskCompletionSource<bool> taskCompletionSource, string nextTrigger)
	{
		Dictionary<string, object> dictionary = CustomScript.ParseActionPayloadToDict(actionPayload);
		if (dictionary != null)
		{
			MoveCamera(dictionary);
		}
		return null;
	}

	private void MoveCamera(Dictionary<string, object> paramDict)
	{
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
		ICameraService cameraService = Contexts.sharedInstance.Service<ICameraService>();
		object value = null;
		object value2 = null;
		object value3 = null;
		if (paramDict.TryGetValue("Scene", out var value4))
		{
			cameraService.SwitchToScene(value4.ToString());
		}
		else if (paramDict.TryGetValue("X", out value) || paramDict.TryGetValue("Y", out value2) || paramDict.TryGetValue("Z", out value3))
		{
			Vector3 position = cameraService.Position;
			if (value != null)
			{
				position.x += Convert.ToSingle(value);
			}
			if (value2 != null)
			{
				position.y += Convert.ToSingle(value2);
			}
			if (value3 != null)
			{
				position.z += Convert.ToSingle(value3);
			}
			cameraService.SetPosition(position);
		}
	}
}
