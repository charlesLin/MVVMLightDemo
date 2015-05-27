using System;

namespace MessengerDemo
{
	class ConfirmMessage : LogMessage
	{
		public ConfirmMessage(string message, Func<bool> confirmAction) : base(message)
		{
			Confirm = confirmAction;
		}
		public Func<bool> Confirm { get; private set; }



	}
}