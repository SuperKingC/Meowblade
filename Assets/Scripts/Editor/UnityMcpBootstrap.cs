using System;
using System.Threading.Tasks;
using MCPForUnity.Editor.Clients.Configurators;
using MCPForUnity.Editor.Services;
using MCPForUnity.Editor.Services.Transport;
using UnityEditor;
using UnityEngine;

namespace Meowblade.Editor
{
    /// <summary>
    /// Keeps the project-local UnityMCP bridge ready for Codex without requiring
    /// manual editor-window setup after package imports or domain reloads.
    /// </summary>
    [InitializeOnLoad]
    internal static class UnityMcpBootstrap
    {
        private const string SessionGuard = "Meowblade.UnityMcpBootstrap.Configured";
        private const string Endpoint = "http://127.0.0.1:8080";

        static UnityMcpBootstrap()
        {
            EditorPrefs.SetBool("MCPForUnity.UseHttpTransport", true);
            EditorPrefs.SetString("MCPForUnity.HttpTransportScope", "local");
            EditorPrefs.SetString("MCPForUnity.HttpUrl", Endpoint);
            EditorPrefs.SetBool("MCPForUnity.AutoStartOnLoad", true);
            EditorPrefs.SetBool("MCPForUnity.HttpServerLaunchConfirmed", true);
            EditorPrefs.SetBool("MCPForUnity.SetupCompleted", true);

            if (SessionState.GetBool(SessionGuard, false))
            {
                return;
            }

            SessionState.SetBool(SessionGuard, true);
            EditorApplication.delayCall += ConfigureAndConnect;
        }

        private static async void ConfigureAndConnect()
        {
            try
            {
                CodexConfigurator configurator = new CodexConfigurator();
                configurator.Configure();

                if (!MCPServiceLocator.Server.IsLocalHttpServerReachable())
                {
                    bool launched = MCPServiceLocator.Server.StartLocalHttpServer(quiet: true);
                    if (!launched)
                    {
                        Debug.LogWarning("[Meowblade UnityMCP] Local server launch failed. Open Window > MCP for Unity for details.");
                        return;
                    }
                }

                bool serverReady = await WaitForServerAsync();
                if (!serverReady)
                {
                    Debug.LogWarning("[Meowblade UnityMCP] Local server did not become reachable within 60 seconds.");
                    return;
                }

                bool connected = MCPServiceLocator.TransportManager.IsRunning(TransportMode.Http)
                    || await MCPServiceLocator.TransportManager.StartAsync(TransportMode.Http);
                bool verified = connected
                    && await MCPServiceLocator.TransportManager.VerifyAsync(TransportMode.Http);

                if (verified)
                {
                    Debug.Log("[Meowblade UnityMCP] Connected and verified at " + Endpoint + "/mcp");
                }
                else
                {
                    Debug.LogWarning("[Meowblade UnityMCP] Server is reachable, but the Unity bridge verification failed.");
                }
            }
            catch (Exception exception)
            {
                Debug.LogException(exception);
            }
        }

        private static async Task<bool> WaitForServerAsync()
        {
            const int attempts = 120;
            for (int i = 0; i < attempts; i++)
            {
                if (MCPServiceLocator.Server.IsLocalHttpServerReachable())
                {
                    return true;
                }

                await Task.Delay(500);
            }

            return false;
        }
    }
}
