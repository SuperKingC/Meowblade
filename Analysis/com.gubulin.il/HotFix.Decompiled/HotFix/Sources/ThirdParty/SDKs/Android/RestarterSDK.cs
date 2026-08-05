using System;
using System.Collections.Generic;

namespace HotFix.Sources.ThirdParty.SDKs.Android;

public class RestarterSDK : BaseAndroidSDK
{
	public RestarterSDK()
		: base("com.gubulin.il.restarter.AppRestarter")
	{
		MethodMap = new Dictionary<string, Action<string>> { { "Restart", Restart } };
	}

	public static void Restart(string info)
	{
	}
}
