import socket
import threading
import struct

server_socket = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
server_socket.setsockopt(socket.SOL_SOCKET, socket.SO_REUSEADDR, 1)
socket.setdefaulttimeout(None)
print('socket created ')

port = 4444
server_socket.bind(('192.168.0.13', port)) #local host
server_socket.listen() #listening for connection for 30 sec?
print('socket listensing ... ')

clients = []
nicknames = []

def handle(client):
    try:
        while True:
            message = client.recv(1024)
            if len(message) == struct.calcsize('2i2i?'):
                unpacked_data = struct.unpack('2i2L?', message)
                if (unpacked_data[4] == True):
                    print('Comm_disconnect')
                    break
                print(f'Encoder1 : {unpacked_data[0]}, Encoder : {unpacked_data[1]}')
                print(f'sec(s) : {unpacked_data[2]}.{unpacked_data[3]}')
                joint = (unpacked_data[0] + "," + unpacked_data[1]).encode('utf-8')

                if(message == b'2'):
                    client.send(joint)
            else:
                if(message == b'2'):
                    client.send(b'3230,5049')
    except:
        print("client exit")
        clients.remove(client)

while True:
    client, address = server_socket.accept()
    client.send('NICKNAME'.encode('ascii'))
    nickname = client.recv(1024).decode('ascii')
    nicknames.append(nickname)
    clients.append(client)

    thread = threading.Thread(target=handle, args=(client,))
    thread.start()