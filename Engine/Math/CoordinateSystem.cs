namespace Engine.Math
{
	public class CoordinateSystem
	{
		private double Width;
		private double Height;
		public Vector2D Center {get; private set; } // get para que pueda ser leído desde fuera y private set para que el compilador lo marque como private y reducir lineas de codigo, lo cual es genial porque me las cobran
		
		// "void" y no static? Porque actualizan el estado del objeto (métodos de instancia)
		public void UpdateCenter(double width, double height)
		{
			Width  = width;
			Height = height;
			Center = new Vector2D (width / 2 , height / 2);
		}
		
		// En los siguientes métodos no es necesario volver a pasar width y height, 
		// puesto que están actualizados en tiempo real
		
		public Vector2D ToWindowsCoordinates(Vector2D v)
		{
			// Traslada un vector cartesiano al sistema de ventana
			return new Vector2D(v.X + Center.X , v.Y + Center.Y);
		}
			
		public Vector2D ToCartesianCoordinates(Vector2D v)
		{	
			// Traslada un vector en coordenadas de ventana al sistema cartesiano
			return new Vector2D(v.X - Center.X , v.Y - Center.Y);
		}
	}
}
