using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SuperCastService
{
    class SuperCastWS
    {
        public SuperCastWS()
        {

            //WebSocketContext wsCon = new WebSocketContext();
            

            Console.WriteLine("Starting HTTP Listener...");
            HttpListener listener = new HttpListener();
            listener.Prefixes.Add("http://*:8876/");
            listener.Start();

            Top:
            Console.WriteLine("Waiting for HTTP Connection...");
            HttpListenerContext context = listener.GetContext();
            
            Task<HttpListenerWebSocketContext> wsConAsync = context.AcceptWebSocketAsync(null);
            try
            {
                wsConAsync.Wait();
                HttpListenerWebSocketContext wsCon = wsConAsync.Result;
                WebSocket ws = wsCon.WebSocket;
                ArraySegment<byte> bytes = new ArraySegment<byte>(Encoding.Default.GetBytes(""));
                ws.SendAsync(bytes, WebSocketMessageType.Text, true, new CancellationToken()).Wait();
                Console.WriteLine("HELLO");
            }
            catch(Exception e)
            {
                StreamWriter writer = new StreamWriter(context.Response.OutputStream);
                writer.WriteLine(e);
                writer.Close();
                context.Response.Close();
            }
            goto Top;
        }
    }
}
