namespace BlazorServer.Extensions
{
    public static class DateTimeExtensions
    {
		/// <summary>
		/// Metodo de Extension
		/// </summary>
		/// <param name="dateTime"></param>
		/// <returns>DateTime</returns>
		public static int GetQuarter(this DateTime dateTime)
		{
			var month = dateTime.Month;
			int trim = 1;
			switch (month)
			{
				case int when (month >= 1 && month <= 3):
					trim = 1;
					break;
				case int when (month >= 4 && month <= 6):
					trim = 2;
					break;
				case int when (month >= 7 && month <= 9):
					trim = 3;
					break;
				case int when (month >= 10 && month <= 12):
					trim = 4;
					break;
			}

			return trim;
		}


		public static string GetQuarterName(this DateTime dateTime)
		{
			var month = dateTime.Month;
			string trim = "Q1";
			switch (month)
			{
				case int when (month >= 1 && month <= 3):
					trim = "Q1";
					break;
				case int when (month >= 4 && month <= 6):
					trim = "Q2";
					break;
				case int when (month >= 7 && month <= 9):
					trim = "Q3";
					break;
				case int when (month >= 10 && month <= 12):
					trim = "Q4";
					break;
			}

			return trim;
		}
	}
}
