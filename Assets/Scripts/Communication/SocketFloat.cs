using UnityEngine;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System;

public class SocketFloat : MonoBehaviour
{
    public string ip = "192.168.0.4";
    public int port = 4444;
    private Socket client;
    [SerializeField]
    private int[] dataOut, dataIn; //debugging

    private void Update()
    {
        ServerRequest(new int[] { 2 });
    }

    protected int[] ServerRequest(int[] dataOut)
    {
        this.dataOut = dataOut; //debugging
        this.dataIn = SendAndReceive(dataOut); //debugging
        return this.dataIn;
    }

    private int[] SendAndReceive(int[] dataOut)
    {
        //initialize socket
        client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        client.Connect(ip, port);
        if (!client.Connected)
        {
            Debug.LogError("Connection Failed");
            return null;
        }

        //convert floats to bytes, send to port
        var byteArray = new byte[dataOut.Length];
        Buffer.BlockCopy(dataOut, 0, byteArray, 0, byteArray.Length);
        client.Send(byteArray);

        //allocate and receive bytes
        byte[] bytes = new byte[4000];
        int n = client.Receive(bytes);
        Debug.Log(Encoding.UTF8.GetString(bytes, 0, n));

        client.Close();
        //return floatsReceived;
        return new int[] { };
    }
}