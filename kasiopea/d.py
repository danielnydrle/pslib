with open("D-lehky.txt") as input:
    with open("D-vysledek.txt", "w") as output:
        problems = int(input.readline())

        for y in range(problems):
            matrix = []
            door = {"row": 0, "column": 0}
            [rows, columns, boxes] = [int(i) for i in input.readline().split()]
            for r in range(rows):
                matrix.append(input.readline())
                if "D" in matrix[r]:
                    door["row"] = r
                    door["column"] = matrix[r].find("D")
            print(door)
            door.clear()
