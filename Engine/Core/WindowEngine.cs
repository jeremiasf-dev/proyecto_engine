using OpenTK.Graphics.OpenGL4;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace Engine.Core
{
	public class WindowEngine : GameWindow
	{
		// Campos acccesibles pero privados a través de private set
		// (El compilador se encarga de declararlos ocultos)

		public int Width {get; private set; }
		public int Height {get; private set; }
		public string Title {get; private set; }

		// Constructor de la clase
		// (Instrucciones para construir una instancia (el objeto)
		public WindowEngine(int width,int height,string title)
			: base(	
				GameWindowSettings.Default,
				new NativeWindowSettings() 
				{ 
					ClientSize = (width, height),
					Title = title
				}
			)
		{
			Width  = width;  // Al campo de Width de la clase, le inserto el valor del width del parámetro del constructor
			Height = height; // Lo mismo que arriba
			Title  = title;  // Lo mismo que arriba
		}
	
		// Método para actualizar pantalla
		protected override void OnUpdateFrame(FrameEventArgs e)
		{
			base.OnUpdateFrame(e);
			
			// Si pulso la tecla ESCAPE la ventana se cierra
			if (KeyboardState.IsKeyDown(Keys.Escape))
			{
				Close();
			}
		}
	
	}
}
