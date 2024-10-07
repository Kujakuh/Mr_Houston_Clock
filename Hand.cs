using System.Diagnostics;
using System.Runtime.Versioning;

namespace ClockApp
{
    public class Hand
    {
        private Graphics graph;
        private double lastAngle;
        private Point virtualCoord;

        public Point origin;
        public float lenght;
        public double step;

        public Hand(Graphics graph, Point origin, float lenght, double stepDegrees, double startingAngle = 0) { 
        
            this.graph  = graph;
            this.origin = origin;
            this.lenght = lenght;
            this.step   = stepDegrees;

            this.lastAngle = startingAngle;
        }
        public void render(Pen pen, double canvasWidth, double canvasHeight)
        {
            if (lastAngle >= 360) lastAngle = 0;

            lastAngle += step;

            // We wanna go clock wise, so we have to swap cos and sin
            // cos is y axis proyection
            // sin is x axis proyection

            Point realCoord = new Point(
                (int) ((Math.Sin(degToRad(lastAngle)) * lenght)),
                (int) ((Math.Cos(degToRad(lastAngle)) * lenght))
            );

            if(0 <= lastAngle && lastAngle < 90) {
                virtualCoord.Y = (int) ( -1 * realCoord.Y + canvasHeight / 2);
                virtualCoord.X = (int) ( 1 * realCoord.X + canvasWidth / 2);
            }
            else if (90 <= lastAngle && lastAngle < 180)
            {
                virtualCoord.Y = (int)( -1 * realCoord.Y + canvasHeight / 2);
                virtualCoord.X = (int)( 1 * realCoord.X + canvasWidth / 2);
            }
            else if (180 <= lastAngle && lastAngle < 270)
            {
                virtualCoord.Y = (int)( -1 * realCoord.Y + canvasHeight / 2);
                virtualCoord.X = (int)( 1 * realCoord.X + canvasWidth / 2);
            }
            else
            {
                virtualCoord.Y = (int)( -1 * realCoord.Y + canvasHeight / 2);
                virtualCoord.X = (int)( 1 * realCoord.X + canvasWidth / 2);
            }

            virtualCoord.Y -= (int) (canvasHeight * 0.03);

            graph.DrawLine(pen, origin, virtualCoord);
        }

        public double degToRad(double degrees) { return (Math.PI * degrees) / 180; }

        
    }
} 