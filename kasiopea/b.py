with open("B-tezky.txt") as vstup:
    with open("B-vysledek.txt", "w") as vystup:
        pocet_problemu = int(vstup.readline())
        [sude_tydny, liche_tydny] = [0, 0]
        for i in range(pocet_problemu):
            dny = int(vstup.readline())
            tydny = [int(j) for j in vstup.readline().split()]
            for tyden in tydny:
                if (tyden % 2 == 0):
                    sude_tydny+=1
                else:
                    liche_tydny+=1
            if (sude_tydny > liche_tydny):
                print("ANO", file=vystup)
            else:
                print("NE", file=vystup)
            [sude_tydny, liche_tydny] = [0, 0]