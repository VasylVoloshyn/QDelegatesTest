using System;

namespace QDelegatesTest
{
	class Program
	{
		static void Main(string[] args)
		{
			var myCar = new QCar();
			myCar.RegiterCallback(Message);

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
	public class QCar
	{
		public delegate void SendingCalbackDelegate(string str);
		private SendingCalbackDelegate listOfDelegates;
		public void RegiterCallback(SendingCalbackDelegate methodName)
		{
			listOfDelegates += methodName;
		}

		public string Name { get; set; }
		public int Spead { get; set; }
		public void IncreaseSpead(int incrSpeadAmount)
		{
			Spead += incrSpeadAmount;
			if (Spead % 10 == 0)
			{
				listOfDelegates.Invoke(String.Format("Spead amount increased. New sepead = {0}", Spead));
			}
		}
	}
}
