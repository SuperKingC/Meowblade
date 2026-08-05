using Shift.Legion.Common.Models;

namespace Shift.Legion.Common.Services;

public interface ITextTranslateService : IService
{
	InfoEvo GetInfoEvo(string evoInfoId);
}
