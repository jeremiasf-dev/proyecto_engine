using OpenTK.Graphics.OpenGL4;

namespace Engine.Graphics
{
	public class Render
	{
		private int _VertexBufferObject;
		private int _VertexArrayObject;
		// Vértices del triángulo
		float[] vertices = 
		{
			-1.0f, -1.0f, 0.0f, //Vértice (vertex) inferior izquierda
			 1.0f, -1.0f, 0.0f, //Vértice (vertex) inferior derecha
			 0.0f,  1.0f, 0.0f  //Vértice (vertex) superior
		};
	
		public void Init()
		{
			// VAO
			// 	
			_VertexArrayObject = GL.GenVertexArray();
			GL.BindVertexArray(_VertexArrayObject);
		
			// VBO
			// 	Es un array dinámico, guarda los buffers de Open GL
			_VertexBufferObject = GL.GenBuffer();
			GL.BindBuffer(BufferTarget.ArrayBuffer, _VertexBufferObject); // Lo bindeo

			// Copio los datos del buffer de las vérticas previamente definidas
			//
			// GL.BufferData es una funcion diseñada para copiar datos definidos por el usuario
			// hacia el buffer actualmente emparejado
			// El primer argumento es el vbo actualmente emparejado al BufferTarget.ArrayBuffer al que apunta.
			// El segundo especifica el tamaño de los datos en bytes
			// El tercer parametro son los datos que queremos enviar
			// El cuarto parámetro es un BufferUsageHint que especifica como queremos que la GPU procese los datos enviados...
			// ... esto puede tener tres formas:
			//		> StaticDraw: los datos no son propensos a cambiar o lo harán cada tanto
			//      > DynamicDraw: los datos que son propensos a cambiar
			//		> StreamDraw: Los datos cambiarán cada vez que son dibujados
			//

			GL.BufferData(BufferTarget.ArrayBuffer, vertices.Length * sizeof(float), vertices, BufferUsageHint.StaticDraw);
			
			GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), 0);
			GL.EnableVertexAttribArray(0);
		}
		
		public void Draw(Shader shader)
		{
			shader.Use();
			GL.BindVertexArray(_VertexArrayObject);
			GL.DrawArrays(PrimitiveType.Triangles, 0, 3);	
		}
		
		public void UpdateVertices(float[] newVertices)
		{
			// Actualizo el array en C#
			vertices = newVertices;

			// Vuelvo a subir los datos al VBO
			GL.BindBuffer(BufferTarget.ArrayBuffer, _VertexBufferObject);
			GL.BufferData(BufferTarget.ArrayBuffer, vertices.Length * sizeof(float), vertices, BufferUsageHint.DynamicDraw);
		}

	}
}
