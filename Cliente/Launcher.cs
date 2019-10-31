using Cliente.presentacion;
using System;
using System.Windows.Forms;

namespace Cliente
{
    class Launcher
    {

        private Modelo miApp;

        public Launcher()
        {
            miApp = new Modelo();
            miApp.iniciar();

        }


        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            new Launcher();

        }
    }
}
