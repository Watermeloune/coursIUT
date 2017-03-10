// compilation :	gcc -Wall -o client.o  -c client.c
//			gcc -o client client.o
#include <stdio.h>
#include <errno.h>
#include <signal.h>
#include <netdb.h>
#include <netinet/in.h>
#include <sys/socket.h>
#define SERVEURNAME "192.168.1.106" // adresse IP de mon serveur

int to_server_socket = -1;
void main ( )
{
char *server_name = SERVEURNAME;
struct sockaddr_in serverSockAddr;
struct hostent *serverHostEnt;
long hostAddr;
long status;
char buffer[512];
bzero(&serverSockAddr,sizeof(serverSockAddr));
hostAddr = inet_addr(SERVEURNAME);
if ( (long)hostAddr != (long)-1)
  bcopy(&hostAddr,&serverSockAddr.sin_addr,sizeof(hostAddr));
else
{
  serverHostEnt = gethostbyname(SERVEURNAME);
  if (serverHostEnt == NULL)
  {
    printf("gethost rate\n");
    exit(0);
  }
  bcopy(serverHostEnt->h_addr,&serverSockAddr.sin_addr,serverHostEnt->h_length);
}
serverSockAddr.sin_port = htons(30000);
serverSockAddr.sin_family = AF_INET;
/* creation de la socket */
if ( (to_server_socket = socket(AF_INET,SOCK_STREAM,0)) < 0)
{
  printf("creation socket client ratee\n");
  exit(0);
}
/* requete de connexion */
if(connect( to_server_socket,
            (struct sockaddr *)&serverSockAddr,
            sizeof(serverSockAddr)) < 0 )
{
  printf("demande de connection ratee\n");
  exit(0);
}
/* envoie de donne et reception */
write(to_server_socket,"Toto",4);
read(to_server_socket,buffer,512);
printf(buffer);
/* fermeture de la connection */
shutdown(to_server_socket,2);
close(to_server_socket);
}