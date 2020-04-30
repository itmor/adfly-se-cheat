using System;
using System.Net;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Timers;

namespace SeproxyTools
{
	public class Seproxy
	{
		private string serverAdress;
		private bool connected = false;
		private Timer workerTimer = new Timer(3000);
		
		public void Connect()
		{
			if (serverAdress != "")
			{
				connected = true;
			} else
			{
				throw new Exception("Server address not found");
			}

		}

		public bool SetServerAddress(string url)
		{
			if (!connected && IsServerAdress(url) && IsServerRunning(url))
			{
				serverAdress = url;
				return true;
			}
			else
			{
				return false;

			}
		}

		private bool IsServerAdress(string url)
		{
			string pattern = "http://([0-9]+.[0-9]+.[0-9]+.[0-9]+:[0-9]+)";
			while (true)
			{
				if (Regex.IsMatch(url, pattern, RegexOptions.IgnoreCase))
				{
					
					return IsServerRunning(url);
				}
				else
				{
					return false;
				}
			}

		}


		private bool IsServerRunning(string url)
		{
			string result = Get(url + "/test");

			if (result != "error")
			{
				return true;
			} else
			{
				return false;
			}
			
		}

		public string Get(string url)
		{
			WebClient webClient = new WebClient();

			try
			{
				string response = webClient.DownloadString(url);

				return response;
			}
			catch (WebException e)
			{
				Debug.WriteLine(e);
				return "error";
			}

		}

		public void Disconnect()
		{
			connected = false;
			serverAdress = "";
		}

		public void GetNewProxy(Action callback)
		{
			Get(serverAdress + "/getNewProxy");

			workerTimer.Elapsed += delegate
			{
				string status = Get(serverAdress + "/status");
		
				if (status == "not work" || connected == false)
				{
					callback();
					workerTimer.Stop();
				}
			};

			workerTimer.Start();
		}	 
	}

}