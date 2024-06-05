// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
using System;
using System.Collections.Generic;

namespace MultiValueDictionaryApp
{
    class Program
    {
        static Dictionary<string, HashSet<string>> multiValueDict = new Dictionary<string, HashSet<string>>();

        static void Main(string[] args)
        {
            string command;
            Console.WriteLine("Enter commands:");
            while ((command = Console.ReadLine()) != null)
            {
                ProcessCommand(command);
            }
        }

        static void ProcessCommand(string command)
        {
            var parts = command.Split(' ', 3, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length == 0) return;

            switch (parts[0].ToUpper())
            {
                case "KEYS":
                    Keys();
                    break;
                case "MEMBERS":
                    if (parts.Length == 2)
                        Members(parts[1]);
                    else
                        Console.WriteLine(") ERROR, key not provided");
                    break;
                case "ADD":
                    if (parts.Length == 3)
                        Add(parts[1], parts[2]);
                    else
                        Console.WriteLine(") ERROR, key or member not provided");
                    break;
                case "REMOVE":
                    if (parts.Length == 3)
                        Remove(parts[1], parts[2]);
                    else
                        Console.WriteLine(") ERROR, key or member not provided");
                    break;
                case "REMOVEALL":
                    if (parts.Length == 2)
                        RemoveAll(parts[1]);
                    else
                        Console.WriteLine(") ERROR, key not provided");
                    break;
                case "CLEAR":
                    Clear();
                    break;
                case "KEYEXISTS":
                    if (parts.Length == 2)
                        KeyExists(parts[1]);
                    else
                        Console.WriteLine(") ERROR, key not provided");
                    break;
                case "MEMBEREXISTS":
                    if (parts.Length == 3)
                        MemberExists(parts[1], parts[2]);
                    else
                        Console.WriteLine(") ERROR, key or member not provided");
                    break;
                case "ALLMEMBERS":
                    AllMembers();
                    break;
                case "ITEMS":
                    Items();
                    break;
                default:
                    Console.WriteLine(") ERROR, unknown command");
                    break;
            }
        }

        static void Keys()
        {
            if (multiValueDict.Count == 0)
            {
                Console.WriteLine("(empty set)");
            }
            else
            {
                int index = 1;
                foreach (var key in multiValueDict.Keys)
                {
                    Console.WriteLine($"{index}) {key}");
                    index++;
                }
            }
        }

        static void Members(string key)
        {
            if (multiValueDict.ContainsKey(key))
            {
                int index = 1;
                foreach (var member in multiValueDict[key])
                {
                    Console.WriteLine($"{index}) {member}");
                    index++;
                }
            }
            else
            {
                Console.WriteLine(") ERROR, key does not exist.");
            }
        }

        static void Add(string key, string member)
        {
            if (!multiValueDict.ContainsKey(key))
            {
                multiValueDict[key] = new HashSet<string>();
            }

            if (multiValueDict[key].Add(member))
            {
                Console.WriteLine(") Added");
            }
            else
            {
                Console.WriteLine(") ERROR, member already exists for key");
            }
        }

        static void Remove(string key, string member)
        {
            if (multiValueDict.ContainsKey(key))
            {
                if (multiValueDict[key].Remove(member))
                {
                    if (multiValueDict[key].Count == 0)
                    {
                        multiValueDict.Remove(key);
                    }
                    Console.WriteLine(") Removed");
                }
                else {
                    Console.WriteLine(") ERROR, member does not exist");
                }
               
            }
            else
            {
                Console.WriteLine(") ERROR, key does not exist");
            }
        }

        static void RemoveAll(string key)
        {
            if (multiValueDict.Remove(key))
            {
                Console.WriteLine(") Removed");
            }
            else
            {
                Console.WriteLine(") ERROR, key does not exist");
            }
        }

        static void Clear()
        {
            multiValueDict.Clear();
            Console.WriteLine(") Cleared");
        }

        static void KeyExists(string key)
        {
            Console.WriteLine($") {multiValueDict.ContainsKey(key).ToString().ToLower()}");
        }

        static void MemberExists(string key, string member)
        {
            if (multiValueDict.ContainsKey(key) && multiValueDict[key].Contains(member))
            {
                Console.WriteLine(") true");
            }
            else
            {
                Console.WriteLine(") false");
            }
        }

        static void AllMembers()
        {
            if (multiValueDict.Count == 0)
            {
                Console.WriteLine("(empty set)");
            }
            else
            {
                int index = 1;
                foreach (var key in multiValueDict.Keys)
                {
                    foreach (var member in multiValueDict[key])
                    {
                        Console.WriteLine($"{index}) {member}");
                        index++;
                    }
                }
            }
        }

        static void Items()
        {
            if (multiValueDict.Count == 0)
            {
                Console.WriteLine("(empty set)");
            }
            else
            {
                int index = 1;
                foreach (var key in multiValueDict.Keys)
                {
                    foreach (var member in multiValueDict[key])
                    {
                        Console.WriteLine($"{index}) {key}: {member}");
                        index++;
                    }
                }
            }
        }
    }
}
