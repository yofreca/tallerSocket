using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Cliente.Logica
{
    public class Sistema
    {
        private static int puerto;
        string host;
        public bool conectado { get; set; }
        string sEncabezadoConexion;
        Socket mSocket;


        public Sistema(string shost)
        {
            puerto = 9050;
            mSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            host = shost;
            conectado = false;
        }

        public bool conectar(ref string sLog)
        {
            try
            {
                mSocket.Connect(host, puerto);
                conectado = true;
                return conectado;
            }
            catch (Exception ex)
            {
                sLog = ex.Message;
                return false;
            }
        }



        public bool solicitudConexion(string sMensaje, ref string sLog)
        {
            byte[] msg;
            byte[] result = new byte[1024];
            string respuesta;
            int bytesRes;

            try
            {
                if (mSocket.Connected)
                {
                    msg = Encoding.ASCII.GetBytes(sMensaje);
                    mSocket.Send(msg);
                    bytesRes = mSocket.Receive(result);
                    respuesta = Encoding.ASCII.GetString(result, 0, bytesRes);
                    sLog = "Respuesta: " + respuesta + Environment.NewLine;

                    if (respuesta == "00")
                    {
                        sLog += "Solicitud rechazada, ID repetido " + Environment.NewLine;
                        conectado = false;
                        mSocket.Close();
                    }


                }
                return true;
            }
            catch (SocketException err)
            {
                sLog = err.Message;
                return false;
            }
            catch (Exception ex)
            {
                sLog = ex.Message;
                return false;
            }
        }


        public void enviarMensaje(string sMensaje, ref string sLog)
        {
            byte[] msg;
            byte[] result = new byte[1024];
            string respuesta;
            int bytesRes;

            try
            {
                if (mSocket.Connected)
                {
                    msg = Encoding.ASCII.GetBytes(sMensaje);
                    mSocket.Send(msg);
                    bytesRes = mSocket.Receive(result);
                    respuesta = Encoding.ASCII.GetString(result, 0, bytesRes);
                    sLog = "Respuesta: " + respuesta + Environment.NewLine;
                }
            }
            catch (SocketException err)
            {
                sLog = err.Message;
                throw;
            }
            catch (Exception ex)
            {
                sLog = ex.Message;
                throw;
            }
        }



        public string getEncabezado()
        {
            sEncabezadoConexion = "SEM";
            sEncabezadoConexion += DateTime.Now.ToString("yyyyMMddhhmmss");
            return sEncabezadoConexion;
        }

    }
}
