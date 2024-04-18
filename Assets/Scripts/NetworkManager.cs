using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.Net.Sockets;
using System.Text;

public class NetworkManager : MonoBehaviour
{
    string serverIP = "192.168.10.241";
    int port = 9999;

    private Socket udpSocket;
    private IPEndPoint remoteEndPoint;

    bool isSending = false;

    void Start()
    {
        udpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
        remoteEndPoint = new IPEndPoint(IPAddress.Parse(serverIP), port);
    }

    public void StartSendingVideo()
    {
        byte[] data = Encoding.UTF8.GetBytes("Hello from Unity");
        udpSocket.SendTo(data, remoteEndPoint);
    }

    public void QuitSendingVideo()
    {

    }

    private void OnApplicationQuit()
    {
        udpSocket.Close();
    }
}
