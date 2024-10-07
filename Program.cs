using System.Diagnostics;

namespace ClockApp {
    internal static class Program {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration

            DateTime now = DateTime.Now;
            Debug.WriteLine(now.ToString());
            int hour = now.Hour;


            if (hour >= 12) hour -= 12;

            ApplicationConfiguration.Initialize();
            Application.Run( new Clock(hour, now.Minute, now.Second) );
        }
    }
}