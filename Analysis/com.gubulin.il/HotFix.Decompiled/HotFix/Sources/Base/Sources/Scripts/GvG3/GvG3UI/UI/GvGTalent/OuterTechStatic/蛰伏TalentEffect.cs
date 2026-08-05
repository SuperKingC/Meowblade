using HotFix.Sources.Base.Scripts.Helper;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.UI.GvGTalent.OuterTechStatic;

public class 蛰伏TalentEffect
{
	public bool 蛰伏IsActive = false;

	private string _蛰伏Desc;

	public float 蛰伏_减免Value => 0.3f;

	public string 蛰伏Desc => _蛰伏Desc ?? (_蛰伏Desc = "GvG3OuterTechI67605Desc".ToLanguage());
}
