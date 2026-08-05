using System.Collections;
using System.Collections.Generic;
using System.IO;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using HotFix;
using Shift.Legion.Common.Services;
using UnityEngine;

namespace UI.Screenshots;

public class UI_ScreenshotsPanel : GComponent, IUiController
{
	public Controller Status;

	public GGraph Mask;

	public UI_InvitationDialog InvitationDialog;

	public const string URL = "ui://pzmiqysmh95m0";

	public static string Name = "UI_ScreenshotsPanel";

	private int curPage;

	public static string GetURL()
	{
		return "ui://pzmiqysmh95m0";
	}

	public static UI_ScreenshotsPanel CreateInstance()
	{
		return (UI_ScreenshotsPanel)(object)UIPackage.CreateObject("Screenshots", "ScreenshotsPanel");
	}

	public static UI_ScreenshotsPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ScreenshotsPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://pzmiqysmh95m0", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Status = ((GComponent)this).GetController("Status");
		Mask = (GGraph)((GComponent)this).GetChild("Mask");
		InvitationDialog = (UI_InvitationDialog)(object)((GComponent)this).GetChild("InvitationDialog");
	}

	public void BeforeDestroy()
	{
	}

	public void Destroy()
	{
		FGUIManager.Instance.ReleaseGloaderTexture2D(Name);
	}

	public void Init(Dictionary<string, object> parameters)
	{
		((GObject)this).SetSize(((GObject)GRoot.inst).width, ((GObject)GRoot.inst).height);
		UnityUiService.Instance.SetEdgeMaskVisible(value: false);
		((GObject)this).sortingOrder = 100;
		curPage = 1;
		Status.selectedIndex = 1;
		((MonoBehaviour)FGUIManager.Instance).StartCoroutine(FGUIManager.Instance.GetImageByWebRequestAndStorage(Name, GameController.Contexts.gameState.user.value.UserId, InvitationDialog.icon, InvitationDialog.name));
		((GObject)InvitationDialog.InviteCode).text = GameController.Contexts.gameState.user.value.InvitingCode;
		if (HotUpdateProcess.ChannelCode == "bilibili")
		{
			((GObject)InvitationDialog.code).visible = false;
			((GObject)InvitationDialog.qrCodeTitle).visible = false;
		}
	}

	public void OnShow()
	{
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		float num = (float)Screen.width / 1080f;
		float num2 = (float)Screen.height / 1920f;
		float num3 = Mathf.Min(num2, num);
		float num4 = num3 / UIContentScaler.scaleFactor;
		((GObject)InvitationDialog).SetSize((float)Screen.width / num3, (float)Screen.height / num3);
		((GObject)InvitationDialog).SetScale(num4, num4);
		((GObject)this).xy = Vector2.zero;
		if (HotUpdateProcess.Instance.IsRegionOutCN)
		{
			SDKManager.Instance.OnGetScreenShots_Intl(((GObject)this).sortingOrder, ScreenPanelFade);
		}
		else if (SDKManager.CheckVersion())
		{
			SDKManager.Instance.OpenSomeChange(((GObject)this).sortingOrder, ScreenPanelFade);
		}
	}

	public void RegisterUiEventListeners()
	{
	}

	public void UnregisterUiEventListeners()
	{
	}

	private void CreatScreenshot()
	{
		string path = CaptureScreenshotManager.Instance.CaptureScreenshot();
		((MonoBehaviour)FGUIManager.Instance).StartCoroutine(FindScreenShot(path));
	}

	private IEnumerator FindScreenShot(string _path)
	{
		int second = 0;
		bool isExists = false;
		while (second <= 3 && !isExists)
		{
			second++;
			if (File.Exists(_path))
			{
				isExists = true;
			}
			yield return (object)new WaitForSeconds(1f);
		}
		if (isExists)
		{
			List<string> tipList = new List<string> { LanguagesManager.GetDesc("CsharpCodeZhTcText536") + "：" + Application.persistentDataPath };
			SharedMessenger.Broadcast("SHOW_TIPS", tipList, ((GObject)this).sortingOrder, arg3: false);
		}
		else
		{
			List<string> tipList2 = new List<string> { LanguagesManager.GetDesc("CsharpCodeZhTcText65") + LanguagesManager.Comma + LanguagesManager.GetDesc("CsharpCodeZhTcText66") };
			SharedMessenger.Broadcast("SHOW_TIPS", tipList2, ((GObject)this).sortingOrder, arg3: false);
		}
		End();
	}

	public void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name);
	}

	public void ScreenPanelFade()
	{
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Expected O, but got Unknown
		Screen.orientation = (ScreenOrientation)3;
		((GObject)this).alpha = 0f;
		int cullmask = Camera.main.cullingMask;
		Camera.main.cullingMask = 0;
		((GComponent)(object)this).SetTimeout(1.5f).OnComplete((GTweenCallback)delegate
		{
			Camera.main.cullingMask = cullmask;
			End();
		});
	}
}
