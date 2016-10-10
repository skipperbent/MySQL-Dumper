using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Text;
using MySql.Data.MySqlClient;
using Renci.SshNet;
using Renci.SshNet.Common;

namespace MysqlDumper
{
	class MainClass
	{

		protected static bool running;

		protected static SshClient client;

		public static void Main(string[] args)
		{
			Output.Writeline("");
			if (!Output.ParseArguments(args))
			{
				Environment.Exit(0);
			}

			List<string> errors = new List<string>();

			if (String.IsNullOrEmpty(Config.DbHost))
			{
				errors.Add("  --mysqlhost");
			}

			if (String.IsNullOrEmpty(Config.DbUsername))
			{
				errors.Add("  --mysqluser");
			}

			if (String.IsNullOrEmpty(Config.DbPassword))
			{
				errors.Add("  --mysqlpass");
			}

			if (String.IsNullOrEmpty(Config.TunnelHost))
			{
				errors.Add("  --tunnelhost");
			}

			if (String.IsNullOrEmpty(Config.TunnelUsername))
			{
				errors.Add("  --tunneluser");
			}

			if (String.IsNullOrEmpty(Config.TunnelPassword))
			{
				errors.Add("  --tunnelpass");
			}

			if (String.IsNullOrEmpty(Config.OutputFile))
			{
				errors.Add("  --outputfile");
			}

			if (String.IsNullOrEmpty(Config.DbDatabase))
			{
				errors.Add("  --mysqldb");
			}

			if (errors.Count > 0)
			{
				Output.Write("Error: missing one or more required parameters:\n{0}", String.Join("\n", errors));
				Console.WriteLine("");
				Console.WriteLine("\nUse --help to display information about availible arguments.");
				Environment.Exit(1);
			}

			running = true;

			Console.CancelKeyPress += delegate (object sender, ConsoleCancelEventArgs e)
			{
				running = false;
			};

			Console.WriteLine(" + Establishing connection to " + Config.TunnelHost);

			try
			{
				using (client = new SshClient(Config.TunnelHost, Config.TunnelUsername, Config.TunnelPassword))
				{
					//client.KeepAliveInterval = new TimeSpan(0, 0, 0, 20);
					//client.ConnectionInfo.Timeout = new TimeSpan(0, 0, 5);

					client.Connect();

					Console.WriteLine(" + Forwarding connection " + Config.DbHost + ":" + Config.DbPort + " -> " + Config.TunnelBindHost + ":" + Config.TunnelPort);

					using (var port = new ForwardedPortLocal(Config.TunnelBindHost, Config.TunnelPort, Config.DbHost, Config.DbPort))
					{
						port.Exception += delegate (object sender, ExceptionEventArgs e)
						{
							//Output.Writeline("   Error: " + e.Exception.Message);
						};

						client.AddForwardedPort(port);

						port.Start();

						Console.WriteLine(" + Connecting to MySQL "+ Config.TunnelBindHost +":" + Config.TunnelPort);

						string connectionString = "server="+ Config.TunnelBindHost +";AllowZeroDateTime=true;ConvertZeroDateTime=true;port=" + Config.TunnelPort + ";user=" + Config.DbUsername + ";pwd=" + Config.DbPassword + ";database=" + Config.DbDatabase + ";charset=utf8;";
						using (MySqlConnection conn = new MySqlConnection(connectionString))
						{
							using (MySqlCommand cmd = new MySqlCommand())
							{
								cmd.CommandTimeout = 0;

								using (MySqlBackup mb = new MySqlBackup(cmd))
								{
									Console.WriteLine(" + Starting export to file: " + Config.OutputFile);

									Console.WriteLine("");
									Console.WriteLine("");
									Console.WriteLine("");
									Console.WriteLine("");

									mb.ExportInfo.AddCreateDatabase = true;
									mb.ExportInfo.ExportTableStructure = true;

									mb.ExportProgressChanged += delegate (object sender, ExportProgressArgs e)
									{
										Console.Clear();

										var progress = Math.Floor(((double)(e.CurrentRowIndexInAllTables / (double)e.TotalRowsInAllTables) * 100));
										var maxBlocks = 50;

										var activeBlocks = Math.Max(1, progress * 0.50);

										Console.WriteLine("   TABLE: " + e.CurrentTableName);
										Console.WriteLine("");
										Console.WriteLine("   PROGRESS:");
										Console.Write("   ");

										for (var i = 0; i <= activeBlocks; i++)
										{
											Console.Write("=");
										}

										for (var i = 0; i < (maxBlocks - activeBlocks); i++)
										{
											Console.Write("-");
										}

										Console.Write(" " + progress + "%");
									};

									mb.ExportCompleted += delegate (object sender, ExportCompleteArgs e)
									{
										Output.ClearLine();

										Console.SetCursorPosition(0, Console.CursorTop - 1);
										Output.ClearLine();

										Console.SetCursorPosition(0, Console.CursorTop - 2);
										Output.ClearLine();

										Console.Write("   - COMPLETE!");
										Console.WriteLine("");

										running = false;
									};

									cmd.Connection = conn;

									conn.Open();

									using (var ms = new FileStream(Config.OutputFile, FileMode.Create))
									{
										using (var zip = new GZipStream(ms, CompressionMode.Compress))
										{
											using (var writer = new StreamWriter(zip, Encoding.UTF8))
											{
												mb.ExportToTextWriter(writer);
											}
										}
									}

									//mb.StopAllProcess();
									//conn.Close();
								}
							}
						}

						while (running)
						{

						}

						if (client.IsConnected)
						{
							port.Stop();
							client.Disconnect();
						}
					}
				}
			}
			catch (Exception e)
			{
				Output.Writeline("   - Error: " + e.Message);
			}

			return;
		}
	}
}