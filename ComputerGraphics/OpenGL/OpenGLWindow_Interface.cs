﻿using ComputerGraphics.GraphObjects;
using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Text;



namespace ComputerGraphics
{
    internal partial class OpenGLWindow : GameWindow
    {
        Shader _shader;
        int VertexBufferObject;
        int VertexArrayObject;
        public OpenGLWindow(GameWindowSettings gameWindowSettings, NativeWindowSettings nativeWindowSettings) : base(gameWindowSettings, nativeWindowSettings)
        {
           
            LoadNavigationFunctions();
        }

        

        protected override void OnUnload()
        {
            //_shader.Dispose();
            //GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
            //GL.DeleteBuffer(VertexBufferObject);
            foreach(var obj in _graphObjects)
            {
                obj.OnUnload();
            }
            base.OnUnload();
        }

  
        protected override void OnLoad()
        {
            GL.ClearColor(0.2f, 0.3f, 0.3f, 1.0f);
            //Code goes here
            foreach (var obj in _graphObjects)
            {
                obj.OnLoad();
            }
           

            //_shader = new Shader("shader.vert", "shader.frag");
            //float[] vertices = {
            //                        -0.5f, -0.5f, 0.0f, //Bottom-left vertex
            //                         0.5f, -0.5f, 0.0f, //Bottom-right vertex
            //                         0.0f,  0.5f, 0.0f  //Top vertex
            //                    };
            //VertexBufferObject = GL.GenBuffer();
            //GL.BindBuffer(BufferTarget.ArrayBuffer, VertexBufferObject);
            //GL.BufferData(BufferTarget.ArrayBuffer, vertices.Length * sizeof(float), vertices, BufferUsageHint.StaticDraw);

            //GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), 0);
            //GL.EnableVertexAttribArray(0);
            ////_shader.Use();
            //VertexArrayObject = GL.GenVertexArray();
            //// ..:: Initialization code (done once (unless your object frequently changes)) :: ..
            //// 1. bind Vertex Array Object
            //GL.BindVertexArray(VertexArrayObject);
            //// 2. copy our vertices array in a buffer for OpenGL to use
            //GL.BindBuffer(BufferTarget.ArrayBuffer, VertexBufferObject);
            //GL.BufferData(BufferTarget.ArrayBuffer, vertices.Length * sizeof(float), vertices, BufferUsageHint.StaticDraw);
            //// 3. then set our vertex attributes pointers
            //GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), 0);
            //GL.EnableVertexAttribArray(0);

            base.OnLoad();

           
        }
        List<GraphObjects.GraphObject> _graphObjects = new List<ComputerGraphics.GraphObjects.GraphObject>();
        internal void AddGraph(GraphObject obj)
        {
            _graphObjects.Add(obj);
        }

        protected override void OnResize(ResizeEventArgs e)
        {

            GL.Viewport(0, 0, e.Width, e.Height);
            base.OnResize(e);



        }

        protected override void OnRenderFrame(FrameEventArgs args)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit);

            //Code goes here.
            foreach(var obj in _graphObjects)
            {
                obj.OnRenderFrame(args);
                
            }
            Context.SwapBuffers();
            //_shader.Use();
            //GL.BindVertexArray(VertexArrayObject);
            //GL.DrawArrays(PrimitiveType.Triangles, 0, 3);



            base.OnRenderFrame(args);
           

        }


    }
}
