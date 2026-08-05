using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;
using Shift.Legion.ClientApi;
using UnityEngine;

namespace UI.MaskCover;

public class UI_DebugInfo : GComponent, IUiController
{
	public GImage n1;

	public GTextField userId;

	public GTextField delay;

	public const string URL = "ui://nhaflg39egl39";

	public static string Name = "UI_DebugInfo";

	public static string GetURL()
	{
		return "ui://nhaflg39egl39";
	}

	public static UI_DebugInfo CreateInstance()
	{
		return (UI_DebugInfo)(object)UIPackage.CreateObject("MaskCover", "DebugInfo");
	}

	public static UI_DebugInfo CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_DebugInfo).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://nhaflg39egl39", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n1 = (GImage)((GComponent)this).GetChild("n1");
		userId = (GTextField)((GComponent)this).GetChild("userId");
		string id = "ui://nhaflg39egl39".Replace("ui://", "") + "-" + ((GObject)userId).id;
		((GObject)userId).text = LanguagesManager.GetDesc(id);
		delay = (GTextField)((GComponent)this).GetChild("delay");
		string id2 = "ui://nhaflg39egl39".Replace("ui://", "") + "-" + ((GObject)delay).id;
		((GObject)delay).text = LanguagesManager.GetDesc(id2);
	}

	public void RegisterUiEventListeners()
	{
		SharedMessenger.AddListener("DEBUG_INFO_SWITCH_CHANGED", OnChangeDebugInfo);
	}

	public void UnregisterUiEventListeners()
	{
		SharedMessenger.RemoveListener("DEBUG_INFO_SWITCH_CHANGED", OnChangeDebugInfo);
	}

	public void Init(Dictionary<string, object> parameters)
	{
		((GObject)this).SetXY(((GObject)GRoot.inst).width, 0f);
		((GObject)this).sortingOrder = 3000;
		((GObject)userId).text = GameController.Contexts.gameState.user.value.UserId.ToString();
		((MonoBehaviour)FGUIManager.Instance).StartCoroutine(UpdatePerSecond());
		OnChangeDebugInfo();
		((GObject)this).touchable = false;
	}

	private IEnumerator UpdatePerSecond()
	{
		WaitForSeconds wait = new WaitForSeconds(1f);
		while (!((GObject)this).isDisposed)
		{
			int rtt = UnityRequestHelper.Instance.GetRtt();
			((GObject)delay).text = $"{rtt}ms";
			yield return wait;
		}
	}

	private void OnChangeDebugInfo()
	{
		bool visible = GameLocalDataManager.GetBool("DebugInfoSwitch");
		((GObject)this).visible = visible;
	}

	public void OnShow()
	{
	}

	public void BeforeDestroy()
	{
	}

	public void Destroy()
	{
	}
}
