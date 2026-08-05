using Shift.Legion.Common.Services;
using UnityEngine;

namespace GvG3;

public class KeepConnectionManager
{
	private const float REQUEST_INTERVAL = 3f;

	private float nextRequestTime = 0f;

	public void Update()
	{
		if (Time.time > nextRequestTime)
		{
			nextRequestTime = Time.time + 3f;
			GameController.Contexts.Service<INetworkService>().GetUserProfileUrl();
		}
	}
}
