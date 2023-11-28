using UnityEngine;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System;
using UnityEngine.SceneManagement;
using System.Threading;

public class SocketFloat : MonoBehaviour
{
    public string ip = "192.168.0.13";
    public int port = 4444;
    public Socket client;
    [SerializeField]
    private byte[] dataOut; //debugging

    public int[] masterDeviceJointData = new int[] { 0, 0 };

    public void Receive()
    {
        //initialize socket
        client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        client.Connect(ip, port);

        dataOut = Encoding.UTF8.GetBytes("hello");
        client.Send(dataOut);
        byte[] bytes = new byte[1024];
        //client.ReceiveTimeout = 100;
        int n = client.Receive(bytes);
        Debug.Log(Encoding.UTF8.GetString(bytes, 0, n));

        Debug.Log("연결 완료");
    }

    public void CatchData()
    {
        dataOut = Encoding.UTF8.GetBytes("2");
        //convert floats to bytes, send to port
        var byteArray = new byte[dataOut.Length];
        Buffer.BlockCopy(dataOut, 0, byteArray, 0, byteArray.Length);
        client.Send(dataOut);

        byte[] bytes = new byte[1024];
        //client.ReceiveTimeout = 100;
        int n = client.Receive(bytes);

        string[] T = Encoding.UTF8.GetString(bytes, 0, n).Split(',');

        masterDeviceJointData[0] = int.Parse(T[0]);
        masterDeviceJointData[1] = int.Parse(T[1]);
    }

    private void Update()
    {
        if (client != null)
            CatchData();
    }
}