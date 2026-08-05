using System;
using System.Runtime.CompilerServices;
using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;
using UnityEngine;

namespace UI.PvpSelectSoldiers;

public class UI_PvpTeamMoveInfo : GButton
{
	[Serializable]
	[CompilerGenerated]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9 = new _003C_003Ec();

		public static PlayCompleteCallback _003C_003E9__15_0;

		public static PlayCompleteCallback _003C_003E9__16_0;

		internal void _003CMainUiDisappear_003Eb__15_0()
		{
			((GObject)PvpTeamMoveInfoButton).touchable = false;
		}

		internal void _003CDisappear_003Eb__16_0()
		{
			((GObject)PvpTeamMoveInfoButton).touchable = false;
		}
	}

	public Controller button;

	public GImage n3;

	public GTextField indexText;

	public Transition ShowSelf;

	public const string URL = "ui://82mo10n5g2a9dhe";

	public static string Name = "UI_PvpTeamMoveInfo";

	public static UI_PvpTeamMoveInfo PvpTeamMoveInfoButton;

	private static Vector2 posOffset;

	private const float DisappearDelayTime = 0.1667f;

	public static string GetURL()
	{
		return "ui://82mo10n5g2a9dhe";
	}

	public static UI_PvpTeamMoveInfo CreateInstance()
	{
		return (UI_PvpTeamMoveInfo)(object)UIPackage.CreateObject("PvpSelectSoldiers", "PvpTeamMoveInfo");
	}

	public static UI_PvpTeamMoveInfo CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_PvpTeamMoveInfo).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5g2a9dhe", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n3 = (GImage)((GComponent)this).GetChild("n3");
		indexText = (GTextField)((GComponent)this).GetChild("indexText");
		string id = "ui://82mo10n5g2a9dhe".Replace("ui://", "") + "-" + ((GObject)indexText).id;
		((GObject)indexText).text = LanguagesManager.GetDesc(id);
		ShowSelf = ((GComponent)this).GetTransition("ShowSelf");
	}

	public static void ShowMainUi(Vector2 formationBtnGlobalPos, Vector2 touchPos, int index)
	{
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		if (PvpTeamMoveInfoButton != null)
		{
			((GComponent)UnityUiService.Instance.maskCover).RemoveChild((GObject)(object)PvpTeamMoveInfoButton, true);
			PvpTeamMoveInfoButton = null;
		}
		if (PvpTeamMoveInfoButton == null)
		{
			PvpTeamMoveInfoButton = CreateInstance_ILRuntime();
			((GComponent)UnityUiService.Instance.maskCover).AddChild((GObject)(object)PvpTeamMoveInfoButton);
			((GObject)PvpTeamMoveInfoButton).sortingOrder = 3000;
		}
		((GObject)PvpTeamMoveInfoButton).touchable = false;
		((GObject)PvpTeamMoveInfoButton).xy = touchPos;
		((GObject)PvpTeamMoveInfoButton.indexText).text = index.ToString();
		PvpTeamMoveInfoButton.ShowSelf.Play();
	}

	public static void ChangePosOnMoving(Vector2 touchPos)
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		if (PvpTeamMoveInfoButton != null)
		{
			((GObject)PvpTeamMoveInfoButton).xy = touchPos;
		}
	}

	public static void MainUiDisappear(Vector2 formationBtnGlobalPos, Action action)
	{
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Expected O, but got Unknown
		if (PvpTeamMoveInfoButton == null)
		{
			return;
		}
		Transition showSelf = PvpTeamMoveInfoButton.ShowSelf;
		object obj = _003C_003Ec._003C_003E9__15_0;
		if (obj == null)
		{
			PlayCompleteCallback val = delegate
			{
				((GObject)PvpTeamMoveInfoButton).touchable = false;
			};
			_003C_003Ec._003C_003E9__15_0 = val;
			obj = (object)val;
		}
		showSelf.PlayReverse((PlayCompleteCallback)obj);
		action?.Invoke();
	}

	public static void Disappear()
	{
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Expected O, but got Unknown
		if (PvpTeamMoveInfoButton == null)
		{
			return;
		}
		Transition showSelf = PvpTeamMoveInfoButton.ShowSelf;
		object obj = _003C_003Ec._003C_003E9__16_0;
		if (obj == null)
		{
			PlayCompleteCallback val = delegate
			{
				((GObject)PvpTeamMoveInfoButton).touchable = false;
			};
			_003C_003Ec._003C_003E9__16_0 = val;
			obj = (object)val;
		}
		showSelf.PlayReverse((PlayCompleteCallback)obj);
	}
}
