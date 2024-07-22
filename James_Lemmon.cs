using System;
using System.Collections.Generic;

namespace BuffHotel
{
    public class Room
    {
        public int RoomNumber { get; set; }
        public int Capacity { get; set; }
        public bool IsReserved { get; set; } = false;
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }

        public Room(int roomNumber, int capacity)
        {
            RoomNumber = roomNumber;
            Capacity = capacity;
        }
    }

    class Program
    {
        static List<Room> roomList = new List<Room>();
        static string username = "alice";
        static string password = "alice123";

        static void Main(string[] args)
        {
            Console.WriteLine("CIDM2315 Final Project: James Lemmon");
            Console.WriteLine("Welcome to Buff Hotel!");

            if (!Login())
            {
                Console.WriteLine("Invalid username or password. Exiting application...");
                return;
            }

            InitializeRooms();

            while (true)
            {
                Console.Clear();
                Console.WriteLine($"Welcome {username}");
                Console.WriteLine("1. Show Available Rooms");
                Console.WriteLine("2. Check-In");
                Console.WriteLine("3. Show Reserved Rooms");
                Console.WriteLine("4. Check-Out");
                Console.WriteLine("5. Log Out");

                Console.Write("Select an option: ");
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ShowAvailableRooms();
                        break;
                    case "2":
                        CheckIn();
                        break;
                    case "3":
                        ShowReservedRooms();
                        break;
                    case "4":
                        CheckOut();
                        break;
                    case "5":
                        Console.WriteLine("Logging out...");
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        static bool Login()
        {
            Console.Write("Enter username: ");
            var inputUsername = Console.ReadLine();
            Console.Write("Enter password: ");
            var inputPassword = Console.ReadLine();

            return inputUsername == username && inputPassword == password;
        }

        static void InitializeRooms()
        {
            roomList.Add(new Room(101, 2));
            roomList.Add(new Room(102, 2));
            roomList.Add(new Room(103, 2));
            roomList.Add(new Room(104, 2));
            roomList.Add(new Room(105, 2));
            roomList.Add(new Room(106, 3));
            roomList.Add(new Room(107, 3));
            roomList.Add(new Room(108, 3));
            roomList.Add(new Room(109, 3));
            roomList.Add(new Room(110, 4));
        }

        static void ShowAvailableRooms()
        {
            Console.WriteLine("Available Rooms:");
            foreach (var room in roomList)
            {
                if (!room.IsReserved)
                {
                    Console.WriteLine($"Room {room.RoomNumber} (Capacity: {room.Capacity})");
                }
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        static void CheckIn()
        {
            Console.Write("Enter number of people: ");
            if (int.TryParse(Console.ReadLine(), out int numberOfPeople))
            {
                var availableRooms = roomList.FindAll(room => !room.IsReserved && room.Capacity >= numberOfPeople);

                if (availableRooms.Count > 0)
                {
                    Console.WriteLine("Available Rooms:");
                    foreach (var room in availableRooms)
                    {
                        Console.WriteLine($"Room {room.RoomNumber} (Capacity: {room.Capacity})");
                    }

                    Console.Write("Enter room number to check-in: ");
                    if (int.TryParse(Console.ReadLine(), out int roomNumber))
                    {
                        var roomToReserve = roomList.Find(room => room.RoomNumber == roomNumber && !room.IsReserved);
                        if (roomToReserve != null)
                        {
                            Console.Write("Enter customer name: ");
                            roomToReserve.CustomerName = Console.ReadLine();
                            Console.Write("Enter customer email: ");
                            roomToReserve.CustomerEmail = Console.ReadLine();
                            roomToReserve.IsReserved = true;
                            Console.WriteLine("Check-in successful!");
                        }
                        else
                        {
                            Console.WriteLine("Invalid room number or room is already reserved.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a valid room number.");
                    }
                }
                else
                {
                    Console.WriteLine("No available rooms match the capacity requirement.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        static void ShowReservedRooms()
        {
            Console.WriteLine("Reserved Rooms:");
            foreach (var room in roomList)
            {
                if (room.IsReserved)
                {
                    Console.WriteLine($"Room {room.RoomNumber} (Customer: {room.CustomerName})");
                }
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        static void CheckOut()
        {
            Console.Write("Enter room number to check-out: ");
            if (int.TryParse(Console.ReadLine(), out int roomNumber))
            {
                var roomToCheckOut = roomList.Find(room => room.RoomNumber == roomNumber && room.IsReserved);
                if (roomToCheckOut != null)
                {
                    Console.WriteLine($"Customer Name: {roomToCheckOut.CustomerName}");
                    Console.Write("Confirm check-out (y/n): ");
                    if (Console.ReadLine().ToLower() == "y")
                    {
                        roomToCheckOut.IsReserved = false;
                        roomToCheckOut.CustomerName = null;
                        roomToCheckOut.CustomerEmail = null;
                        Console.WriteLine("Check-out successful!");
                    }
                    else
                    {
                        Console.WriteLine("Check-out cancelled.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid room number or room is not reserved.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid room number.");
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
