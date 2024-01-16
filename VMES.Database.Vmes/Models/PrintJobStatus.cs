namespace VMES.Database.Vmes.Models
{

	public enum PrintJobStatus : byte
	{
		Pending = 3,
		Processed = 5,
		Aborted = 8,
		Completed = 9,
	}

}
