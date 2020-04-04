using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.IO;

namespace laba_5
{
    class Lab5
    {
        public static void Main(string[] args)
        {
            First.Execute();
        }
        public class First
        {

            enum Pos
            {
                И,
                А,
                Т
            }
            enum Rey
            {
                Один,
                Два,
                Три,
                Четыре,
                Пять

            }

            struct TVshow
            {
                public string broadcast;
                public Pos Type;
                public string leading;
                public Rey reyting;

                public void showTable()
                {
                    Console.WriteLine("{0, -20} {1, -15} {2, -15} {3, -10}", broadcast, leading, Type, reyting);
                    Console.WriteLine();
                }
            }

            struct Log
            {
                public DateTime time;
                public string operation;
                public string name;

                public void logOutput()
                {
                    Console.WriteLine("{0, -20} : {1, -15} {2, -15}", time, operation, name);
                }
            }
            
            public static void CreateFile(string directory, string path)
            {
                var directoryInfo = new DirectoryInfo(directory);
                if (!directoryInfo.Exists)
                {
                    directoryInfo.Create();
                }
                FileStream file = new FileStream(path, FileMode.OpenOrCreate);
                file.Close();
            }
            public static void Execute()
            {
                var table = new List<TVshow>();

                string directory = @"C:\Users\Сашок\source\repos\LAba_po_programachu_6";
                string path = directory + "\\lab.dat";
                CreateFile(directory, path);
                using (StreamReader readFile = new StreamReader(path))
                {
                    while (!readFile.EndOfStream)
                    {
                        string brodcast = readFile.ReadLine();
                        string leading = readFile.ReadLine();
                        string pos = readFile.ReadLine();
                        var Type = Pos.А;
                        if (pos == "А")
                        {
                            Type = Pos.А;
                        }
                        else if (pos == "И")
                        {
                            Type = Pos.И;
                        }
                        else if (pos == "Т")
                        {
                            Type = Pos.Т;
                        }
                        string rey = readFile.ReadLine();
                        var reyting = Rey.Один;
                        if (rey == "Один")
                        {
                            reyting = Rey.Один;
                        }
                        else if (rey == "Два")
                        {
                            reyting = Rey.Два;
                        }
                        else if (rey == "Три")
                        {
                            reyting = Rey.Три;
                        }
                        else if (rey == "Четыре")
                        {
                            reyting = Rey.Четыре;
                        }
                        else if (rey == "Пять")
                        {
                            reyting = Rey.Пять;
                        }

                        int year = int.Parse(readFile.ReadLine());
                        decimal salary = decimal.Parse(readFile.ReadLine());
                        TVshow Телепередача;
                        Телепередача.broadcast = brodcast;
                        Телепередача.leading = leading;
                        Телепередача.reyting = reyting;
                        Телепередача.Type = Pos.И;
                        table.Add(Телепередача);
                    }
                }


                var logOfSession = new List<Log>(50);
                DateTime firstTime = DateTime.Now;
                DateTime secondTime = DateTime.Now;
                TimeSpan downtime = secondTime - firstTime;

                TVshow Телепередача_1;
                Телепередача_1.broadcast = "Своя игра";
                Телепередача_1.leading = "Кушелёв";
                Телепередача_1.reyting = Rey.Пять;
                Телепередача_1.Type = Pos.И;

                TVshow Телепередача_2;
                Телепередача_2.broadcast = "Воскресный вечер";
                Телепередача_2.leading = "Соловьев";
                Телепередача_2.reyting = Rey.Пять;
                Телепередача_2.Type = Pos.А;

                TVshow Телепередача_3;
                Телепередача_3.broadcast = "Пусть говорят";
                Телепередача_3.leading = "Малахов";
                Телепередача_3.reyting = Rey.Четыре;
                Телепередача_3.Type = Pos.Т;

                table = new List<TVshow>();
                table.Add(Телепередача_1);
                table.Add(Телепередача_2);
                table.Add(Телепередача_3);

                bool TVshow = true;
                bool error = true;
                do
                {
                    Console.WriteLine("1 – Просмотр таблицы");
                    Console.WriteLine("2 – Добавить запись");
                    Console.WriteLine("3 – Удалить запись");
                    Console.WriteLine("4 – Обновить запись");
                    Console.WriteLine("5 – Поиск записей");
                    Console.WriteLine("6 – Просмотреть лог");
                    Console.WriteLine("7 - Выход");
                    int selector = int.Parse(Console.ReadLine());
                    if (selector == 1)
                    {
                        for (int i = 0; i < table.Count; i++)
                        {
                            table[i].showTable();
                        }
                        Console.WriteLine();
                    }
                    if (selector == 2)
                    {
                        Console.Write("Введите название передачи: ");
                        string broadcast = Console.ReadLine();
                        string leading = Console.ReadLine();
                        var Type = Pos.А;
                        var reyting = Rey.Один;
                        do
                        {
                            Console.Write("Введите тип на русском языке: ");
                            string pos = Console.ReadLine();
                            if (pos == "А")
                            {
                                Type = Pos.А;
                                error = false;
                            }
                            else if (pos == "И")
                            {
                                Type = Pos.И;
                                error = false;
                            }
                            else if (pos == "Т")
                            {
                                Type = Pos.Т;
                                error = false;
                            }
                            else
                            {
                                Console.WriteLine("Поменяйте раскладку");
                                Console.WriteLine();
                            }
                        }
                        while (error);
                        error = true;
                        do
                        {
                            Console.Write("Введите Рейтинг программы: ");
                            string rey = Console.ReadLine();
                            if (rey == "Один")
                            {
                                reyting = Rey.Один;
                                error = false;
                            }
                            else if (rey == "Два")
                            {
                                reyting = Rey.Два;
                                error = false;
                            }
                            else if (rey == "Три")
                            {
                                reyting = Rey.Три;
                                error = false;
                            }
                            else if (rey == "Четыре")
                            {
                                reyting = Rey.Четыре;
                                error = false;
                            }
                            else if (rey == "Пять")
                            {
                                reyting = Rey.Пять;
                                error = false;
                            }
                            else
                            {
                                Console.WriteLine("от 1 до 5");
                                Console.WriteLine();
                            }


                        }
                        while (error);
                        error = true;


                        TVshow newTvshow;
                        newTvshow.broadcast = broadcast;
                        newTvshow.leading = leading;
                        newTvshow.reyting = reyting;
                        newTvshow.Type = Type;
                        table.Add(newTvshow);
                        Log newLog;
                        newLog.time = DateTime.Now;
                        newLog.operation = "Record added";
                        newLog.name = broadcast;
                        logOfSession.Add(newLog);

                        firstTime = newLog.time;
                        TimeSpan secondDowntime = firstTime - secondTime;
                        if (downtime < secondDowntime)
                        {
                            downtime = secondDowntime;
                        }
                        secondTime = newLog.time;
                        Console.WriteLine();
                    }
                    if (selector == 3)
                    {
                        int number = 0;
                        string Tvshow = string.Empty;
                        do
                        {
                            Console.WriteLine("Выберите номер строки для удаления: ");
                            number = int.Parse(Console.ReadLine());
                            if (number > 0 && number <= table.Count)
                            {
                                Tvshow = table[number - 1].broadcast;
                                table.RemoveAt(number - 1);
                                error = false;
                            }
                            else
                            {
                                Console.WriteLine(" Введите правильный номер!");
                            }
                        }
                        while (error);
                        error = true;

                        Log newLog;
                        newLog.time = DateTime.Now;
                        newLog.operation = "Record deleted";
                        newLog.name = Tvshow;
                        logOfSession.Add(newLog);

                        firstTime = newLog.time;
                        TimeSpan secondDowntime = firstTime - secondTime;
                        if (downtime < secondDowntime)
                        {
                            downtime = secondDowntime;
                        }
                        secondTime = newLog.time;
                        Console.WriteLine();
                    }
                    if (selector == 4)
                    {
                        string oldbroadcast = string.Empty;
                        string broadcast = string.Empty;
                        string oldleading = string.Empty;
                        string leading = string.Empty;
                        var Type = Pos.А;
                        var reyting = Rey.Один;
                        int number = 0;
                        do
                        {
                            Console.WriteLine("Выберите номер строки для обновления: ");
                            number = int.Parse(Console.ReadLine());
                            if (number > 0 && number <= table.Count)
                            {
                                oldbroadcast = table[number - 1].broadcast;
                                Console.Write("Введите Назвиние передачи: ");
                                broadcast = Console.ReadLine();
                                oldleading = table[number - 2].leading;
                                Console.Write("Введите фамилию велущего: ");
                                leading = Console.ReadLine();
                                do
                                {
                                    Console.Write("Введите тип рограммы (на русском языке): ");
                                    string pos = Console.ReadLine();
                                    if (pos == "А")
                                    {
                                        Type = Pos.А;
                                        error = false;
                                    }
                                    else if (pos == "И")
                                    {
                                        Type = Pos.И;
                                        error = false;
                                    }
                                    else if (pos == "Т")
                                    {
                                        Type = Pos.Т;
                                        error = false;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Введите правильный тип программы");
                                        Console.WriteLine();
                                    }
                                }
                                while (error);
                                error = true;
                                do
                                {
                                    Console.Write("Введите Рейтинг программы: ");
                                    string rey = Console.ReadLine();
                                    if (rey == "Один")
                                    {
                                        reyting = Rey.Один;
                                        error = false;
                                    }
                                    else if (rey == "Два")
                                    {
                                        reyting = Rey.Два;
                                        error = false;
                                    }
                                    else if (rey == "Три")
                                    {
                                        reyting = Rey.Три;
                                        error = false;
                                    }
                                    else if (rey == "Четыре")
                                    {
                                        reyting = Rey.Четыре;
                                        error = false;
                                    }
                                    else if (rey == "Пять")
                                    {
                                        reyting = Rey.Пять;
                                        error = false;
                                    }
                                    else
                                    {
                                        Console.WriteLine("от 1 до 5");
                                        Console.WriteLine();
                                    }

                                }
                                while (error);
                                error = true;

                                while (error) ;
                            }
                            else
                            {
                                Console.WriteLine("Введите правильный номер!");
                            }
                        }
                        while (error);
                        error = true;

                        TVshow newTvshow;
                        newTvshow.broadcast = broadcast;
                        newTvshow.leading = leading;
                        newTvshow.reyting = reyting;
                        newTvshow.Type = Type;
                        table.Insert(number - 1, newTvshow);
                        table.Remove(table[number]);

                        Log newLog;
                        newLog.time = DateTime.Now;
                        newLog.operation = "Record updated";
                        newLog.name = oldbroadcast + " --> " + broadcast;
                        logOfSession.Add(newLog);

                        firstTime = newLog.time;
                        TimeSpan secondDowntime = firstTime - secondTime;
                        if (downtime < secondDowntime)
                        {
                            downtime = secondDowntime;
                        }
                        secondTime = newLog.time;
                        Console.WriteLine();
                    }

                    if (selector == 5)
                    {
                        var pos = Pos.А;
                        do
                        {
                            Console.WriteLine("И - игровая ");
                            Console.WriteLine("A - аналитическая");
                            Console.WriteLine("T - ток-шоу");
                            Console.WriteLine("Введите, кого вы хотите найти (русская буква): ");
                            string select = Console.ReadLine();
                            Console.WriteLine();
                            if (select == "И" || select == "А" || select == "Т")
                            {
                                if (select == "И")
                                    pos = Pos.И;
                                if (select == "А")
                                    pos = Pos.А;
                                if (select == "Т")
                                    pos = Pos.Т;
                                for (int i = 0; i < table.Count; i++)
                                {
                                    if (table[i].Type == pos)
                                    {
                                        table[i].showTable();
                                    }
                                }
                                error = false;
                            }
                            else
                            {
                                Console.WriteLine("Введите в правильной форме!");
                            }
                        }
                        while (error);
                        error = true;
                        Console.WriteLine();
                    }
                    if (selector == 6)
                    {
                        for (int i = 0; i < logOfSession.Count; i++)
                        {
                            logOfSession[i].logOutput();
                        }
                        Console.WriteLine();
                        Console.WriteLine(downtime + " - самое большое время простоя");
                        Console.WriteLine();
                    }
                    if (selector == 7)
                    {
                        using (StreamWriter newText = new StreamWriter(path, false))
                        {
                            for (int i = 0; i < table.Count; i++)
                            {
                                newText.WriteLine("{0}\n{1}\n{2}\n{3}", table[i].broadcast, table[i].leading, table[i].Type, table[i].reyting);
                            }
                        }
                        TVshow = false;
                    }
                    if (selector < 1 || selector > 7)
                    {
                        Console.WriteLine("Выберите правильное действие");
                        Console.WriteLine();
                    }
                }
                while (TVshow);
                Console.WriteLine();

            }
        }
    }
}



