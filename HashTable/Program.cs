using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HashTable
{
    class Program
    {
        static void Main(string[] args) 
        {
            Console.WriteLine("Hash Table");

            /*UC1*/
            //MyMapNode<string, string> hashtable = new MyMapNode<string, string>(5); 
            //hashtable.Add("0", "To"); 
            //hashtable.Add("1", "be");
            //hashtable.Add("2", "or");
            //hashtable.Add("3", "not");
            //hashtable.Add("4", "to");
            //hashtable.Add("5", "be");
            //Console.WriteLine("\nShowing Value using Key using Get Method");
            //Console.WriteLine($"{hashtable.Get("3")}"); 

            MyMapNode<string, int> hashtable = new MyMapNode<string, int>(5);
            string input = "Paranoids are are not paranoid because they are paranoid but because they \n               keep putting themselves deliberately into paranoid avoidable situations\n";
            Console.WriteLine($"Statement is:- {input}");
            try
            {
                string[] inputArray = input.Split(); 

                foreach (string word in inputArray) 
                {
                    if (hashtable.get(word) == 0)
                    {
                        hashtable.Add(word, 1); 
                    }
                    else
                    {
                        int value = hashtable.get(word) + 1; 
                        hashtable.Set(word, value); 
                    }
                }
                string[] newInputArray = inputArray.Distinct().ToArray(); 
                foreach (var word in newInputArray)
                {
                    Console.WriteLine("Frequency of Word ccurrence :- \"" + word + "\" is :- " + hashtable.get(word)); 
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }
    }
}

   


