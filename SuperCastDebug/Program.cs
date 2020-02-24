using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Net.WebSockets;
using System.IO;

namespace SuperCastDebug
{
    class Program
    {
        static void Main(string[] args)
        {
            ClientWebSocket ws = new ClientWebSocket();
            ws.ConnectAsync(new Uri("ws://127.0.0.1:8876/"), new CancellationToken()).Wait();

            ArraySegment<byte> bytes = new ArraySegment<byte>(new byte[50]);

            Task<WebSocketReceiveResult> asyncWsResult = ws.ReceiveAsync(bytes, new CancellationToken());

            asyncWsResult.Wait();
            WebSocketReceiveResult wsResult = asyncWsResult.Result;
            
            foreach(byte resByte in bytes)
            {
                Console.WriteLine(resByte.ToString());
            }
            Console.ReadLine();
        }
    }
}
