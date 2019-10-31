using Servidor.Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace Servidor.presentacion
{
    public class Modelo
    {

        private Vista ventana;
        private string sLog;
        private bool iniciado;
        SistemaServer sys;
        private Thread hiloEsperaCliente;
        private Thread hiloActualizaGrilla;


        public delegate void EsperaConexion();
        public delegate void Timer();

        public Modelo()
        {
            hiloEsperaCliente = new Thread(new ThreadStart(Run));
            hiloActualizaGrilla = new Thread(new ThreadStart(RunGrilla));
            iniciado = true;
        }

        public Vista getVentana()
        {
            if (ventana == null)
            {
                ventana = new Vista(this);
            }
            return ventana;
        }


        public void iniciar()
        {
            getVentana().Size = new System.Drawing.Size(900, 600);
            getVentana().Visible = true;
            Application.Run(getVentana());
        }


        public void inicioServidor()
        {
            sys = new SistemaServer();
            sys.iniciar(ref sLog);
            hiloEsperaCliente.Start();
            hiloActualizaGrilla.Start();
        }


        public void esperaConexion()
        {
             sys.esperaConexion(ref sLog);
            // getVentana().getTxtLog().Text += sLog;
             Thread.Sleep(150);
            
        }



        private void actualizaGrilla()
        {
            List<Cliente> clientes;
            List<InfoCliente> lst;

            clientes = sys.GetClientes();

            lst = clientes.Where(c=> c.activo == true).Select(c=> new InfoCliente { Nombre = c.nombre , ID = c.id, Estado = c.estado } ).ToList();

            getVentana().getGrilla().DataSource = lst;

            getVentana().getNoClientes().Text = sys.clientesConectados().ToString();
            getVentana().getTxtLog().Text += sLog;
            sLog = string.Empty;

        }


        public void timer()
        {
            actualizaGrilla(); 
        }



        public void Run()
        {
            while (iniciado)
            {

                try
                {
                    //  getVentana().Invoke(new EsperaConexion(esperaConexion));
                    esperaConexion();
                    Thread.Sleep(50);
                }
                catch (ThreadInterruptedException)
                {
                }
                catch (Exception)
                { }
            }

        }



        public void RunGrilla()
        {
            while (iniciado)
            {

                try
                {
                    getVentana().Invoke(new Timer(timer));
                    Thread.Sleep(350);
                }
                catch (ThreadInterruptedException)
                {
                }
                catch (Exception)
                { }
            }

        }



    }
}
