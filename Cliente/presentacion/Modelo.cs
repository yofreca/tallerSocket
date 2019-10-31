using Cliente.Logica;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Cliente.presentacion
{
    public class Modelo
    {
        private Esquema esquema;
        private Vista ventana;
        private int R, A, V;
        private List<Opcion> lst;
        Sistema sys;
        private string combinacion;
        private string sLog;

        public Modelo()
        {
            esquema = new Esquema(Application.StartupPath);
            lst = esquema.getEsquema();
            R = A =  V = 0;
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
            getVentana().Size = new System.Drawing.Size(535, 530);
            getVentana().Visible = true;
            Application.Run(getVentana());
       
        }


        public void encenderLuz(string sOpcion)
        {
            
            R = A = V = 0;

            if (sOpcion == "ckbApagado")
            {
                Apagar();
                ventana.getImgSemaforo().Image = Image.FromFile(Application.StartupPath + @"\img\apagado.png");
                getVentana().getTimer().Stop();
            }
            else
            {
                switch (sOpcion)
                {
                    case "ckbAmarillo":
                        ventana.getCkbAmarilloIntermitente().Checked = false;
                        break;
                    case "ckbRojo":
                        ventana.getCkbRojoIntermitente().Checked = false;
                        break;
                    case "ckbVerde":
                        ventana.getCkbVerdeIntermitente().Checked = false;
                        break;
                    case "ckbRojoIntermitente":
                        ventana.getCkbRojo().Checked = false;
                        break;
                    case "ckbAmarilloIntermitente":
                        ventana.getCkbAmarillo().Checked = false;
                        break;
                    case "ckbVerdeIntermitente":
                        ventana.getCkbVerde().Checked = false;
                        break;
                }

                SetSemaforo();
                actualizaEstadoServer();

                if (combinacion.IndexOf("2") > -1)
                    getVentana().getTimer().Start();
                else
                    getVentana().getTimer().Stop();
            }
        }


        public void Apagar()
        {
            var lstCheck = getVentana().Controls;

            foreach (CheckBox item in lstCheck.OfType<CheckBox>())
            {
                if (item.Name != "ckbApagado")
                    item.Checked = false;
            }
        }


        public void timer()
        {

            SetSemaforo();
            getVentana().blnEncendido  = !getVentana().blnEncendido;

        }


        private void SetSemaforo()
        {
            string img;
            combinacion = GetCombinacion();

            img = lst.FirstOrDefault(x => x.codigo.TrimEnd() == combinacion).imagen;

            getVentana().getImgSemaforo().Image = Image.FromFile(Application.StartupPath + @"\img\" + img);


        }



        public string GetCombinacion()
        {
            string sEstado; 
            var lstCheck = getVentana().Controls;

            foreach (CheckBox item in lstCheck.OfType<CheckBox>())
            {
                if (item.Name != "ckbApagado")
                {
                    switch (item.Name)
                    {
                        case "ckbRojo":
                            R = ventana.getCkbRojo().Checked ? 1 : R;
                            break;
                        case "ckbAmarillo":
                            A = ventana.getCkbAmarillo().Checked ? 1: A;
                            break;
                        case "ckbVerde":
                            V = ventana.getCkbVerde().Checked ? 1: V;
                            break;
                        case "ckbRojoIntermitente":
                            R = ventana.getCkbRojoIntermitente().Checked ? 2 : R;
                            break;
                        case "ckbAmarilloIntermitente":
                            A = ventana.getCkbAmarilloIntermitente().Checked ? 2 : A;
                            break;
                        case "ckbVerdeIntermitente":
                            V = ventana.getCkbVerdeIntermitente().Checked ? 2 : V;
                            break;
                    }
                }
            }
            sEstado = R.ToString() + A.ToString() + V.ToString();

            if (getVentana().blnEncendido)
                sEstado += "1";
            else
                sEstado += "0"; 

            return sEstado;

        }



        public void actualizaTitulo(string sTitulo)
        {
            getVentana().Text = sTitulo;
        }


        #region "Socket"


        public void conectar()
        {
            bool blnExito;
         

            if (validaDatosConexion())
            {
                sys = new Sistema(getVentana().getTxtServidor().Text);

                blnExito = sys.conectar(ref sLog);


                if (blnExito)
                    SolicitudConexion();
                else
                   getVentana().getTxtLog().Text += sLog + Environment.NewLine;

                Application.DoEvents();

                //enviarMensaje();

            }

        }


        private void SolicitudConexion()
        {
            int ID;
            string msg = sys.getEncabezado();
            ID =  int.Parse(getVentana().getTxtID().Text);

            msg += "CON" + ID.ToString("D4") + getVentana().getTxtNombre().Text.PadLeft(12,'-');

            getVentana().getTxtLog().Text += "Mensaje: " + msg + Environment.NewLine;

            if (sys.solicitudConexion(msg, ref sLog))
                getVentana().getTxtLog().Text += "Conectado con " + getVentana().getTxtServidor().Text + Environment.NewLine + sLog;
            else
                getVentana().getTxtLog().Text += "Solicitud rechazada" + getVentana().getTxtServidor().Text + Environment.NewLine + sLog;


        }


        public void enviarMensaje()
        {
            string msg;
            msg = getVentana().getTxtNombre().Text;
            sys.enviarMensaje(msg,ref sLog);

            getVentana().getTxtLog().Text += "Mesaje Enviado " + msg + Environment.NewLine + sLog + Environment.NewLine;
        }


        private bool validaDatosConexion()
        {
            bool validar = true;
            var lstTxt = getVentana().GetGroupBox().Controls;

            foreach (TextBox item in lstTxt.OfType<TextBox>())
            {

                if (item.Text == string.Empty)
                {
                    getVentana().GetErrorProvider().SetError(item, "Debe ingresar esta información");
                    validar = false;
                }
                else
                    getVentana().GetErrorProvider().SetError(item, string.Empty);
            }

            return validar;
        }



        private void actualizaEstadoServer()
        {
            string msg; 
            if (sys != null && sys.conectado)
            {
                msg = sys.getEncabezado();
                msg += "CES" + R.ToString() + A.ToString() + V.ToString();

                sys.enviarMensaje(msg, ref sLog);

                getVentana().getTxtLog().Text += "Mesaje Enviado " + msg + Environment.NewLine + sLog + Environment.NewLine;
            }

        }



        #endregion






    }
}
