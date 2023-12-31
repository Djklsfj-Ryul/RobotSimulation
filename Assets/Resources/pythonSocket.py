import socket
import select
import struct

server_socket = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
server_socket.setsockopt(socket.SOL_SOCKET, socket.SO_REUSEADDR, 1)
socket.setdefaulttimeout(None)
print('socket created ')

port = 4444
server_socket.bind(('192.168.0.13', port)) #local host
server_socket.listen() #listening for connection for 30 sec?
print('socket listensing ... ')

readsocks = [server_socket]

latestData = b"123"
finishCommTrigger = True

data = ""

while finishCommTrigger:
    readables, writeables, excepctions = select.select(readsocks, [], [])
    for sock in readables:
        if sock == server_socket:
            newsock, addr = server_socket.accept()
            readsocks.append(newsock)
        else:
            c = sock
            try:
                data = c.recv(struct.calcsize('2i2i?'))
                if len(data) == struct.calcsize('2i2i?'): # 받은 데이터 값이 존재
                    unpacked_data = struct.unpack('2i2L?', data)
                    if (unpacked_data[4] == True):
                        print('Comm_disconnect')
                        finishCommTrigger = False

                    latestData = unpacked_data[0].encode('utf-16') + b"," + unpacked_data[1].encode('utf-16') 
                    print(f'Encoder1 : {unpacked_data[0]}, Encoder : {unpacked_data[1]}')
                    print(f'sec(s) : {unpacked_data[2]}.{unpacked_data[3]}')
                else:
                    c.sendall(latestData)
            except:
                c.close()