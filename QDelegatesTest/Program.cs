using System;

namespace QDelegatesTest
{
	class Program
	{
		static void Main(string[] args)
		{
			var myCar = new QCar();
			myCar.RegiterCallback(Message);
			var listener = new Listener();
			myCar.RegiterCallback(new QCar.SendingCalbackDelegate(listener.NewMessage));
			myCar.RegiterCallback(listener.NewMessage2);
			myCar.RegisterActionDelegate(Message);
			for (int i = 0; i < 100; i++)
			{
				myCar.IncreaseSpead(1);
			}

			Console.ReadLine();
		}
		
		static void Message(string str)
		{
			Console.WriteLine(str);
		}		
		
	}

	public class Listener
	{
		public void NewMessage(string str)
		{
			Console.WriteLine("Listener: " + str);
		}

		public void NewMessage2(string str)
		{
			Console.WriteLine("Simple Message: " + str);
		}
	}

	public class QCar
	{
		public delegate void SendingCalbackDelegate(string str);
		private SendingCalbackDelegate listOfDelegates;
		public void RegiterCallback(SendingCalbackDelegate methodName)
		{
			listOfDelegates += methodName;
		}

		private Action<string> actionDelegate;
		public void RegisterActionDelegate(Action<string> actionMethod)
		{
			actionDelegate += actionMethod;
		}

		public string Name { get; set; }
		public int Spead { get; set; }
		public void IncreaseSpead(int incrSpeadAmount)
		{
			Spead += incrSpeadAmount;
			if (Spead % 10 == 0)
			{
				listOfDelegates(String.Format("Spead amount increased. New sepead = {0}", Spead));
				actionDelegate("Action:");
			}
		}
	}
}
