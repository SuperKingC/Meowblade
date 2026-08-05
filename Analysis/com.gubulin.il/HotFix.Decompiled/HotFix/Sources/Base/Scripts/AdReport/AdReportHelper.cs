using System.Collections.Generic;
using Shift.Legion.ClientApi.Protocol;
using UnityEngine;

namespace HotFix.Sources.Base.Scripts.AdReport;

public class AdReportHelper : MonoBehaviour
{
	private void Awake()
	{
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Invalid comparison between I4 and Unknown
		List<int> appleAdReportedUsers = GameLocalDataManager.GetAppleAdReportedUsers();
		if (!appleAdReportedUsers.Contains(-1) && 8 == (int)Application.platform)
		{
			SDKManager.Instance.SDKMap_IOS[SDKManager.eSDKName.iOS].GetAdToken(null);
		}
		SharedMessenger.AddListener<User>("NEW_USER_REGISTERED", OnNewUserRegistered);
	}

	private void OnNewUserRegistered(User user)
	{
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Invalid comparison between I4 and Unknown
		List<int> appleAdReportedUsers = GameLocalDataManager.GetAppleAdReportedUsers();
		if (!appleAdReportedUsers.Contains(user.UserId) && 8 == (int)Application.platform)
		{
			SDKManager.Instance.SDKMap_IOS[SDKManager.eSDKName.iOS].GetAdToken(null);
		}
	}
}
