using Servidor.presentacion;
using System;
using System.Windows.Forms;

namespace Servidor
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
