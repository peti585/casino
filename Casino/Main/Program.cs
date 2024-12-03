
static bool ValaszKerdesre(string szoveg)
{
    while (true)
    {
        Console.Write(szoveg);
        switch (char.Parse(Console.ReadLine()))
        {
            case '0':
                return false;
            case '1':
                return true;
            case '9':
                Environment.Exit(0);
                break;
        }
    }       
}

#region BlackJack
static void kartyaHuzas(List<int> szemely,int[] pakli)
{
    Random r = new Random();
    szemely.Add(pakli[r.Next(0,13)]);
    
}

static void csere(List<int> pakli)
{
    for (int i = 0; i < pakli.Count; i++)
    {
        if (pakli[i] == 11)
        {
            pakli[i] = 1;
        }
    }
}

static void BalckJack()
{
    #region kező értékek
    int[] kartyak = { 2, 3, 4, 5, 6, 7, 8, 9, 10, 10, 10, 10, 11 };
    bool gameContinue = true;
    bool playerRound = true;
    bool dealerRound = false;
    List<int> playerValueArrey = new List<int>();
    List<int> dealerValueArrey = new List<int>();
    bool preDivision = true;
    Console.BackgroundColor = ConsoleColor.Black;
    #endregion

    while (gameContinue == true)
    {
        #region előosztás
        for (int i = 0; i < 2 && preDivision == true; i++)
        {
            kartyaHuzas(playerValueArrey, kartyak);
            kartyaHuzas(dealerValueArrey, kartyak);
        }
        preDivision = false;
        #endregion

        #region kiírás

        if (dealerRound == false)
        {
            Console.Write($"Osztó lapjai  : {dealerValueArrey[0]}");
        }
        if (dealerRound == true)
        {
            Console.Write("Osztó lapjai  : ");
            for (int i = 0; i < dealerValueArrey.Count; i++)
            {
                Console.Write($"{dealerValueArrey[i]} ");
            }
        }
        Console.WriteLine();

        Console.Write($"Játékos lapjai: ");
        foreach (var item in playerValueArrey)
        {
             Console.Write($"{item} ");
        }
        Console.WriteLine();
        #endregion

        #region játékos kör
        if (playerRound == true)
        {
            bool valasz = ValaszKerdesre("kérsze még lapot? ");
            if (valasz == true)
            {
                kartyaHuzas(playerValueArrey, kartyak);
            }
            if (valasz == false)
            {
                dealerRound = true;
                playerRound = false;
            }
        }
        #endregion

        #region osztó kör
        if (dealerRound == true && dealerValueArrey.Sum() < 17)
        {
            kartyaHuzas(dealerValueArrey, kartyak);
        }
        else
        {
            dealerRound = false;
        }
        #endregion

        #region vég ellenörzés
        if (playerValueArrey.Sum() > 21)
        {
            csere(playerValueArrey);
        }
        if (dealerValueArrey.Sum() > 21 || (dealerValueArrey.Sum() >= 17 && dealerRound == false))
        {
            csere(dealerValueArrey);
            dealerRound = true;
        }

        // osztó gyözelem
        if ((dealerRound == false && playerRound == false && dealerValueArrey.Sum() > playerValueArrey.Sum()) || playerValueArrey.Sum() > 21 || dealerValueArrey.Sum() == 21)
        {
            Console.Clear();

            Console.Write("Osztó lapjai  : ");
            for (int i = 0; i < dealerValueArrey.Count; i++)
            {
                Console.Write($"{dealerValueArrey[i]} ");
            }            
            Console.WriteLine();

            Console.Write($"Játékos lapjai: ");
            foreach (var item in playerValueArrey)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();

            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine("Vesztetél!");
            Console.WriteLine("Vesztetél x Ft");
            Console.BackgroundColor = ConsoleColor.Black;
            gameContinue = ValaszKerdesre("Szeretnél még játszani? ");
            #region újra játszás
            if (gameContinue == true)
            {
                playerRound = true;
                dealerRound = false;
                playerValueArrey = new List<int>();
                dealerValueArrey = new List<int>();
                preDivision = true;
            }
            #endregion
        }

        // játéskos gyözelem
        if ((dealerRound == false && playerRound == false && playerValueArrey.Sum() > dealerValueArrey.Sum()) || dealerValueArrey.Sum() > 21)
        {
            Console.Clear();

            Console.Write("Osztó lapjai  : ");
            for (int i = 0; i < dealerValueArrey.Count; i++)
            {
                Console.Write($"{dealerValueArrey[i]} ");
            }
            Console.WriteLine();

            Console.Write($"Játékos lapjai: ");
            foreach (var item in playerValueArrey)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();

            Console.BackgroundColor = ConsoleColor.Green;
            Console.WriteLine("Nyertél!");
            Console.WriteLine("Nyertél x Ft");
            Console.BackgroundColor = ConsoleColor.Black;
            gameContinue = ValaszKerdesre("Szeretnél még játszani? ");
            #region újra játszás
            if (gameContinue == true)
            {
                playerRound = true;
                dealerRound = false;
                playerValueArrey = new List<int>();
                dealerValueArrey = new List<int>();
                preDivision = true;
            }
            #endregion
        }
        
        // döntetlen
        if (dealerRound == false && playerRound == false && dealerValueArrey.Sum() == playerValueArrey.Sum())
        {
            Console.Clear();

            Console.Write("Osztó lapjai  : ");
            for (int i = 0; i < dealerValueArrey.Count; i++)
            {
                Console.Write($"{dealerValueArrey[i]} ");
            }
            Console.WriteLine();

            Console.Write($"Játékos lapjai: ");
            foreach (var item in playerValueArrey)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();

            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Döntetlen!");
            Console.WriteLine("Vissza kaptál x Ft");
            Console.BackgroundColor = ConsoleColor.Black;
            gameContinue = ValaszKerdesre("Szeretnél még játszani? ");
            #region újra játszás
            if (gameContinue == true)
            {
                playerRound = true;
                dealerRound = false;
                playerValueArrey = new List<int>();
                dealerValueArrey = new List<int>();
                preDivision = true;
            }
            #endregion
        }
        //Console.Clear();
        #endregion
    }
    Menu();
}
#endregion


static void Menu()
{
    Console.WriteLine("Üdv a kaszinónkban!");
    Console.WriteLine();
    Console.WriteLine("A '9'-essel kilépész a programmbol.");
    Console.WriteLine("Az '1' igent,a '0' nemt jelent az igen/nem kérdések esetében.");
    Console.WriteLine("Mindig egy számmal válaszoljon a opciok közül.");
    Console.WriteLine();
    Console.WriteLine("1. BlackJack");
    Console.WriteLine("2. Slotmania");
    Console.WriteLine("3. ---");
    Console.WriteLine("4. ---");
    Console.Write("Válasszon a fentiek közül: ");

    switch (char.Parse(Console.ReadLine()))
    {
        case '9':
            Environment.Exit(0);
            break;
        case '1':
            Console.Clear();
            BalckJack();
            break;
        case '2':
            Console.Clear();
            break;
        case '3':
            Console.Clear();
            break;
        case '4':
            Console.Clear();
            break;
        default:
            Menu();
            break;
    }
}

Menu();

