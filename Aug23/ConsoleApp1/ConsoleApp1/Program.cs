class Animal
{
    public string Name { get; set; }
}

class Cat : Animal
{
    public int Paws { get; set; }
}

interface IAnimalProvider<out T>
{
    T GetAnimal();
}

class CatProvided : IAnimalProvider<Cat>
{
    public Cat GetAnimal()
    {
        return new Cat { Name = "Whisker", Paws = 4 };
    }
}

class Program
{
    static void Main(string[] args)
    {
        IAnimalProvider<Animal> animalProvider = new CatProvided();
        Animal animal = animalProvider.GetAnimal();
        Console.WriteLine(animal.Name);
    }
}