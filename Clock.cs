using System.Diagnostics;
using System.Runtime.Versioning;

namespace ClockApp
{
    public partial class Clock : Form
    {
        private double stepPerMilisecond = 0.006;

        private Graphics graph;

        private float clockRad = 450;

        float originX;
        float originY;

        Hand secondsHand;
        Hand minsHand;
        Hand hoursHand;

        public Clock(int hour, int minute, int second)
        {
            InitializeComponent();
            graph = Canvas.CreateGraphics();

            originX = this.Width / 2;
            originY = this.Height / 2;

            double secStep = (stepPerMilisecond * timeToRender);
            double secAng = second * 6;
            secondsHand = new Hand(
                graph, 
                new Point((int)originX, (int)originY),
                300, secStep,
                secAng
            );

            double minStep = (stepPerMilisecond * timeToRender) / 60;
            double minAng = minute * 6 + second * minStep ;
            minsHand = new Hand(
                graph,
                new Point((int)originX, (int)originY),
                150, minStep,
                minAng
            );

            double hourStep = (stepPerMilisecond * timeToRender) / 360;
            double hourAng = ((hour * 5) * 6) + (minute * 60 * hourStep) + (second * hourStep);
            hoursHand = new Hand(
                graph,
                new Point((int)originX, (int)originY),
                80, hourStep,
                hourAng
            );

        }

        // Render Loop
        private void RenderTim_Tick(object sender, EventArgs e)
        {
            Pen pen = new Pen(Color.Black, 3);
            graph.Clear(DefaultBackColor);

            originX = this.Width / 2;
            originY = this.Height / 2;

            double offsetY = this.Height * 0.03;

            drawCircle(originX, originY, clockRad, pen, offsetY);

            secondsHand.updateOrigin((int) originX, (int) (originY - offsetY));
            minsHand.updateOrigin((int)originX, (int)(originY - offsetY));
            hoursHand.updateOrigin((int)originX, (int)(originY - offsetY));

            secondsHand.render(pen, this.Width, this.Height);
            minsHand.render(pen, this.Width, this.Height);
            hoursHand.render(pen, this.Width, this.Height);

        }

        // Extra Utils

        private void drawCircle(float centerX, float centerY, float radius, Pen? pen, double offsetY = 0, double offsetX = 0)
        {
            pen ??= new Pen(Color.Black);

            float circleDimX = (radius * 2) * (float)(this.Height * 0.001);
            float circleDimY = (radius * 2) * (float)(this.Height * 0.001);

            Rectangle rect =
            new(
                (int)(centerX - (circleDimX / 2) - offsetX), (int)(centerY - (circleDimY / 2) - offsetY),
                (int)circleDimX, (int)circleDimY
            );

            graph.DrawEllipse(pen, rect);
        }
    }
}
