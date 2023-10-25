using System;
using System.Collections.Generic;

class DailyPlanner
{
    private List<Note> notes;
    private int currentDateIndex;

    public DailyPlanner()
    {
        notes = new List<Note>();
        currentDateIndex = 0;
    }

    public void AddNote(string title, string description, DateTime date, DateTime dueDate)
    {
        Note note = new Note(title, description, date, dueDate);
        notes.Add(note);
    }

    public void DisplayMenu()
    {
        Note note = notes[currentDateIndex];
        Console.WriteLine($"Дата: {note.Date.ToShortDateString()}");
        Console.WriteLine($"Заметка: {note.Title}");
    }

    public void DisplayFullInfo()
    {
        Note note = notes[currentDateIndex];
        Console.WriteLine($"Дата: {note.Date.ToShortDateString()}");
        Console.WriteLine($"Заметка: {note.Title}");
        Console.WriteLine($"Описание: {note.Description}");
        Console.WriteLine($"Дата выполнения: {note.DueDate.ToShortDateString()}");
    }

    public void NextDate()
    {
        if (currentDateIndex < notes.Count - 1)
        {
            currentDateIndex++;
        }
    }

    public void PreviousDate()
    {
        if (currentDateIndex > 0)
        {
            currentDateIndex--;
        }
    }
}

class Note
{
    public string Title { get; }
    public string Description { get; }
    public DateTime Date { get; }
    public DateTime DueDate { get; }

    public Note(string title, string description, DateTime date, DateTime dueDate)
    {
        Title = title;
        Description = description;
        Date = date;
        DueDate = dueDate;
    }
}

class Program
{
    static void Main(string[] args)
    {
        DailyPlanner planner = new DailyPlanner();

        // Добавляем заметки
        planner.AddNote("Дота", "Нужно поиграть в доту с Матвеем в часиков 8", new DateTime(2023, 1, 1), new DateTime(2023, 1, 2));
        planner.AddNote("Практос по питону", "Обязательно сделать практос в последний день и сдать его в 23:50", new DateTime(2023, 1, 2), new DateTime(2023, 1, 3));
        planner.AddNote("Бк", "Сходить в бк в 15:30", new DateTime(2023, 1, 3), new DateTime(2023, 1, 4));

        ConsoleKeyInfo key;
        do
        {
            Console.Clear();
            planner.DisplayMenu();

            key = Console.ReadKey(true);
            switch (key.Key)
            {
                case ConsoleKey.LeftArrow:
                    planner.PreviousDate();
                    break;
                case ConsoleKey.RightArrow:
                    planner.NextDate();
                    break;
                case ConsoleKey.Enter:
                    Console.Clear();
                    planner.DisplayFullInfo();
                    Console.WriteLine("Нажми любую клавишу для продолжения...");
                    Console.ReadKey();
                    break;
            }
        } while (key.Key != ConsoleKey.Escape);
    }
}