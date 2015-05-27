using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Messaging;

namespace MessengerDemo
{
	class LogMessageViewModel
	{
		public NotificationMessage<ConfirmMessage> NotificationMessage { get; set; }

		public bool IsConfirm { get; set; }

		public override string ToString()
		{
			var cm = NotificationMessage.Content;
			var log = string.Format("{0}, you agree that? {1},  at {2: HHmmss}",
				cm.Message, IsConfirm, cm.Timestamp);

			return log;
		}
	}
}
