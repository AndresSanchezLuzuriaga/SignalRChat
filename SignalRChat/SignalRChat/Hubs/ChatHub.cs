using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace SignalRChat.Hubs
{
    public class ChatHub : Hub
    {
        //-----PARTE 1: ENVIAR MENSAJES A CLIENTES-----/
        public void Enviar(string nombre, string mensaje)
        {
            //Llamar al metodo addNuevoMensajeEnPagina para actualizar los clientes.
            Clients.All.addNuevoMensajeEnPagina(nombre, mensaje);
        }
        //-----FIN PARTE 1-----/

        //-----PARTE 2 (opcional): CONTAR LOS CLIENTES CONECTADOS-----/
        public static int contador = 0;

        public override Task OnConnected()
        {
            contador++;
            //Llamar al metodo mostrarConectados para actualizar los clientes.
            Clients.All.mostrarConectados(contador);
            return base.OnConnected();
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            contador--;
            //Llamar al metodo mostrarConectados para actualizar los clientes.
            Clients.All.mostrarConectados(contador);
            return base.OnDisconnected(stopCalled);
        }
        //-----FIN PARTE 2-----/
    }
}