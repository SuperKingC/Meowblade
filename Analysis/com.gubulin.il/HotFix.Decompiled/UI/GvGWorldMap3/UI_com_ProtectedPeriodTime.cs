using System.Collections;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Model;
using UnityEngine;

namespace UI.GvGWorldMap3;

public class UI_com_ProtectedPeriodTime : GComponent
{
	public GImage n18;

	public GTextField n19;

	public GTextField Time;

	public const string URL = "ui://4eq8fgd2gi53s9y";

	public static string Name = "UI_com_ProtectedPeriodTime";

	private int _protectedPeriodTimestamp;

	private Coroutine _protectedPeriodCountdown;

	private readonly WaitForSeconds _perSeconds = new WaitForSeconds(1f);

	private int Countdown => _protectedPeriodTimestamp - Now;

	private static int Now => (int)GameController.Instance.GetServerTime();

	public static string GetURL()
	{
		return "ui://4eq8fgd2gi53s9y";
	}

	public static UI_com_ProtectedPeriodTime CreateInstance()
	{
		return (UI_com_ProtectedPeriodTime)(object)UIPackage.CreateObject("GvGWorldMap3", "com_ProtectedPeriodTime");
	}

	public static UI_com_ProtectedPeriodTime CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_ProtectedPeriodTime).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2gi53s9y", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n18 = (GImage)((GComponent)this).GetChild("n18");
		n19 = (GTextField)((GComponent)this).GetChild("n19");
		string id = "ui://4eq8fgd2gi53s9y".Replace("ui://", "") + "-" + ((GObject)n19).id;
		((GObject)n19).text = LanguagesManager.GetDesc(id);
		Time = (GTextField)((GComponent)this).GetChild("Time");
	}

	public void OnLoad()
	{
		if (_protectedPeriodCountdown != null)
		{
			FGUIManager.Instance.CloseIEnumerator(_protectedPeriodCountdown);
		}
	}

	public void OnUnload()
	{
		if (_protectedPeriodCountdown != null)
		{
			FGUIManager.Instance.CloseIEnumerator(_protectedPeriodCountdown);
		}
	}

	public void OnRender(IslandStateModel islandState)
	{
		if (islandState.ProtectedPeriodTimestamp > Now)
		{
			_protectedPeriodTimestamp = islandState.ProtectedPeriodTimestamp;
			_protectedPeriodCountdown = FGUIManager.Instance.OpenIEnumerator(UpdateCountdown());
			((GObject)this).visible = true;
		}
		else
		{
			((GObject)this).visible = false;
		}
	}

	private IEnumerator UpdateCountdown()
	{
		while (Countdown > 0)
		{
			if (((GObject)this).isDisposed)
			{
				yield break;
			}
			((GObject)Time).text = UiHelper.ParseTimeShort(Countdown);
			yield return _perSeconds;
		}
		if (!((GObject)this).isDisposed)
		{
			((GObject)this).visible = false;
		}
	}
}
