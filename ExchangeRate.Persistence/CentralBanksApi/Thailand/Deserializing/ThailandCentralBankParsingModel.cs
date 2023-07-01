using System.Text.Json.Serialization;

#pragma warning disable CS8618

namespace ExchangeRate.Persistence.CentralBanksApi.Thailand.Deserializing;

public class Root
{
	[JsonPropertyName("result")]
	public Result Result { get; set; }
}

public class Result
{
	[JsonIgnore]
	[JsonPropertyName("timestamp")]
	public string Timestamp { get; set; }

	[JsonIgnore]
	[JsonPropertyName("api")]
	public string Api { get; set; }

	[JsonPropertyName("data")]
	public Data Data { get; set; }
}

public class Data
{
	[JsonIgnore]
	[JsonPropertyName("data_header")]
	public DataHeader DataHeader { get; set; }

	[JsonPropertyName("data_detail")]
	public List<DataDetail> DataDetail { get; set; } = new();
}

public class DataHeader
{
	[JsonPropertyName("report_name_eng")]
	public string ReportNameEng { get; set; }

	[JsonPropertyName("report_name_th")]
	public string ReportNameTh { get; set; }

	[JsonPropertyName("report_uoq_name_eng")]
	public string ReportUoqNameEng { get; set; }

	[JsonPropertyName("report_uoq_name_th")]
	public string ReportUoqNameTh { get; set; }

	[JsonPropertyName("report_source_of_data")]
	public List<ReportSourceOfDatum> ReportSourceOfData { get; set; } = new();

	[JsonPropertyName("report_remark")]
	public List<ReportRemark> ReportRemark { get; set; } = new();

	[JsonPropertyName("last_updated")]
	public string LastUpdated { get; set; }
}

public class ReportSourceOfDatum
{
	[JsonPropertyName("source_of_data_eng")]
	public string SourceOfDataEng { get; set; }

	[JsonPropertyName("source_of_data_th")]
	public string SourceOfDataTh { get; set; }
}

public class ReportRemark
{
	[JsonPropertyName("report_remark_eng")]
	public string ReportRemarkEng { get; set; }

	[JsonPropertyName("report_remark_th")]
	public string ReportRemarkTh { get; set; }
}

public class DataDetail
{
	[JsonIgnore]
	[JsonPropertyName("period")]
	public string Period { get; set; }

	[JsonPropertyName("currency_id")]
	public string CurrencyId { get; set; }

	[JsonIgnore]
	[JsonPropertyName("currency_name_th")]
	public string CurrencyNameTh { get; set; }

	[JsonPropertyName("currency_name_eng")]
	public string CurrencyNameEng { get; set; }

	[JsonIgnore]
	[JsonPropertyName("buying_sight")]
	public string BuyingSight { get; set; }

	[JsonIgnore]
	[JsonPropertyName("buying_transfer")]
	public string BuyingTransfer { get; set; }

	[JsonIgnore]
	[JsonPropertyName("selling")]
	public string Selling { get; set; }

	[JsonPropertyName("mid_rate")]
	public string MidRate { get; set; }
}