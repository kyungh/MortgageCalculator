using System;
using System.Windows.Forms;

namespace MortgageCalculator
{
    static class Program
    {
        // <summary>
        // The main entry point for the application.
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new Form1());

            /* 
             * Please see Form1.cs for all requirements in projects.
             * All requirements for the project are commented with: **RequirementName** 
             * The presentation file can be found with the submitted items
             * Comments have been written throughout the program as well
             */
        }
    }
}
