using System;
using Newtonsoft.Json;

namespace Nest
{
	[JsonObject(MemberSerialization = MemberSerialization.OptIn)]
	[ContractJsonConverter(typeof(AggregationJsonConverter<SamplerAggregation>))]
	public interface ISamplerAggregation : IBucketAggregation
	{
		[JsonProperty("execution_hint")]
		SamplerAggregationExecutionHint? ExecutionHint { get; set; }

		[JsonProperty("max_docs_per_value")]
		int? MaxDocsPerValue { get; set; }

		[JsonProperty("script")]
		IScript Script { get; set; }

		[JsonProperty("shard_size")]
		int? ShardSize { get; set; }
	}

	public class SamplerAggregation : BucketAggregationBase, ISamplerAggregation
	{
		internal SamplerAggregation() { }

		public SamplerAggregation(string name) : base(name) { }

		public SamplerAggregationExecutionHint? ExecutionHint { get; set; }
		public int? MaxDocsPerValue { get; set; }
		public IScript Script { get; set; }
		public int? ShardSize { get; set; }

		internal override void WrapInContainer(AggregationContainer c) => c.Sampler = this;
	}

	public class SamplerAggregationDescriptor<T>
		: BucketAggregationDescriptorBase<SamplerAggregationDescriptor<T>, ISamplerAggregation, T>, ISamplerAggregation
		where T : class
	{
		SamplerAggregationExecutionHint? ISamplerAggregation.ExecutionHint { get; set; }
		int? ISamplerAggregation.MaxDocsPerValue { get; set; }
		IScript ISamplerAggregation.Script { get; set; }
		int? ISamplerAggregation.ShardSize { get; set; }

		public SamplerAggregationDescriptor<T> ExecutionHint(SamplerAggregationExecutionHint? executionHint) =>
			Assign(a => a.ExecutionHint = executionHint);

		public SamplerAggregationDescriptor<T> MaxDocsPerValue(int? maxDocs) => Assign(a => a.MaxDocsPerValue = maxDocs);

		public SamplerAggregationDescriptor<T> Script(string script) => Assign(a => a.Script = (InlineScript)script);

		public SamplerAggregationDescriptor<T> Script(Func<ScriptDescriptor, IScript> scriptSelector) =>
			Assign(a => a.Script = scriptSelector?.Invoke(new ScriptDescriptor()));

		public SamplerAggregationDescriptor<T> ShardSize(int? shardSize) => Assign(a => a.ShardSize = shardSize);
	}
}
