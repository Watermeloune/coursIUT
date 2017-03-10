#include <stdio.h>
#include <pthread.h>
#include <stdlib.h>
#include <errno.h>


pthread_t pthread_id[3];

void f_thread(){
	printf("Je suis le thread d'identité %d\n", getpid());
}

int main(int argc, char const *argv[])
{
	int i;
	for (int i = 0; i < 3; ++i)
	{
		if(pthread_create(pthread_id+i,NULL,(void*) f_thread,NULL)==-1)
		{
			perror("erreur creation thread");

		}
	}
	printf("je suis le processus inital de pid %d\n", getpid());
		sleep(3);
		exit(1);
	return 0;
}