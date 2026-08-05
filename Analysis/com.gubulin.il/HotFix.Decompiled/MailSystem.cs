using System;
using System.Collections.Generic;
using System.Linq;
using GameMaths;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;

public sealed class MailSystem : BaseExecuteSystem
{
	private int CheckingCycle = 50;

	public MailSystem(Contexts contexts)
		: base(contexts)
	{
		CheckingCycle = Mathf.RoundToInt(1f / contexts.Service<ITimeService>().FixedDeltaTime());
	}

	public override void Execute()
	{
		if (GameManagers.Instance == null || !GameManagers.Instance.Initialized || !_contexts.gameState.hasUser || !_contexts.gameState.isDataReady || _contexts.input.tick.value % CheckingCycle != 0)
		{
			return;
		}
		DateTimeOffset now = DateTimeHelper.Now;
		List<int> list = (from mail in GameManagers.Instance.MailManager.Mails.Values
			where now.CompareTo(mail.ExpireTime) >= 0
			select mail.Id).ToList();
		foreach (int item in list)
		{
			GameManagers.Instance.MailManager.DeleteMail(item);
		}
	}
}
