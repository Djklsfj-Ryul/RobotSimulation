import socket
import struct
import traceback
import logging
import time

def sending_and_reciveing():
    s = socket.socket()
    socket.setdefaulttimeout(None)
    print('socket created ')
    port = 4444
    s.bind(('192.168.0.13', port)) #local host
    s.listen(30) #listening for connection for 30 sec?
    print('socket listensing ... ')
    while True:
        c, addr = s.accept() #when port connected
        print('connected client add: ', addr)
        bytes_received = c.recv(struct.calcsize('i')) #received bytes
        print(bytes_received)
        bytes_to_send = struct.pack('?', False) #converting float to byte
        c.sendall(b"324ew") #sending back
        c.close()



sending_and_reciveing()