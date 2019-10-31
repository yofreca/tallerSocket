using Servidor.Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Servidor
{
    public class SistemaServer
    {
        private static int puerto;
        List<Cliente> lstCliente;
        List<string> lstIDs;
        Socket svrSocket;


        public SistemaServer()
        {
            puerto = 9050;
            svrSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            lstCliente = new List<Cliente>();
            lstIDs = new List<string>();
        }

        public bool iniciar(ref string sLog)
        {
            IPHostEntry host = Dns.GetHostEntry("localhost");
            IPAddress ipAddress = host.AddressList[1];
            IPEndPoint local = new IPEndPoint(ipAddress, puerto);

            try
            {
                svrSocket.Bind(local);

                svrSocket.Listen(10);

                sLog += "Servidor ejecutandose en el puerto: " + puerto.ToString() + Environment.NewLine;
                return true;
            }
            catch (Exception ex)
            {
                sLog +=  ex.Message + Environment.NewLine;
                return false;
            }

        }


        public int clientesConectados()
        {
            return lstCliente.Count(c=> c.activo == true);
        }


        public List<Cliente> GetClientes()
        {
            return lstCliente;
        }


        public void esperaConexion(ref string sLog)
        {
            Cliente cliente; 
            string data = string.Empty;
            //byte[] bytes = null;
            Socket sCliente = svrSocket.Accept();

            sLog = "Solicitud Recibida " + sCliente.RemoteEndPoint + Environment.NewLine;


            lstIDs = lstCliente.Select(c=> c.id).ToList();

            cliente = new Cliente(sCliente, lstIDs);


            lstCliente.Add(cliente);

            //bytes = new byte[1024];

            //int bytesRec = cliente.Receive(bytes);
            //data += Encoding.ASCII.GetString(bytes, 0, bytesRec);

            //sLog = "Mesaje recibido";

            //cliente.Close();

        }




    }
}
