with open("C-lehky.txt") as vstup:
    with open("C-vysledek.txt", "w") as vystup:
        pocet_problemu = int(vstup.readline())
        
        for i in range(pocet_problemu):
            [radky, sloupce, polevy] = [int(j) for j in vstup.readline().split()]
            policka = [int(j) for j in vstup.readline().split()]
            polevy_cisla = []
            polevy_counter = 0
            for policko in policka:
                if policko != -1:
                    polevy_cisla.append(policko)
                else:
                    continue
            for policko in policka:
                if polevy_counter < len(polevy_cisla):
                    if policko == -1:
                        policka[policka.index(policko)] = polevy_cisla[polevy_counter]
                    elif policko == polevy_cisla[polevy_counter]:
                        continue
                    else:
                        polevy_counter += 1
                        continue
            print(" ".join(str(p) for p in policka), file=vystup)

    