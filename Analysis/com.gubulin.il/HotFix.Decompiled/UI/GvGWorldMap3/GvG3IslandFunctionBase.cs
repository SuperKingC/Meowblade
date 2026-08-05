using System.Collections.Generic;
using FairyGUI;
using HotFix.Sources.Base.Scripts.Helper;

namespace UI.GvGWorldMap3;

public class GvG3IslandFunctionBase
{
	private string _functionType;

	private string _desc;

	public string Desc
	{
		get
		{
			if (string.IsNullOrEmpty(_desc))
			{
				_desc = "GvG3IslandFunctionsDesc".ToConfiguration<Dictionary<string, string>>()[_functionType].ToLanguage();
			}
			return _desc;
		}
	}

	public void Init(IslandFuncStatus funcStatus, GButton button, string functionType)
	{
		_functionType = functionType;
		((GComponent)button).GetController("Status").SetSelectedIndex((int)funcStatus);
	}

	public void Update(IslandFuncStatus funcStatus, GButton button)
	{
		((GComponent)button).GetController("Status").SetSelectedIndex((int)funcStatus);
	}
}
