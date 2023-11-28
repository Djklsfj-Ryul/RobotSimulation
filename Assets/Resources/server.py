import socket, time
import struct
import sys

host = '192.168.0.4'
port = 4444

server_socket = socket.socket(socket.AF_INET, socket.SOCK_STREAM)

server_socket.setsockopt(socket.SOL_SOCKET, socket.SO_REUSEADDR, 1)

server_socket.bind((host, port))

server_socket.listen()
print('echo server start')

client_soc, addr = server_socket.accept()
print('connected client add: ', addr)

while (1):
    data = client_soc.recv(struct.calcsize('2i2L?'))
    # 구조체 데이터 : int32 position[2] / unsigned long time[2] / bool end_signal

    if len(data) == struct.calcsize('2i2i?'):
        unpacked_data = struct.unpack('2i2L?', data)
        if (unpacked_data[4] == True):
            print('Comm_disconnect')
            break

        print(f'Encoder1 : {unpacked_data[0]}, Encoder : {unpacked_data[1]}')
        print(f'sec(s) : {unpacked_data[2]}.{unpacked_data[3]}')

time.sleep(5)

server_socket.close()