using Raven.Abstractions;
using Raven.Database.Linq;
using System.Linq;
using System.Collections.Generic;
using System.Collections;
using System;
using Raven.Database.Linq.PrivateExtensions;
using Lucene.Net.Documents;
using System.Globalization;
using System.Text.RegularExpressions;
using Raven.Database.Indexing;

public class Transformer_FailedMessageViewTransformer : Raven.Database.Linq.AbstractTransformer
{
	public Transformer_FailedMessageViewTransformer()
	{
		this.ViewText = @"from failure in results
select new {
	failure = failure,
	rec = DynamicEnumerable.LastOrDefault(failure.ProcessingAttempts)
} into this0
select new {
	Id = this0.failure.UniqueMessageId,
	MessageType = this0.rec.MessageMetadata[""MessageType""],
	IsSystemMessage = ((bool)this0.rec.MessageMetadata[""IsSystemMessage""]),
	SendingEndpoint = this0.rec.MessageMetadata[""SendingEndpoint""],
	ReceivingEndpoint = this0.rec.MessageMetadata[""ReceivingEndpoint""],
	TimeSent = ((DateTime?)this0.rec.MessageMetadata[""TimeSent""]),
	MessageId = this0.rec.MessageMetadata[""MessageId""],
	Exception = this0.rec.FailureDetails.Exception,
	QueueAddress = this0.rec.FailureDetails.AddressOfFailingEndpoint,
	NumberOfProcessingAttempts = this0.failure.ProcessingAttempts.Count,
	Status = this0.failure.Status,
	TimeOfFailure = this0.rec.FailureDetails.TimeOfFailure,
	LastModified = this0.failure[""@metadata""][""Last-Modified""].Value<DateTime>()
}
";
		this.TransformResultsDefinition = results => 
			from failure in ((IEnumerable<dynamic>)results)
			select new {
				failure = failure,
				rec = DynamicEnumerable.LastOrDefault(failure.ProcessingAttempts)
			} into this0
			select new {
				Id = this0.failure.UniqueMessageId,
				MessageType = this0.rec.MessageMetadata["MessageType"],
				IsSystemMessage = ((bool)this0.rec.MessageMetadata["IsSystemMessage"]),
				SendingEndpoint = this0.rec.MessageMetadata["SendingEndpoint"],
				ReceivingEndpoint = this0.rec.MessageMetadata["ReceivingEndpoint"],
				TimeSent = ((DateTime?)this0.rec.MessageMetadata["TimeSent"]),
				MessageId = this0.rec.MessageMetadata["MessageId"],
				Exception = this0.rec.FailureDetails.Exception,
				QueueAddress = this0.rec.FailureDetails.AddressOfFailingEndpoint,
				NumberOfProcessingAttempts = this0.failure.ProcessingAttempts.Count,
				Status = this0.failure.Status,
				TimeOfFailure = this0.rec.FailureDetails.TimeOfFailure,
				LastModified = this0.failure["@metadata"]["Last-Modified"].Value<DateTime>()
			};
	}
}
