Console.WriteLine($"Počet logických jader: {Environment.ProcessorCount}");

void Work1()
{
	for (var i = 0; i <= 100; i++)
	{
		Console.WriteLine($"Work 1: {i}");
	}
}
void Work2()
{
	for (var i = 0; i <= 100; i++)
	{
		Console.WriteLine($"Work 2: {i}");
	}
}
void Work3(int end)
{
	for (var i = 0; i <= end; i++)
	{
		Console.WriteLine($"Work 3: {i}");
		Thread.Sleep(100);
	}
}
void Work4(object end)
{
	try
	{
		for (var i = 0; i <= (int)end; i++)
		{
			Console.WriteLine($"Work 4: {i}");
			Thread.Sleep(100);
		}
		Console.WriteLine("Work 4 completed");
	}
	catch (ThreadAbortException e)
	{
		Console.WriteLine(e);
	}
}

void WorkSort()
{
	int[] list = { 78, 55, 45, 98, 13 };

	int j = list.Length - 2;
	int temp;
	bool swapped = true;
	while (swapped)
	{
		swapped = false;
		for (int i = 0; i <= j; i++)
		{
			if (list[i] > list[i + 1])
			{
				temp = list[i];
				list[i] = list[i + 1];
				list[i + 1] = temp;
				swapped = true;
			}
		}
		j--;
	}
	foreach (var item in list)
	{
		Console.WriteLine(item);
	}
}

Thread oThreadone = new Thread(WorkSort);
/*Thread oThreadtwo = new Thread(new ThreadStart(Work2)); // == new Thread(Work1);*/

oThreadone.Start();
/*oThreadtwo.Start();

// 1. možnost
/*ThreadStart starter = delegate { Work3(100); };
new Thread(starter).Start();
// 2. možnost
// Thread oThreadthree = new Thread(starter);
// oThreadthree.Start();
// 3. možnost
// new Thread(() => Work3(100)).Start();

Thread oThreadfour = new Thread(new ParameterizedThreadStart(Work4));
oThreadfour.Start(100);

//oThreadone.Join();
//oThreadtwo.Join();

/*Thread oThreadfive = new Thread(() =>
{
	for (int i = 0; i < 100; i++)
	{
		Console.WriteLine($"Work 0: {i}");
		Thread.Sleep(100);
	}
});

oThreadfive.Start();

Console.WriteLine("Main");
for (int i = 0; i < 100; i++)
{
	Console.WriteLine($"Work 0: {i}");
	Thread.Sleep(100);
}

oThreadone.Interrupt();
oThreadtwo.Interrupt();*/