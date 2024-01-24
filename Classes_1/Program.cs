using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Подготовка к бою:");

        Console.WriteLine("Введите имя бойца:");
        string name = Console.ReadLine();

        Console.WriteLine("Введите начальное здоровье бойца (10-100):");
        int health = int.Parse(Console.ReadLine());

        Console.WriteLine("Введите значение брони шлема от 0 до 1:");
        float helmArmor = float.Parse(Console.ReadLine());

        Console.WriteLine("Введите значение брони кирасы от 0 до 1:");
        float shellArmor = float.Parse(Console.ReadLine());

        Console.WriteLine("Введите значение брони сапог от 0 до 1:");
        float bootsArmor = float.Parse(Console.ReadLine());

        Console.WriteLine("Укажите минимальный урон оружия (0-20):");
        float minDamage = float.Parse(Console.ReadLine());

        Console.WriteLine("Укажите максимальный урон оружия (20-40):");
        float maxDamage = float.Parse(Console.ReadLine());

        Unit player = new Unit(name, health, new Helm(helmArmor), new Shell(shellArmor), new Boots(bootsArmor), new Weapon(minDamage, maxDamage));

        Console.WriteLine("Общий показатель брони равен: " + player.Armor);
        Console.WriteLine("Фактическое значение здоровья равно: " + player.RealHealth);

        Console.ReadLine();
    }
}