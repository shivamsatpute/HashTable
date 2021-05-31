using System;

namespace HashTable
{
    class Program
    {
        static void Main(string[] args)
        {
            MyMapNode<string, string> hashtable = new MyMapNode<string, string>(5); 
            hashtable.Add("0", "To");  
            hashtable.Add("1", "be");
            hashtable.Add("2", "or");
            hashtable.Add("3", "not");
            hashtable.Add("4", "to");
            hashtable.Add("5", "be");
            Console.ReadLine();
        }
    }
}

