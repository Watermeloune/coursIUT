#include <stdio.h>
#include <sys/types.h>
#include <sys/socket.h>
#include <netinet/in.h>
#include <signal.h>

char message[512];
int maSocket;

void main ( void )
{
int socketClient;
struct sockaddr_in adresse, adresseClient;
int longueurAdresse, lg;
bzero(&adresse,sizeof(adresse));
adresse.sin_port = htons(30000);
adresse.sin_family = AF_INET;
adresse.sin_addr.s_addr = htonl(INADDR_ANY);


if ((maSocket = socket(AF_INET,SOCK_STREAM,0))== -1)
{
  printf("la creation rate\n");
  exit(0);
}
signal(SIGINT,0);

bind(maSocket,(struct sockaddr *)&adresse,sizeof(adresse));

listen(maSocket,5);

longueurAdresse = sizeof(adresseClient);
while(1)
{
  socketClient = accept(maSocket,
                         (struct sockaddr *)&adresseClient,
                         &longueurAdresse);
  if (fork() == 0)
  {
    close(maSocket);
    lg = read(socketClient,message, 512);
printf("le serveur a recu: %s\n",message);
sprintf(message,"%s du serveur",message);
write(socketClient,message, 512);
shutdown(socketClient,2);
close(socketClient);
exit(0);
  }
}
shutdown(maSocket,2);
close(maSocket);
}
