using System;
using System.Net;
using System.Text;
using System.Threading;
using PolyhydraGames.Valheim.Plugin.Models;
using UnityEngine;

namespace PolyhydraGames.Valheim.Plugin.WebServer
{
    public class HttpCommandServer : MonoBehaviour
    {
        private HttpListener _listener;
        private Thread _listenerThread;

        private void Start()
        {
            _listener = new HttpListener();
            _listener.Prefixes.Add("http://*:8080/"); // listen on port 8080
            _listener.Start();

            _listenerThread = new Thread(ListenLoop);
            _listenerThread.Start();

            Debug.Log("[MyMod] HTTP command server started on port 8080");
        }

        private void OnDestroy()
        {
            _listener.Stop();
            _listener.Close();
            _listenerThread.Abort();
        }

        private void ListenLoop()
        {
            while (_listener.IsListening)
            {
                try
                {
                    var ctx = _listener.GetContext();
                    string responseText = HandleRequest(ctx.Request);
                    byte[] buffer = Encoding.UTF8.GetBytes(responseText);

                    ctx.Response.ContentType = "application/json";
                    ctx.Response.OutputStream.Write(buffer, 0, buffer.Length);
                    ctx.Response.Close();
                }
                catch (Exception ex)
                {
                    Debug.LogError("[MyMod] HTTP listener error: " + ex);
                }
            }
        }


        private string HandleRequest(HttpListenerRequest request)
        {
            if (request.HttpMethod != "POST" || request.Url.AbsolutePath != "/command")
            {
                return "{\"status\":\"unknown command\"}";
            }

            using var reader = new System.IO.StreamReader(request.InputStream, request.ContentEncoding);
            string body = reader.ReadToEnd();
            var command = CommandRequest.Create(body);
            ActionManager.Instance.ProcessCommand(command);
            return "{\"status\":\"ok\"}";

        }
    }

}
