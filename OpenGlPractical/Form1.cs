using System;
using System.Windows.Forms;
using OpenTK.Graphics.OpenGL;

namespace OpenGlPractical
{
    public partial class Form1 : Form
    {


        public Form1()
        {
            InitializeComponent();
        }

        //Initilizing ControlWindow for GL on launch
        private void ControlWindow_Paint(object sender, PaintEventArgs e)
        {
            GL.Viewport(0, 0, ControlWindow.Width, ControlWindow.Height);
            GL.ClearColor(1f, 1f, 1f, 1);
            GL.Clear(ClearBufferMask.ColorBufferBit);
            ControlWindow.SwapBuffers();
        }

        //Drawing X axis with ticks
        private void DrawXAxis()
        {
            GL.LineWidth(1);
            GL.Color3(1, 1, 1);
            GL.Begin(PrimitiveType.Lines);
            GL.Vertex2(0f, 1f);
            GL.Vertex2(0f, -1f);
            for (float i = -1f; i < 1f; i += 0.2f)
            {
                GL.Vertex2(i, 0.02f);
                GL.Vertex2(i, -0.02f);
            }
            GL.End();
        }

        //Drawing Y axis with ticks
        private void DrawYAxis()
        {
            GL.LineWidth(1);
            GL.Color3(1, 1, 1);
            GL.Begin(PrimitiveType.Lines);
            GL.Vertex2(-1f, 0f);
            GL.Vertex2(1f, 0f);
            for (float i = -1f; i < 1f; i += 0.2f)
            {
                GL.Vertex2(0.02f, i);
                GL.Vertex2(-0.02f, i);
            }
            GL.End();
        }

        //Draws a connected group of line segments.
        private void DrawFigureLines()
        {
            GL.LineWidth(3);
            GL.Color3(1, 1, 1);
            GL.Begin(PrimitiveType.LineLoop);
            for (int i = 0; i < 6; i++)
            {
                GL.Vertex2(figure[i, 0], figure[i, 1]);
            }
            GL.End();
        }

        //Draws a single, convex polygon.
        private void DrawFigurePolygon()
        {
            Random rand = new Random();
            GL.Begin(PrimitiveType.Polygon);
            for (int i = 0; i < 6; i++)
            {
                GL.Color3(rand.NextDouble(), rand.NextDouble(), rand.NextDouble());
                GL.Vertex2(figure[i, 0], figure[i, 1]);
            }
            GL.End();
        }

        //Method called when clicking on Lines in menu strip
        private void LineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GL.Viewport(0, 0, ControlWindow.Width, ControlWindow.Height);
            GL.ClearColor(1f, 1f, 1f, 1);
            GL.Clear(ClearBufferMask.ColorBufferBit);
            DrawXAxis();
            DrawYAxis();
            DrawFigureLines();
            ControlWindow.SwapBuffers();
        }

        //Method called when clicking on Polyglon in menu strip
        private void PolygonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GL.Viewport(0, 0, ControlWindow.Width, ControlWindow.Height);
            GL.ClearColor(1f, 1f, 1f, 1);
            GL.Clear(ClearBufferMask.ColorBufferBit);
            DrawXAxis();
            DrawYAxis();
            DrawFigurePolygon();
            ControlWindow.SwapBuffers();
        }

        //Method called when clicking on Exit in menu strip
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
