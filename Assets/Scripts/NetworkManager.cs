using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.Net.Sockets;
using System.Text;

public class NetworkManager : MonoBehaviour
{
    private Socket udpSocket;
    private IPEndPoint remoteEndPoint;

    void Start()
    {
        udpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
        remoteEndPoint = new IPEndPoint(IPAddress.Parse("192.168.10.241"), 9999);

        StartCoroutine(SendData());
    }

    IEnumerator SendData()
    {
        while (true)
        {
            byte[] data = Encoding.UTF8.GetBytes("Hello from Unity");
            udpSocket.SendTo(data, remoteEndPoint);

            yield return new WaitForSeconds(1f);
        }
    }

    private void OnApplicationQuit()
    {
        udpSocket.Close();
    }
}
