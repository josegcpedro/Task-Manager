using System;
using System.Collections.Generic;
using System.Linq;


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
        Console.WriteLine("6. Afficher par ordre de priorité");
        Console.WriteLine("7. Quitter");

        string choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                AddTask();
                break;
            case "2":
                ModifyTask();
                break;
            case "3":
                VerifyUnfinishedTasks();
                break;
            case "4":
                VerifyFinishedTasks();
                break;
            case "5":
                DeleteTask();
                break;
            case "6":
                SortByPriority();
                break;
            case "7":
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
        Menu();
    }

    static void VerifyFinishedTasks()
    {
        var finishedTasks = tasks.Where(t => t.Completed).ToList();


        if (!finishedTasks.Any())
        {
            Console.WriteLine("Aucune tache fini trouvé!");
            Menu();
        }
        else
        {
            foreach (var task in finishedTasks)
            {
                Console.WriteLine($"Nom: {task.Name}, Priorité: {task.Priority}");
                Menu();
            }
        }
    }

    static void VerifyUnfinishedTasks()
    {
        var unfinishedTasks = tasks.Where(t => !t.Completed).ToList();

        if (!unfinishedTasks.Any())
        {
            Console.WriteLine("Aucune tache trouvé!");
            Menu();
        }
        else
        {
            foreach (var task in unfinishedTasks)
            {
                Console.WriteLine($"Nom: {task.Name}, Priorité: {task.Priority}");
                Menu();
            }
        }
    }

    static void ModifyTask()
    {
        Console.WriteLine("Quelle est le nom de la tache que vous souhaitez modifier?");
        string desiredTaskToModify = Console.ReadLine();

        Task taskToModify = tasks.Find(task => task.Name.Equals(desiredTaskToModify, StringComparison.OrdinalIgnoreCase));

        if (desiredTaskToModify == null)
        {
            Console.WriteLine("Tache pas trouvé!");
            Menu();
        }
        else
        {
            Console.WriteLine("Que voulez-vous modifier?");
            Console.WriteLine("1. Le nom");
            Console.WriteLine("2. La priorité");
            Console.WriteLine("3. Mettre tache comme conclue.");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.WriteLine("Quel est le nouveau nom?");
                    string newName = Console.ReadLine();
                    taskToModify.Name = newName;
                    Console.WriteLine($"Nom changé! Nouveau nom : {taskToModify.Name}");
                    Menu();
                    break;
                case "2":
                    Console.WriteLine("Quel est la priorité");
                    string input = Console.ReadLine();
                    int.TryParse(input, out int newPriority);
                    taskToModify.Priority = newPriority;
                    Console.WriteLine($"Priorité changé! Nouvelle priorité : {taskToModify.Priority}");
                    Menu();
                    break;
                case "3":
                    Console.WriteLine("Task fini, bien joué!");
                    taskToModify.Completed = true;
                    Menu();
                    break;
            }
        }
    }

    static void DeleteTask()
    {
        Console.WriteLine("Quelle est la tâche que vous voulez supprimer?");
        string desiredTaskToRemove = Console.ReadLine();

        Task taskToDelete = tasks.Find(task => task.Name.Equals(desiredTaskToRemove, StringComparison.OrdinalIgnoreCase));

        if (taskToDelete != null)
        {
            tasks.Remove(taskToDelete);
            Console.WriteLine($"Tâche {taskToDelete.Name} suprimée!");
            Menu();
        }
        else
        {
            Console.WriteLine("Task pas trouvé!");
            Menu();
        }

    }

    static void SortByPriority()
    {

        var sortedTasks = tasks.OrderByDescending(t => t.Priority).ToList();

        Console.WriteLine("Tâches triées par priorité (croissante):");
        foreach (var task in sortedTasks)
        {
            Console.WriteLine($"Nom: {task.Name}, Priorité: {task.Priority}");
        }
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