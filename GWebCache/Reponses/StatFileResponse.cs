﻿using GWebCache.Extensions;
namespace GWebCache.Reponses;

public class StatFileResponse : GWebCacheResponse {
	public int TotalNumberOfRequests { get; set; }
	public int RequestsInLastHour { get; set; }
	public int? UpdateRequestsInLastHour { get; set; }


	public override bool IsValidResponse(HttpResponseMessage responseMessage) {
		string[] lines = responseMessage.ContentAsString().Split("\n").Select(l => l.Trim()).Where(l => !string.IsNullOrEmpty(l)).ToArray();
		if (lines.Length < 2 || lines.Any(line => !int.TryParse(line, out int _))) {
			return false;
		}

		return base.IsValidResponse(responseMessage);
	}
	public override void Parse(HttpResponseMessage? response) {
		string[]? lines = response?.ContentAsString().Split("\n").Select(l => l.Trim()).Where(l => !string.IsNullOrEmpty(l)).ToArray();
		TotalNumberOfRequests = int.Parse(lines[0]);
		RequestsInLastHour = int.Parse(lines[1]);
		if (lines.Length > 2) {
			UpdateRequestsInLastHour = int.Parse(lines[2]);
		}
	}
}
