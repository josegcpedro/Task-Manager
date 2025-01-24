using System;


class Program
{
    static List<Task> tasks = new List<Task>();
    static void Main()
    {
        Menu();
    }

    static void Menu()
    {
        Console.WriteLine("Bienvenue dans votre Task Manager!");
        Console.WriteLine("1. Ajouter une nouvelle tâche");
        Console.WriteLine("2. Modifier une tâche");
        Console.WriteLine("3. Verifier les taches pas fini");
        Console.WriteLine("4. Verifier les taches fini");
        Console.WriteLine("5. Supprimer une tache");
        Console.WriteLine("6. Quitter");

        string choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                AddTask();
                break;
            case "2":
                //ModifyTask();
                break;
            case "3":
                //VerifyUnfinishedTasks();
                break;
            case "4":
                //VerifyFinishedTasks();
                break;
            case "5":
                //DeleteTask();
                break;
            case "6":
                return;
                break;
        }
    }


    static void AddTask()
    {
        Console.WriteLine("Quel est le nom de votre tache?");
        string name = Console.ReadLine();
        Console.WriteLine("De 1 a 10 qu'elle est la priorité de votre tache?");
        string input = Console.ReadLine();
        int.TryParse(input, out int priority);
        bool completed = false;
        Task newTask = new Task(name, priority, completed);
        tasks.Add(newTask);

        Console.WriteLine($"Nouvelle tâche ajoutée! {newTask.Name}");
    }
}


class Task
{
    public string? Name { get; set; }
    public int Priority { get; set; }
    public bool Completed { get; set; }

    public Task(string? name, int priority, bool completed)
    {
        Name = name;
        Priority = priority;
        Completed = completed;
    }
}