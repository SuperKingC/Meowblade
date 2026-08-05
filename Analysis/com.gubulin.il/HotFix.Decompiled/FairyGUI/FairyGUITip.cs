using System;
using UnityEngine;

namespace FairyGUI;

public class FairyGUITip
{
	public static T ShowTip<T>(GObject target = null, eFairyGUITipDir dir = eFairyGUITipDir.None, Action<T> complete = null, Rect Range = default(Rect), bool lastSetXy = false) where T : GComponent
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Expected O, but got Unknown
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_0146: Unknown result type (might be due to invalid IL or missing references)
		//IL_0150: Expected O, but got Unknown
		Window _window = new Window
		{
			sortingOrder = 3000
		};
		if (Range == default(Rect))
		{
			Range = Rect.MinMaxRect(0f, 0f, ((GObject)GRoot.inst).width, ((GObject)GRoot.inst).height);
		}
		if (_window.contentPane == null || (_window.contentPane != null && !(_window.contentPane is T)))
		{
			string[] array = typeof(T).FullName.Split('.');
			string text = array[1];
			string text2 = array[2].Replace("UI_", "");
			_window.contentPane = UIPackage.CreateObject(text, text2).asCom;
			((GObject)_window.contentPane).SetPivot(0.5f, 0.5f, true);
		}
		GRoot.inst.ShowPopup((GObject)(object)_window);
		((GObject)((GObject)_window).asCom).onRemovedFromStage.Add((EventCallback0)delegate
		{
			Window obj = _window;
			if (((obj != null) ? obj.contentPane : null) != null)
			{
				((GObject)_window.contentPane).Dispose();
				_window.contentPane = null;
			}
			Window obj2 = _window;
			if (obj2 != null)
			{
				((GObject)obj2).Dispose();
			}
		});
		T val = (T)(object)_window.contentPane;
		if (lastSetXy)
		{
			complete?.Invoke(val);
			SetXy();
		}
		else
		{
			SetXy();
			complete?.Invoke(val);
		}
		return val;
		void SetXy()
		{
			//IL_0038: Unknown result type (might be due to invalid IL or missing references)
			//IL_0042: Unknown result type (might be due to invalid IL or missing references)
			//IL_004c: Unknown result type (might be due to invalid IL or missing references)
			//IL_002b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0051: Unknown result type (might be due to invalid IL or missing references)
			//IL_0054: Unknown result type (might be due to invalid IL or missing references)
			//IL_015d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0160: Unknown result type (might be due to invalid IL or missing references)
			//IL_0166: Unknown result type (might be due to invalid IL or missing references)
			//IL_019f: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a1: Unknown result type (might be due to invalid IL or missing references)
			//IL_0175: Unknown result type (might be due to invalid IL or missing references)
			//IL_017b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0182: Unknown result type (might be due to invalid IL or missing references)
			//IL_0188: Unknown result type (might be due to invalid IL or missing references)
			GObject obj = target;
			Vector2 val2 = (Vector2)((obj != null) ? obj.LocalToRoot(target.size * 0.5f, GRoot.inst) : new Vector2(((GObject)GRoot.inst).width / 2f, ((GObject)GRoot.inst).height / 2f));
			Vector2 val3 = default(Vector2);
			switch (dir)
			{
			case eFairyGUITipDir.Up:
				((Vector2)(ref val3))._002Ector(0f, (0f - target.height) / 2f - ((GObject)_window.contentPane).height / 2f);
				break;
			case eFairyGUITipDir.Down:
				((Vector2)(ref val3))._002Ector(0f, target.height / 2f + ((GObject)_window.contentPane).height / 2f);
				break;
			case eFairyGUITipDir.Left:
				((Vector2)(ref val3))._002Ector((0f - target.height) / 2f - ((GObject)_window.contentPane).width / 2f, 0f);
				break;
			case eFairyGUITipDir.Right:
				((Vector2)(ref val3))._002Ector(target.height / 2f + ((GObject)_window.contentPane).width / 2f, 0f);
				break;
			}
			if (val3 != default(Vector2))
			{
				((Vector2)(ref val2))._002Ector(val2.x + val3.x, val2.y + val3.y);
			}
			((GObject)(object)_window.contentPane).SetXY_WithinBounds(val2, Range);
		}
	}
}
