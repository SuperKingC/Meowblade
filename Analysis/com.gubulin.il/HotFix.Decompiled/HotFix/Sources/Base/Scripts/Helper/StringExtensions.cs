using System;
using System.Collections.Generic;
using FairyGUI;
using GameDataEditor;
using ILRuntime_LitJson;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Services;
using Shift.Legion.Helpers;
using UI.Tips;

namespace HotFix.Sources.Base.Scripts.Helper;

public static class StringExtensions
{
	public static string ToLanguage(this string langKey)
	{
		GDELanguagesData gDELanguagesData = GDMgr.Get<GDELanguagesData>(langKey);
		if (gDELanguagesData == null || string.IsNullOrEmpty(gDELanguagesData.Template))
		{
			return langKey;
		}
		return gDELanguagesData.Template;
	}

	public static string ToLanguage(this string langKey, params object[] args)
	{
		GDELanguagesData gDELanguagesData = GDMgr.Get<GDELanguagesData>(langKey);
		if (gDELanguagesData == null || string.IsNullOrEmpty(gDELanguagesData.Template))
		{
			return langKey;
		}
		return string.Format(gDELanguagesData.Template, args);
	}

	public static string Format(this string richText, params object[] args)
	{
		try
		{
			return string.Format(richText, args);
		}
		catch (Exception)
		{
			ILRuntimeDebug.LogError("[String.Format] richText=" + richText + " wrong format");
			return richText;
		}
	}

	public static string Format(this string richText, object arg0, object arg1, object arg2)
	{
		try
		{
			return string.Format(richText, arg0, arg1, arg2);
		}
		catch (Exception)
		{
			ILRuntimeDebug.LogError("[String.Format] richText=" + richText + " wrong format");
			return richText;
		}
	}

	public static string Format(this string richText, object arg0, object arg1)
	{
		try
		{
			return string.Format(richText, arg0, arg1);
		}
		catch (Exception)
		{
			ILRuntimeDebug.LogError("[String.Format] richText=" + richText + " wrong format");
			return richText;
		}
	}

	public static string Format(this string richText, object arg0)
	{
		try
		{
			return string.Format(richText, arg0);
		}
		catch (Exception)
		{
			ILRuntimeDebug.LogError("[String.Format] richText=" + richText + " wrong format");
			return richText;
		}
	}

	public static void ToShowLanguageTip(this string langKey)
	{
		GDELanguagesData gDELanguagesData = GDMgr.Get<GDELanguagesData>(langKey);
		string item = ((gDELanguagesData == null || string.IsNullOrEmpty(gDELanguagesData.Template)) ? ("langKey=" + langKey + " does not exist") : gDELanguagesData.Template);
		List<string> arg = new List<string> { item };
		SharedMessenger.Broadcast("SHOW_TIPS", arg, 1, arg3: false);
	}

	public static void ToTip(this string tipText)
	{
		List<string> arg = new List<string> { tipText };
		SharedMessenger.Broadcast("SHOW_TIPS", arg, 1, arg3: false);
	}

	public static void ToConfirmPopup(this string tipText, Action onConfirm = null, Action onCancel = null, AlignType alignType = (AlignType)0, int fontSize = 40, bool mirrorBtns = false, bool needCancelButton = true, int pageIndex = 0)
	{
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		Dictionary<string, Action> dictionary = new Dictionary<string, Action>();
		dictionary.Add("Confirm", onConfirm);
		if (needCancelButton)
		{
			dictionary.Add("Cancel", onCancel);
		}
		else
		{
			pageIndex = 4;
		}
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_UniversalConfirmPopup.Name, new Dictionary<string, object>
		{
			{ "TipTextAlign", alignType },
			{ "Content", tipText },
			{ "FontSize", fontSize },
			{ "Mirror", mirrorBtns },
			{ "PageIndex", pageIndex },
			{ "Order", 999999 },
			{ "ClickSound", "Confirm" },
			{ "Buttons", dictionary }
		});
	}

	public static void ToConfirmPopupDontShowAgain(this string content, string tipKey, string tipValue = null, string tipContent = null, Action onConfirm = null, Action onCancel = null, AlignType alignType = (AlignType)0, int fontSize = 40, bool mirrorBtns = false, bool needCancelButton = true, int pageIndex = 0)
	{
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		Dictionary<string, Action> dictionary = new Dictionary<string, Action>();
		dictionary.Add("Confirm", onConfirm);
		if (needCancelButton)
		{
			dictionary.Add("Cancel", onCancel);
		}
		else
		{
			pageIndex = 4;
		}
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_UniversalConfirmPopup.Name, new Dictionary<string, object>
		{
			{ "TipTextAlign", alignType },
			{ "Content", content },
			{ "FontSize", fontSize },
			{ "Mirror", mirrorBtns },
			{ "PageIndex", pageIndex },
			{ "Order", 999999 },
			{ "ClickSound", "Confirm" },
			{ "Buttons", dictionary }
		});
	}

	public static string ToPublicResourceIcon(this string iconName)
	{
		return string.IsNullOrEmpty(iconName) ? string.Empty : ("ui://PublicResources/" + iconName);
	}

	public static string ToPublicResourcesRgbIcon(this string iconName)
	{
		return string.IsNullOrEmpty(iconName) ? string.Empty : ("ui://PublicResourcesRGB/" + iconName);
	}

	public static T ToConfiguration<T>(this string configKey)
	{
		GDEConfigurationData gDEConfigurationData = GDMgr.Get<GDEConfigurationData>(configKey);
		if (gDEConfigurationData == null || string.IsNullOrEmpty(gDEConfigurationData.Config))
		{
			ILRuntimeDebug.LogError("[StringExtensions] ToConfiguration 没有找到 " + configKey + " 相关的配置");
			return default(T);
		}
		return gDEConfigurationData.Config.ToObject<T>();
	}

	public static T ToObject<T>(this string json)
	{
		try
		{
			Type typeFromHandle = typeof(T);
			if (typeFromHandle == typeof(int))
			{
				return (T)(object)int.Parse(json);
			}
			if (typeFromHandle == typeof(float))
			{
				return (T)(object)NumericParser.Float(json);
			}
			return JsonHelper.ToObject<T>(json);
		}
		catch (Exception ex)
		{
			ILRuntimeDebug.LogError("[StringExtensions] ToObject 无法用类 " + typeof(T).Name + " 解析 json = " + json);
			ILRuntimeDebug.LogError(ex.Message);
			return default(T);
		}
	}

	public static string ToJson<T>(this T obj)
	{
		return JsonHelper.ToJson(obj);
	}

	public static object TryGet(this object obj, string propName)
	{
		if (obj is Dictionary<string, object> dictionary)
		{
			object value;
			return dictionary.TryGetValue(propName, out value) ? value : null;
		}
		JsonData val = (JsonData)((obj is JsonData) ? obj : null);
		if (val != null)
		{
			return val[propName];
		}
		return null;
	}

	public static T TryGet<T>(this object obj, string propName)
	{
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		object obj2 = obj.TryGet(propName);
		return (obj2 == null) ? default(T) : ((JsonData)obj2).ToJson().ToObject<T>();
	}
}
