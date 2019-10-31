using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Servidor.presentacion
{
    public class Controlador
    {
        private Vista ventana;
        private Modelo modelo;

        public Controlador(Vista aThis)
        {
            ventana = aThis;
            modelo = ventana.getModelo();
            ventana.getBtnIniciar().Click += new EventHandler(btn_Click);
           
        }


      


        private void btn_Click(object sender, System.EventArgs e)
        {
            modelo.inicioServidor();
            Application.DoEvents();

        }


    }
}
