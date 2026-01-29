namespace Engine.math
{	
	public struct Vector2D
	{	// Magnitud (x) y dirección (y)
		public double x; 
		public double y;

		public Vector2D(double x, double y)
		{
			this.x = x;
			this.y = y;
		}
	
		public static Vector2D operator +(Vector2D v, Vector2D u) // Static porque no depende de una instancia, es del tipo
		{
			Vector2D c;
			c.x = ( v.x + u.x );	
			c.y = ( v.y + u.y );
			return c;
		}
	
		public static Vector2D operator -(Vector2D v, Vector2D u)
		{
			Vector2D c;
			c.x = v.x - u.x;
			c.y = v.y - u.y;
			return c;
		}
	
		public static Vector2D operator *(Vector2D v, double escalar)
		{
			Vector2D c;
			c.x = v.x * escalar;
			c.y = v.y * escalar;
			return c;							
		}
		
		public static double Magnitude(Vector2D v)	// Devuelve la longitud o magnitud de un vector v
		{
			return System.Math.Sqrt(v.x * v.x + v.y * v.y);
		}
		
		public static Vector2D Normalize(Vector2D v) // Devuelve un vector unitario normalizado para indicar una dirección y un sentido.
		{
			Vector2D u = v; // Capturo el valor del vector v
			
			double magnitude = Vector2D.Magnitude(v); // Obtengo la magnitud del vector2D v
			
			if (magnitude == 0) 
				{
					u.x = 0f;
					u.y = 0f; // Evito la división por 0 y devuelvo 0
					return u;
				}
			
			u.x = (u.x / magnitude);	// u = ( x / magnitud(v) )
			u.y = (u.y / magnitude);	//     ( y / magnitud(v) )
		
			return u;
		}
		
		public static double DotProduct(Vector2D v, Vector2D u)
		{
			double dotProduct = v.x * u.x + v.y * u.y;
			return dotProduct;
		}
	}
}
