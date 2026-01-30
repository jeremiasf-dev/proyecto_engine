using OpenTK.Graphics.OpenGL4;

namespace Engine.Graphics
{
	public class Shader
	{
		private int Handle;

		public Shader (string vertexpath, string fragmentpath)
		{
			string baseDir = AppContext.BaseDirectory;
			string _vertexPath   = Path.Combine(baseDir, "Engine", "Graphics", "Shaders", vertexpath);
			string _fragmentPath = Path.Combine(baseDir, "Engine", "Graphics", "Shaders", fragmentpath);
		
			
			// Lee el código fuente de los shaders
			string VertexShaderSource = File.ReadAllText(_vertexPath);
			string FragmentShaderSource = File.ReadAllText(_fragmentPath);
			
			// Compila Vertex Shader
			int VertexShader = GL.CreateShader(ShaderType.VertexShader);
			GL.ShaderSource(VertexShader, VertexShaderSource);
			GL.CompileShader(VertexShader);
			GL.GetShader(VertexShader, ShaderParameter.CompileStatus, out int successVertex);
			
			if (successVertex == 0)
			{
				string infoLog = GL.GetShaderInfoLog(VertexShader);
				Console.WriteLine(infoLog);
			}


			// Compilar Fragment Shader
			int FragmentShader = GL.CreateShader(ShaderType.FragmentShader);
			
			GL.ShaderSource(FragmentShader, FragmentShaderSource);
			GL.CompileShader(FragmentShader);
			GL.GetShader(FragmentShader, ShaderParameter.CompileStatus, out int successFragment);
			
			if (successFragment == 0)
			{
				string infoLog = GL.GetShaderInfoLog(FragmentShader);
				Console.WriteLine(infoLog);
			}
			

			
			// Linkear programa
			Handle = GL.CreateProgram();

			GL.AttachShader(Handle, VertexShader);
			GL.AttachShader(Handle, FragmentShader);
			GL.LinkProgram(Handle);

			GL.GetProgram(Handle, GetProgramParameterName.LinkStatus, out int successProgram);
			
			if (successProgram == 0)
			{
				string infoLog = GL.GetProgramInfoLog(Handle);
				Console.WriteLine(infoLog);
			}
			
			// Limpio shaders ya linkeados
			GL.DetachShader(Handle, VertexShader);
			GL.DetachShader(Handle, FragmentShader);
			GL.DeleteShader(FragmentShader);
			GL.DeleteShader(VertexShader);
		}
			
		public void Use()
		{
			GL.UseProgram(Handle);
		}
		
		private bool disposedValue = false;

		protected virtual void Dispose(bool disposing)
		{
			if (!disposedValue)
			{
				GL.DeleteProgram(Handle);

				disposedValue = true;
			}
		}
		
		// Solo debug
		//~ ~Shader()
		//~ {
			//~ if (disposedValue == false)
			//~ {
				//~ Console.WriteLine("GPU Resource leak! Did you forget to call Dispose()?");
			//~ }
		//~ }


		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
			//~ shader.Dispose();
		}

	}	
}
