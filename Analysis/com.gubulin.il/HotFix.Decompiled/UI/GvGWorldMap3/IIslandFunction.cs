namespace UI.GvGWorldMap3;

public interface IIslandFunction
{
	GvG3IslandFunctionBase FunctionBase { get; }

	string FunctionDesc { get; }

	void Render(IslandFuncStatus funcStatus, string functionType);
}
