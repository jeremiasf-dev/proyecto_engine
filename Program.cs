using Engine.Core;

class Program
{
	static void Main()
	{
		Console.WriteLine("Hello, World!");
		
		// Declaro y defino la ventana
		WindowEngine window = new WindowEngine(800, 600, "Proyecto engine");
		
		// Ejecuto la ventana a 60fps máximos
		window.Run();
		
	}
}
