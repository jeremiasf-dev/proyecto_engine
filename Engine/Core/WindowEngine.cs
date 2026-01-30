using OpenTK.Graphics.OpenGL4;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;
using Engine.Graphics;

namespace Engine.Core
{
	public class WindowEngine : GameWindow
	{
		
		// Campos acccesibles pero privados a través de private set
		// (El compilador se encarga de declararlos ocultos)

		public int Width {get; private set; }
		public int Height {get; private set; }
		public new string Title {get; private set; }
		public Shader? shader;
		public Render? render;
		
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
	
		// Método para actualizar pantalla (Sobreescribo el método heredado de GameWindow)
		protected override void OnUpdateFrame(FrameEventArgs e)
		{
			base.OnUpdateFrame(e);
			
			// Si pulso la tecla ESCAPE la ventana se cierra
			if (KeyboardState.IsKeyDown(Keys.Escape))
			{
				Close();
			}
		}
		
		// Todo lo que debe inicializarse va en este método 
		protected override void OnLoad()
		{
			base.OnLoad();
				
			shader = new Shader("default.vert", "default.frag");
			render = new Render();
			// Cargo el color de la ventana
			GL.ClearColor(0.2f, 0.3f, 0.3f, 1.0f);

			// Acá va el código 
			render.Init();
		}
		
		//~ // Método para renderizar
		protected override void OnRenderFrame(FrameEventArgs e)
		{
			base.OnRenderFrame(e);
			
			GL.Clear(ClearBufferMask.ColorBufferBit);
			render!.Draw(shader!);

			// Intercambio buffers para mostrar en pantalla
			SwapBuffers();
		}
		
		// Actúa cada vez que se hace resize a la pantalla, actualiza el viewport
		protected override void OnFramebufferResize(FramebufferResizeEventArgs e)
		{
			base.OnFramebufferResize(e);
			
			GL.Viewport(0, 0, e.Width, e.Height);
		}
	}
}
