using System;
namespace MysqlDumper
{
	public class Config
	{
		public enum DebugLevel
		{
			Info,
			Errors,
			Debug
		}

		public static string ApplicationName = "MysqlDumper";
		public static string AuthorName = "Simon Sessingø";
		public static string Version = "1.0";

		public static string DbHost { get; set; }
		public static string DbUsername { get; set; }
		public static string DbPassword { get; set; }
		public static string DbDatabase { get; set; }
		public static uint DbPort { get; set; }

		public static string TunnelBindHost { get; set; }
		public static string TunnelHost { get; set; }
		public static string TunnelUsername { get; set; }
		public static string TunnelPassword { get; set; }
		public static uint TunnelPort { get; set; }

		public static String OutputFile { get; set; }

	}
}

