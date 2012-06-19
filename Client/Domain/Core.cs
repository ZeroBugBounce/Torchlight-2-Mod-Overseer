using System;
using ZeroBugBounce.Missive;
using System.Reflection;

namespace Domain
{
	public static class Core
	{
		static Messenger messenger;

		public static Messenger Messenger
		{
			get
			{
				return messenger;
			}
		}

		static Core()
		{
			messenger = new Messenger();
		}

		public static void ScanAndLoadHandlers(Assembly assembly)
		{
			messenger.ScanAndLoadHandlers(assembly);
		}

		public static void AddHandlers(params Handler[] handlers)
		{
			messenger.AddHandlers(handlers);
		}

		public static Receipt Send<TMessage, TReply>(TMessage message, Action<TReply> reply)
		{
			return messenger.Send<TMessage, TReply>(message, reply);
		}

		public static Receipt Send<TMessage>(TMessage message)
		{
			return messenger.Send<TMessage>(message);
		}
	}
}
