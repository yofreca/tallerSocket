using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Servidor.Logica
{
    public class Cliente
    {
        static int OK = 10;
        Socket skcliente;
        private Thread hiloEscucha;
        public string id { get; set; }
        public string nombre { get; set; }
        public string estado { get; set; }
        public bool activo { get; set; }
        List<string> lstRegistrados;
        string puntoRemoto;
        string amarillo;
        string verde;
        string rojo;
        bool enEspera;
        

        public delegate void RecibeMensaje();

        public Cliente(Socket sck, List<String> lst)
        {
            skcliente = sck;
            puntoRemoto = skcliente.RemoteEndPoint.ToString();
            hiloEscucha = new Thread(new ThreadStart(Run));
            enEspera = true;
            activo = true;
            lstRegistrados = lst;
            hiloEscucha.Start();
        }


        public void recibeMensaje()
        {
            int result;
            string rpt;
            byte[] bRpt;
            string msg;
            byte[] bytes = null;
            bytes = new byte[1024];

            int bytesRec = skcliente.Receive(bytes);
            msg = Encoding.ASCII.GetString(bytes, 0, bytesRec);

            result = ValidaComando(msg);

            if (result == OK)
                rpt = "Ok";
            else 
                rpt = result.ToString("D2");

            bRpt = Encoding.ASCII.GetBytes(rpt);
            skcliente.Send(bRpt);

            if (rpt == "00")
            {
                skcliente.Close();
                activo = false;
            }

        }


        private int ValidaComando(string msg)
        {
            string encabezado;
            string comando;
            int result = OK;

            try
            {
                if (msg.Length > 17)
                {
                    encabezado = msg.Substring(0,17);
                    comando = msg.Substring(17, 3);

                    if (comando == "CON")
                    {
                        if (msg.Substring(20).Length == 16)
                        {
                           result = asignaValores(msg.Substring(20));
                        }
                        else
                            result = (int)Error.LongitudNoValida;
                    }
                    else if (comando == "CES")
                    {
                        if (msg.Substring(20).Length == 3)
                        {
                            actualizaEstado(msg.Substring(20));
                        }
                        else
                            result = (int)Error.LongitudNoValida;
                    }
                    else
                        result = (int)Error.ComandoNovalido;

                }
                else
                    result = (int)Error.LongitudNoValida;
            }
            catch (Exception)
            {
                result = (int)Error.CadenaErrada;
            }
            return result;
        }


        private int asignaValores(string info)
        {
            id = info.Substring(0, 4);
            nombre = info.Substring(4).Replace("-","");

            if (lstRegistrados.Count(r => r.Contains(id)) != 0)
                return (int)Error.IdRepetido;
            else
                return OK;
        }

        private void actualizaEstado(string info)
        {
            rojo = info.Substring(0, 1);
            amarillo = info.Substring(1, 1);
            verde = info.Substring(2);

            estado = "Rojo: " + getEstado(rojo) + ", Amarillo: " + getEstado(amarillo) + ", Verde: " + getEstado(verde);
        }


        private string getEstado(string std)
        {
            string rpt = string.Empty;

            switch (std)
            {
                case "0":
                    rpt = "Apagado";
                    break;
                case "1":
                    rpt = "Encendido";
                    break;
                case "2":
                    rpt = "Intermitente";
                    break;
            }

            return rpt;
        }

        public enum Error
        {
            IdRepetido = 0,
            LongitudNoValida =1,
            CadenaErrada = 2,
            ComandoNovalido = 3,
                
        }



        public void Run()
        {
            while (enEspera)
            {
                try
                {
                    recibeMensaje();
                    Thread.Sleep(150);
                }
                catch (Exception)
                {
                }
            }
        }


    }
}
