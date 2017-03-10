def recupNbNoeuds(file):
    i = 0
    with open(file,'r') as f:
        lines = f.readlines()
        for line in lines:
            i += 1
    f.close()
    return i

def lireGraphe(file):
    list = []
    i=0
    noeuds =""
    with open(file,'r') as f:
        lines = f.readlines()
        for line in lines:
            for i in range (2,len(line)):
                noeuds = noeuds + line[i]
            list1 = noeuds.split(",")
            for i in range (len(list1)):
                list1[i] = int(list1[i])

            list.append(list1)
            noeuds = ""


    f.close()
    return list



def main():
    file = "graphe"
    print ("  ", end='')
    nbLigne = recupNbNoeuds(file)+1
    for line in range (nbLigne-1):
        print(str(line) + " ", end='')
    print()
    print("  ", end = '')
    for line in range(nbLigne+1):
        print("-", end='')
    print()

    graphe=lireGraphe(file)
    for i in range (nbLigne-1):
        print(str(i) + '|', end='')

        for j in range(len(graphe[i])):
            for k in range(j, len(graphe[i])):

                if (k == graphe[i][j]):

                    print(str(1) + " " , end='')
                else:
                    print(str(0) + " ", end='')
        print()





main()