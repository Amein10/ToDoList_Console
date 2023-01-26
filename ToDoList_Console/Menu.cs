using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList_Console
{
    internal class Menu
    {
        List<ToDoItem> todoList = new();

        //Constructor that runs when object is instantiated (with new keyword).
        public Menu()
        {
            while (true)
            {
                MainMenu();
            }
        }
        //Start menu
        public void MainMenu()
        {
            Console.WriteLine("Main Menu\n\n(1) Add new\n(2) Show List");

            var v = Console.ReadKey(true);
            switch (v.KeyChar)
            {
                case '1':
                    CreateItem();
                    break;
                case '2':
                    ShowList();
                    break;
                default:
                    break;
            }
        }

        //Show TodoList shows TodoItems
        void ShowList()
        {
            foreach (ToDoItem? item in todoList)
            {
                ShowItem(item);
            }
        }

        //Create Item
        private void CreateItem()
        {
            ToDoItem newItem = new ToDoItem();
            newItem.Created = DateTime.Now;

            Console.WriteLine("What to do?");
            newItem.Todo = Console.ReadLine();

            Console.WriteLine("When to do it?");
            string dl = Console.ReadLine();
            //TODO Get different input regarding dates and times
            newItem.Deadline = DateTime.Parse(dl);
            newItem.IsDone = false;

            Console.WriteLine("Is it important?");
            newItem.IsFavorite = Console.ReadKey(true).Key == ConsoleKey.Y ? true : false;

            todoList.Add(newItem);
        }

        //Read TodoItem
        private void ShowItem(ToDoItem toDoItem)
        {
            Console.WriteLine($"What: {toDoItem.Todo} When: {toDoItem.Deadline} isDone: {toDoItem.IsDone}");
            //Console.WriteLine("What: {0} When: {1} isDone: {2}", toDoItem.Todo, toDoItem.Deadline, toDoItem.IsDone);
            //Console.WriteLine("What: " + toDoItem.Todo + "When: " + toDoItem.Deadline + "isDone: " + toDoItem.IsDone);
        }

        private void DeleteItem()
        {
            Console.WriteLine("What item do you want to delete / remove?");
            ShowList();
            int i = todoList.Parse(Console.ReadLine());

            Console.WriteLine("Are you sure you want to delete this item?\n\n(Y): Yes\n(N): No");
            var v = Console.ReadKey(true);
            switch (v.KeyChar)
            {
                case 'y':
                    todoList.RemoveAt(i);
                    break;
                case 'n':

                    break;
                default:
                    break;
            }
        }
        private void UpdateItem()
        {
            Console.WriteLine("Update. Pick item index for todoitem that needs updating");
            ShowList();
            int i = int.Parse(Console.ReadLine());
            ToDoItem tdi = todoList[i];
            Console.WriteLine("What to do?");
            string input = Console.ReadLine();
            if (input != "")
                tdi.Description = input;
        }

    }
    //Update Item


    //Delete Item




}