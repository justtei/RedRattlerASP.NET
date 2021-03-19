using System;
using System.Runtime.CompilerServices;

namespace MSLivingChoices.Logging.Messages
{
	public class Message
	{
		public int Key
		{
			get;
			private set;
		}

		public string Text
		{
			get;
			private set;
		}

		public Message(int key, string text)
		{
			this.Key = key;
			this.Text = text;
		}
	}
}