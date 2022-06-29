using System;

public class Fishs
{
	string Type { get; set; }

	public Fishs()
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
	
	/// <summary>
    /// Вертає: 0 - якщо вибухає 1 - якщо Не може з'їсти
    /// </summary>
    /// <param name="TypeEat"></param>
    /// <returns></returns>
    public string Eat(string TypeEat)
	{
		switch (Type)
		{
			case "s":
				return EatS(TypeEat);
				break;
			case "m":
				return Eatm();
				break;
			case "M":
				return EatM();
				break;
			case "b":
				return Eatb();
			case "B":
				return EatB();

		}
		return "1";
	}

	private string EatS(string TypeEat)
	{
		return "1";
	}
	private string Eatm(string TypeEat)
	{
		if (TypeEat == "s")
		{
			Type = "M";
			return "M";
		}
		return "1";
	}
	private string EatM(string TypeEat)
	{
		if (TypeEat == "s")
			return "0";

		return "1";
	}
	private string Eatb(string TypeEat)
	{
		if (TypeEat == "m")
		{
			Type = "B";
			return "B";
		}
		else if (TypeEat == "M")
			return "0";

		return "1";
	}
	private string EatB(string TypeEat)
	{
		if (TypeEat == "m")
			return "0";
		else if (TypeEat == "M")
			return "0";
		return "1";
	}


}
