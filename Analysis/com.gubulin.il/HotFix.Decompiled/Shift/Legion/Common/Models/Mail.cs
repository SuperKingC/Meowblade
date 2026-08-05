using System;
using Shift.Legion.Common.Sources.Enums;

namespace Shift.Legion.Common.Models;

public class Mail
{
	public int Id { get; set; }

	public int UserId { get; set; }

	public string Title { get; set; }

	public string Content { get; set; }

	public DateTimeOffset CreatedTime { get; set; }

	public DateTimeOffset ExpireTime { get; set; }

	public MailStatus Status { get; set; }

	public bool HasPayloads { get; set; }

	public string PayloadsConfig { get; set; }

	public string ExtraPayloadsConfig { get; set; }
}
