using System;
using System.Collections.Generic;
using UnityEngine;

namespace HotFix.Sources.ThirdParty.SDKs.Android;

public class BaseAndroidSDK
{
	protected const string AndroidPackagePrefix = "com.gubulin.il";

	protected const string AndroidPackagePrefixIntl = "com.gooplin.il";

	protected readonly AndroidJavaClass AndroidPlatformJavaBridge;

	public Dictionary<string, Action<string>> MethodMap;

	public BaseAndroidSDK(string name)
	{
		//IL_000a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Expected O, but got Unknown
		AndroidPlatformJavaBridge = new AndroidJavaClass(name);
	}
}
