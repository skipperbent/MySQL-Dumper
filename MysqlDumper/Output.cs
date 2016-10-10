using System;
namespace MysqlDumper
{
	public class Output
	{
		public static void ShowArgs()
		{
			Writeline("Usage:");
			Writeline("    " + AppDomain.CurrentDomain + " <arguments>");
			Writeline("\n Arguments:");
			Writeline("    --mysqluser\t\t\tRemote MySQL username.");
			Writeline("    --mysqlpass\t\t\tRemote MySQL password.");
			Writeline("    --mysqlhost\t\t\tRemote MySQL host.");
			Writeline("    --mysqlport\t\t\tRemote MySQL port (default: 3306).");
			Writeline("    --mysqldb\t\t\tDatabase to export (default: all).");

			Writeline("    --tunnelBindHost\t\tHostname/ip to bind to on local client (default: 127.0.0.1).");
			Writeline("    --tunnelHost\t\tHostname when using SSH-tunnel.");
			Writeline("    --tunnelUsername\t\tUsername when using SSH-tunnel.");
			Writeline("    --tunnelPassword\t\tPassword when using SSH-tunnel.");
			Writeline("    --tunnelPort\t\tCustom port when using SSH-tunnel (default: "+ Config.TunnelPort +").");

			Writeline("    --outputFile\t\tFile-path for the newly created export .sql file.");

			Writeline("\n  Help:");
			Writeline("    --help, -h\t\t\tDisplays help message.");
			Writeline("");
		}

		public static bool ParseArguments(string[] args)
		{
			String dbUsername = String.Empty;
			String dbPassword = String.Empty;
			String dbHost = String.Empty;
			uint dbPort = 3306;
			String dbDatabase = String.Empty;
			String tunnelHost = String.Empty;
			String tunnelUsername = String.Empty;
			String tunnelPassword = String.Empty;
			String tunnelBindHost = "127.0.0.1";
			uint tunnelPort = 10000;

			String outputFile = String.Empty;

			for (var i = 0; i < args.Length; i++)
			{
				var arg = args[i].ToLower();

				switch (arg)
				{
					case "--help":
					case "-h":
						ShowArgs();
						return false;
					case "--mysqluser":
						dbUsername = args[i + 1];
						break;
					case "--mysqlpass":
						dbPassword = args[i + 1];
						break;
					case "--mysqlhost":
						dbHost = args[i + 1];
						break;
					case "--mysqlport":
						dbPort = uint.Parse(args[i + 1]);
						break;
					case "--mysqldb":
						dbDatabase = args[i + 1];
						break;
					case "--tunnelhost":
						tunnelHost = args[i + 1];
						break;
					case "--tunneluser":
						tunnelUsername = args[i+1];
						break;
					case "--tunnelpass":
						tunnelPassword = args[i + 1];
						break;
					case "--tunnelport":
						tunnelPort = uint.Parse(args[i + 1]);
						break;
					case "--outputfile":
						outputFile = args[i + 1];
						break;
					case "--tunnelbindhost":
						tunnelBindHost = args[i + 1];
						break;
						
				}
			}

			Config.DbHost = dbHost;
			Config.DbUsername = dbUsername;
			Config.DbPassword = dbPassword;
			Config.DbDatabase = dbDatabase;
			Config.DbPort = dbPort;

			Config.TunnelHost = tunnelHost;
			Config.TunnelPort = tunnelPort;
			Config.TunnelUsername = tunnelUsername;
			Config.TunnelPassword = tunnelPassword;
			Config.TunnelBindHost = tunnelBindHost;

			Config.OutputFile = outputFile;

			return true;
		}

		public static void Write(string text)
		{
			Console.Write(text);
		}

		public static void Write(string text, params string[] arguments)
		{
			Console.Write(text, arguments);
		}

		public static void Writeline(string text)
		{
			Console.WriteLine(text);
		}

		public static void Writeline(string text, params string[] arguments)
		{
			Console.WriteLine(text, arguments);
		}

		public static void ClearLine()
		{
			int currentLineCursor = Console.CursorTop;
			Console.SetCursorPosition(0, Console.CursorTop);
			Console.Write(new string(' ', Console.BufferWidth));
			Console.SetCursorPosition(0, currentLineCursor);
		}
	}
}

