using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp91
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string CommandAddingPlayer = "1";
            const string CommandBanPlayer = "2";
            const string CommandUnbanPlayer = "3";
            const string CommandDeletePlayer = "4";
            const string CommandExitProgramm = "5";

            bool isOpen = true;
            string userInput;

            Database database = new Database();

            while (isOpen)
            {
                Console.WriteLine(" Добро пожаловать в список базы данных игроков. ");

                database.ShowAllPlayers();

                Console.WriteLine(CommandAddingPlayer + " - Добавить игрока ");
                Console.WriteLine(CommandBanPlayer + " - Забанить игрока по уникальному номеру ");
                Console.WriteLine(CommandUnbanPlayer + " - Разбанить игрока по уникальному номеру ");
                Console.WriteLine(CommandDeletePlayer + " - Удалить игрока по уникальному номеру ");
                Console.WriteLine(CommandExitProgramm + " - Выход из программы ");
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case CommandAddingPlayer:
                        database.AddPlayer();
                        break;
                    case CommandBanPlayer:
                        database.BanPlayer();
                        break;
                    case CommandUnbanPlayer:
                        database.UnBanPlayer();
                        break;
                    case CommandDeletePlayer:
                        database.DeletePlayer();
                        break;
                    case CommandExitProgramm:
                        {                         
                            isOpen= false;
                        }
                        break;
                    default:
                        {
                            Console.WriteLine(" Ошибка выбора меню. Выберите подходящие ");
                            Console.ReadKey();
                            break;
                        }
                }

                Console.Clear();

            }

        }
    }

    class Player
    {
        private string _name;
        private int _id;
        private int _level;
        private bool _isBanned;

        public Player(string name, int id, int level)
        {
            _name = name;
            _id = id;
            _level = level;
            _isBanned = false;
        }

        public void ShowStats()
        {
            Console.WriteLine($" айди - {_id}, имя игрока - {_name}, уровень игрока - {_level} ");
        }

        public void Ban()
        {
            _isBanned = true;
        }

        public void Unban()
        {
            _isBanned = false;
        }

        public int GetId()
        {
            return _id;
        }

    }

    class Database
    {
        private List<Player> _players = new List<Player>();

        public void ShowAllPlayers()
        {
            for (int i = 0; i < _players.Count; i++)
            {
                _players[i].ShowStats();
            }
        }

        public void AddPlayer()
        {
            Console.Write(" Пропишите имя игроку ");
            string name = Console.ReadLine();

            int level = GetNumber(" Введите уровень ");
            int id = GetNumber(" Введите айди игрока ");

            _players.Add(new Player(name, id, level));
        }

        private int GetNumber(string text)
        {
            Console.Write(text);
            int.TryParse(Console.ReadLine(), out int number);
            return number;

        }

        public void BanPlayer()
        {
            int id = GetNumber(" Пропишите айди игрока ");
            bool playerIsbanned = false;

            for (int i = 0; i < _players.Count; i++)
            {
                if (_players[i].GetId() == id)
                {
                    _players[i].Ban();
                    playerIsbanned = true;
                    break;
                }
            }

            if (playerIsbanned)
            {
                Console.WriteLine(" Пользователь забанен ");
            }
            else
            {
                Console.WriteLine(" Пользователь не найден. Пропишите снова ");
                Console.ReadKey();
            }
        }

        public void UnBanPlayer()
        {
            int id = GetNumber(" Пропишите айди игрока ");
            bool playerUnIsBanned = false;

            for (int i = 0; i < _players.Count;i++)
            {
                if (_players[i].GetId() == id)
                {
                    _players[i].Unban();
                    playerUnIsBanned = true;
                    break;
                }
            }

            if (playerUnIsBanned)
            {
                Console.WriteLine(" Пользователь разбанен ");
            }
            else
            {
                Console.WriteLine(" Пользователь не найден. Пропишите снова ");
                Console.ReadKey();
            }
        }   
    
        public void DeletePlayer() 
        {
            {
                int id = GetNumber(" Пропишите айди игрока ");
                bool playerDeletetPlayer = false;
                
                for (int i = 0; i < _players.Count; i++)
                {
                    if (_players[i].GetId() == id)
                    {
                        Player player = _players[i];
                        _players.Remove(player);
                        playerDeletetPlayer = true;
                        break;
                    }
                } 
                
                if (playerDeletetPlayer)
                {
                    Console.WriteLine(" Пользователь удален ");
                }
                else
                {
                    Console.WriteLine(" Пользователь не найден. Пропишите снова ");
                    Console.ReadKey();
                }
            }           
            }
        }
    }


