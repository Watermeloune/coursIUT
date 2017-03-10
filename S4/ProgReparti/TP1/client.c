#include <stdio.h>
#include <errno.h>
#include <signal.h>
#include <netdb.h>
#include <netinet/in.h>
#include <sys/socket.h>
#define nomServeur "127.0.0.1" 
int destinationServ = -1;

void main ( void )
{
char *server_name = nomServeur;
struct sockaddr_in maSocket;
struct hostent *HostServerIn;
long hostAddr;
long status;
char message[512];
bzero(&maSocket,sizeof(maSocket));
hostAddr = inet_addr(nomServeur);
if ( (long)hostAddr != (long)-1)
  bcopy(&hostAddr,&maSocket.sin_addr,sizeof(hostAddr));
else
{
  HostServerIn = gethostbyname(nomServeur);
  if (HostServerIn == NULL)
  {
    printf("gethost rate\n");
    exit(0);
  }
  bcopy(HostServerIn->h_addr,&maSocket.sin_addr,HostServerIn->h_length);
}
maSocket.sin_port = htons(30000);
maSocket.sin_family = AF_INET;


if ( (destinationServ = socket(AF_INET,SOCK_STREAM,0)) < 0)
{
  printf("creation socket client ratee\n");
  exit(0);
}



if(connect( destinationServ,(struct sockaddr *)&maSocket,sizeof(maSocket)) < 0 )
{
  printf("demande de connection ratee\n");
  exit(0);
}


write(destinationServ,"Bien reçu",100);
read(destinationServ,message,512);
printf(message);

shutdown(destinationServ,2);
close(destinationServ);
}
