namespace Engine.Math
{
	public class Proportion
	{
		// a/b = x/d | a/b = c/x  | x/b = c/d | a/x = c/d	

		public decimal CalculateA(decimal b, decimal c, decimal d)
		{
			decimal x = (b * c) / d;
			return x;
		};
		
		public decimal CalculateB(decimal a, decimal c, decimal d)
		{
			decimal x = (a * d) / c;
			return x;
		};
		
		public decimal CalculateC(decimal a, decimal b, decimal d)	
		{
			decimal x = (a * d) / b;
			return x;
		};		
		
		public decimal CalculateD(decimal a, decimal b, decimal c)	
		{
			decimal x = (b * c) / a;
			return x;
		};	
	}
}
