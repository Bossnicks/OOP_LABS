using lab06.Exceptions;


namespace lab05
{
    public partial class Zoo
    {
        public void SortAnimalList()
        {
            AnimalList.Sort((x, y) => x.Birth.CompareTo(y.Birth));
        }
        public void PrintAnimalList()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            foreach (var item in AnimalList) Console.WriteLine(item.Name);
            SortAnimalList();
            Console.WriteLine();
            foreach (var item in AnimalList) Console.WriteLine(item.Name);
        }
        public void Add(Animal item)
        {
            AnimalList.Add(item);
            SortAnimalList();
        }
        public void Delete(Animal item)
        {
            AnimalList.Remove(item);
        }
    }
}

