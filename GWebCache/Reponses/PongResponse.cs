﻿using GWebCache.Extensions;
namespace GWebCache.Reponses;

public class PongResponse : GWebCacheResponse {
	public string? CacheVersion { get; set; }
	public string? SupportedNet { get; set; }

	internal override bool IsValidResponse(HttpResponseMessage? responseMessage) {
		if (!base.IsValidResponse(responseMessage))
			return false;

		return responseMessage!.ContentAsString().Contains("pong", StringComparison.InvariantCultureIgnoreCase);
	}

	internal override bool IsValidV2Response(HttpResponseMessage? responseMessage) {
		if (!IsValidResponse(responseMessage))
			return false;

		string[] fields = responseMessage!.SplitContentInFields();
		return fields.Length >= 2 && fields[0].Equals("I", StringComparison.InvariantCultureIgnoreCase) 
			&& fields[1].Equals("pong", StringComparison.InvariantCultureIgnoreCase);
	}

	internal override void Parse(HttpResponseMessage response) {
		//Get the version of the cache v1 requests are typically -> "pong" "cache version"
		CacheVersion = response.ContentAsString().Replace("pong", "", StringComparison.InvariantCultureIgnoreCase).Trim();
	}


	internal override void ParseV2(HttpResponseMessage response) {
		string[] fields = response.SplitContentInFields();
		CacheVersion = fields.Length > 2 ? fields[2] : "";
		SupportedNet = fields.Length > 3 ? fields[3] : "";
	}
}