namespace Shift.Legion.Common.Services;

public interface IModelTransToConfig<ConfigT>
{
	void ModelTransToConfig(out ConfigT result);
}
