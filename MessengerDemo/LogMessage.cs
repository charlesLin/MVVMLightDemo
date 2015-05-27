using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessengerDemo
{
	class LogMessage
	{
		public LogMessage(string message)
		{
			Message = message;
			Timestamp = DateTime.Now;
		}
		public string Message { get; set; }

		public DateTime Timestamp { get; set; }
	}
}
