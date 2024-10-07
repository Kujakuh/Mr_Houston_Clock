using System.Diagnostics;
using System.Runtime.Versioning;

namespace ClockApp
{
    public partial class Clock : Form
    {
        private Graphics graph;
        private float clockRad = 450;
        float originX;
        float originY;
        double xCoordOffset;
        double yCoordOffset;
        Hand secondsHand;
        Hand minhand;
        Hand hhand;

        public Clock()
        {
            InitializeComponent();
            graph = Canvas.CreateGraphics();

            originX = this.Width / 2;
            originY = this.Height / 2;

            secondsHand = new Hand(
                graph, 
                new Point((int)originX, (int)originY),
                300, 0.6
            );

            minhand = new Hand(
                graph,
                new Point((int)originX, (int)originY),
                150, 0.1
            );

            hhand = new Hand(
                graph,
                new Point((int)originX, (int)originY),
                50, 0.0017
            );

        }

        // Render Loop
        private void RenderTim_Tick(object sender, EventArgs e)
        {
            Pen pen = new Pen(Color.Black);
            graph.Clear(DefaultBackColor);

            originX = this.Width / 2;
            originY = this.Height / 2;

            double offsetY = this.Height * 0.03;

            drawCircle(originX, originY, clockRad, pen, offsetY);

            secondsHand.render(pen, this.Width, this.Height);
            minhand.render(pen, this.Width, this.Height);
            hhand.render(pen, this.Width, this.Height);

        }

        // Extra Utils

        private void drawCircle(float centerX, float centerY, float radius, Pen? pen, double offsetY =  0, double offsetX = 0)
        {
            pen ??= new Pen(Color.Black);

            float circleDimX = (radius * 2) * (float)(this.Height * 0.001);
            float circleDimY = (radius * 2) * (float)(this.Height * 0.001);

            Rectangle rect = 
            new (
                (int)(centerX - (circleDimX / 2) - offsetX), (int)(centerY - (circleDimY / 2) - offsetY),
                (int) circleDimX, (int) circleDimY
            );

            graph.DrawEllipse(pen, rect);
        }
    }
}
