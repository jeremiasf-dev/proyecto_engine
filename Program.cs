using Engine.Core;
using Engine.Math;

class Program
{
	static void Main()
	{
		
		Console.WriteLine("Hello, World!");
		
		// Inicializo variables
		
		// Al estar ubicadas en Main, se inicializan como variables locales
		int widthSize  = 800;
		int heightSize  = 600;
		
		// Declaro y defino la ventana
		WindowEngine window = new WindowEngine(widthSize, heightSize, "Proyecto engine");
		
		// Creo el objeto "coordinates" y capturo el valor del centro cartesiano (x0, y0) 
		CoordinateSystem coordinates = new CoordinateSystem();
		coordinates.UpdateCenter((double)widthSize, (double)heightSize);
		
		// Ejecuto la ventana a lo que banque la gpu (No declaré límite de FPS, ! Investigar sobre esto)
		window.Run();
		
		
		// TEST TEST TEST TEST
		
		//~ Vector2D recta = new Vector2D(0,0);
		//~ Vector2D enPantalla = coordinates.ToWindowsCoordinates(recta);
		//~ Vector2D enXY = coordinates.ToCartesianCoordinates(recta);
		//~ Console.WriteLine($"Coordenadas: {enPantalla.X} , {enPantalla.Y}");
		//~ Console.WriteLine($"Coordenadas: {enXY.X} , {enXY.Y}");
		//~ Console.WriteLine(coordinates.Center);
		// TEST TEST TEST TEST
	
	
	}
}
