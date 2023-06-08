using SimpleRPG;

bool playAgain = true;

while (playAgain)
{
    Console.WriteLine("Choose your class: \n1. Warrior\n2. Mage\n3. Archer");
    string playerClass = Console.ReadLine();
    Character player;

    switch (playerClass)
    {
        case "1":
            player = new Warrior("Player", 100, 25);
            break;
        case "2":
            player = new Mage("Player", 100, 20);
            break;
        case "3":
            player = new Archer("Player", 100, 15);
            break;
        default:
            Console.WriteLine("Invalid class. Defaulting to Warrior.");
            player = new Warrior("Player", 100, 25);
            break;
    }

    Mage enemy = new Mage("Enemy", 50, 20);

    while (player.Health > 0 && enemy.Health > 0)
    {
        Console.WriteLine("Choose your action: \n1. Normal Attack\n2. Special Attack");
        string action = Console.ReadLine();
        int previousEnemyHealth = enemy.Health;

        switch (action)
        {
            case "1":
                player.Attack(enemy);
                break;
            case "2":
                if (player is Warrior)
                {
                    (player as Warrior).ChargeAttack(enemy);
                }
                else if (player is Mage)
                {
                    (player as Mage).Fireball(enemy);
                }
                else if (player is Archer)
                {
                    (player as Archer).RangedAttack(enemy);
                }
                break;
            default:
                Console.WriteLine("Invalid action. Skipping your turn.");
                break;
        }

        int damageDealt = previousEnemyHealth - enemy.Health;
        Console.WriteLine($"{player.Name} dealt {damageDealt} damage to {enemy.Name}. {enemy.Name}'s health is now {enemy.Health}.");

        if (enemy.Health <= 0) break;

        // Enemy AI (Just casting Fireball each turn for simplicity)
        int previousPlayerHealth = player.Health;
        if (enemy is Mage)
        {
            (enemy as Mage).Fireball(player);
        }

        int damageTaken = previousPlayerHealth - player.Health;
        Console.WriteLine($"{enemy.Name} dealt {damageTaken} damage to {player.Name}. {player.Name}'s health is now {player.Health}.");
    }

    if (player.Health > 0)
        Console.WriteLine($"{player.Name} won!");
    else
        Console.WriteLine($"{enemy.Name} won!");

    // Ask player to play again
    Console.WriteLine("Do you want to play again? (yes/no)");
    string playAgainResponse = Console.ReadLine().ToLower();

    if (playAgainResponse != "yes")
        playAgain = false;
}