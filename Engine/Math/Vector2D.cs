namespace Engine.Math
{	
	public struct Vector2D
	{	// Magnitud (x) y dirección (y)
		public double X; 
		public double Y;

		public Vector2D(double x, double y)
		{
			this.X = x;
			this.Y = y;
		}
	
		public static Vector2D operator +(Vector2D v, Vector2D u) // Static porque no depende de una instancia, es del tipo
		{
			Vector2D c;
			c.X = ( v.X + u.X );	
			c.Y = ( v.Y + u.Y );
			return c;
		}
	
		public static Vector2D operator -(Vector2D v, Vector2D u)
		{
			Vector2D c;
			c.X = v.X - u.X;
			c.Y = v.Y - u.Y;
			return c;
		}
	
		public static Vector2D operator *(Vector2D v, double escalar)
		{
			Vector2D c;
			c.X = v.X * escalar;
			c.Y = v.Y * escalar;
			return c;							
		}
		
		public static double Magnitude(Vector2D v)	// Devuelve la longitud o magnitud de un vector v
		{
			return System.Math.Sqrt(v.X * v.X + v.Y * v.Y);
		}
		
		public static Vector2D Normalize(Vector2D v) // Devuelve un vector unitario normalizado para indicar una dirección y un sentido.
		{
			Vector2D u = v; // Capturo el valor del vector v
			
			double magnitude = Vector2D.Magnitude(v); // Obtengo la magnitud del vector2D v
			
			if (magnitude == 0) 
				{
					u.X = 0.0;
					u.Y = 0.0; // Evito la división por 0 y devuelvo 0
					return u;
				}
			
			u.X = (u.X / magnitude);	// u = ( x / magnitud(v) )
			u.Y = (u.Y / magnitude);	//     ( y / magnitud(v) )
		
			return u;
		}
		
		public static double DotProduct(Vector2D v, Vector2D u)
		{
			double dotProduct = v.X * u.X + v.Y * u.Y;
			return dotProduct;
		}
		
		// Convierte coordenadas a String. Ideal para HUD.
		public override string ToString()
		{
			return $"({X}, {Y})";
		}
	}
}
