using GameDataEditor;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model;
using Shift.Legion.Common.Managers;
using Shift.Legion.Helpers;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3UI.Helper;

public static class ObserverConfigHelper
{
	private static GvGMode3Defaults _DefaultsConfig;

	public static GvGMode3Defaults DefaultsConfig
	{
		get
		{
			if (_DefaultsConfig == null)
			{
				string text = GDMgr.Get<GDEConfigurationData>("GVG_MODE3_DEFAULTS")?.Config;
				if (text == null)
				{
					ILRuntimeDebug.LogError("[ObserverConfigHelper] Configuration 表中找不到 ‘GVG_MODE3_DEFAULTS’相关的配置");
					return null;
				}
				_DefaultsConfig = JsonHelper.ToObject<GvGMode3Defaults>(text);
			}
			return _DefaultsConfig;
		}
	}
}
