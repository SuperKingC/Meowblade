using FairyGUI;

namespace HotFix.Sources.Shift.Legion.Shift.Legion.Common.Sources.Models.UiParam;

public class SkeletonAnimationLoadParams
{
	public GGraph Graph { get; }

	public string Name { get; }

	public float Scale { get; }

	public string Skin { get; }

	public string InitialAnimationName { get; }

	public SkeletonAnimationLoadParams(GGraph graph, string name, string skin, string initialAnimationName, float scale = 100f)
	{
		Graph = graph;
		Name = name;
		Scale = scale;
		Skin = skin;
		InitialAnimationName = initialAnimationName;
	}
}
