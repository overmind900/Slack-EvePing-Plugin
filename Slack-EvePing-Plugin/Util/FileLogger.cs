using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows;

namespace Slack_EvePing_Plugin.Util {
	internal partial class FileLogger : ILogger {

		private string m_LogFile;
		private StreamWriter m_FileStream;
		private bool IsOpen = false;

		public string LogFile {
			get { return m_LogFile; }
			private set { m_LogFile = value; }
		}

		public FileLogger() {
			m_LogFile = string.Format("Log-{0}.log", DateTime.UtcNow.ToString("yyyy-MM-dd HH-mm-ss"));
			m_FileStream = File.CreateText(m_LogFile);
			IsOpen = true;
			AppDomain.CurrentDomain.UnhandledException += (s,e) => Log( WarnLevel.ERROR, e.ExceptionObject.ToString());			
		}


		public void Log(string message) {
			Log(WarnLevel.INFO, message);	
		}

		public void Log(WarnLevel level, string message) {
			m_FileStream.WriteLine(string.Format("{0} - {1}: {2}", DateTime.UtcNow.ToString("HH:mm:ss.ffff"),level.ToString(), message));
		}

		public void Close() {
			if(IsOpen) {
				m_FileStream.Close(); 
				IsOpen = false;
			}
		}

	}
}
