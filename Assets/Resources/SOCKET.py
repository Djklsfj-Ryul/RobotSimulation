import socket
import time
import zmq

host = "127.0.0.1"
port = 25001
sock = socket.socket(socket.AF_INET, socket.SOCK_STREAM)

while True:
    try:
        sock.connect((host, port))
        break
    except:
        pass

startPos = [-2, 3, 5]
while True:
    time.sleep(0.5)
    startPos[0] += 0.1
    posString = ','.join(map(str, startPos))
    print(posString)

    sock.sendall(posString.encode("UTF-8"))
    receivedData = sock.recv(1024).decode("UTF-8")
    print(receivedData)
