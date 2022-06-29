using System;

public class Fishs
{
		public string Type { get; set; }

		public Fish()
        {
			Random rnd = new Random();
			int x = rnd.Next(0, 101);

			if (x < 40)
				Type = "s";
			else if (x < 75)
				Type = "m";
			else 
				Type = "b";

        }
		public Eat(string TypeEat)
        {
			
        }

		private EatS(string TypeEat)
        {

        }

		private Eatm(string TypeEat)
        {

        }
		private EatM(string TypeEat)
		{

		}
		private Eatb(string TypeEat)
		{

		}
		private EatB(string TypeEat)
		{

		}

	
}
