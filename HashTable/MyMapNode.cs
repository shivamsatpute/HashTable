using System;
using System.Collections.Generic;
using System.Text;

namespace HashTable
{
    class MyMapNode<K, V>
    {
        public struct KeyValue<k, v> 
        {
            public k Key { get; set; }
            public v Value { get; set; }
        }
        private readonly int size;
        private readonly LinkedList<KeyValue<K, V>>[] items; 
                                                            
        public MyMapNode(int size) 
        {
            this.size = size; 
            this.items = new LinkedList<KeyValue<K, V>>[size]; 
        }

        protected int GetArrayPosition(K key) 
        {                                   
            int hash = key.GetHashCode();                               
            int position = key.GetHashCode() % size;
            return Math.Abs(position); 

        }
        public V get(K key)
        {
            int position = GetArrayPosition(key);
            LinkedList<KeyValue<K, V>> linkedList = GetLinkedList(position);
            foreach (KeyValue<K, V> item in linkedList)
            {
                if (item.Key.Equals(key))
                {
                    return item.Value;
                }
            }
            return default(V);
        }
        protected LinkedList<KeyValue<K, V>> GetLinkedList(int position) 
        {

            LinkedList<KeyValue<K, V>> linkedList = items[position]; 

            if (linkedList == null) 
            {
                linkedList = new LinkedList<KeyValue<K, V>>(); 

                items[position] = linkedList;
            }

            return linkedList;
        }

        public void Add(K key, V value) 
        {
            int position = GetArrayPosition(key); 
            LinkedList<KeyValue<K, V>> linkedList = GetLinkedList(position); 
            KeyValue<K, V> item = new KeyValue<K, V> 
            { Key = key, Value = value }; 
            linkedList.AddLast(item); 
            Console.WriteLine($"{item.Key}   { item.Value}"); 

        }

        internal void Set(K key, V value) 
        {
            try
            {
                int position = GetArrayPosition(key);
                var linkedList = GetLinkedList(position); 
                KeyValue<K, V> temp = new KeyValue<K, V>();
                foreach (KeyValue<K, V> item in linkedList)
                {
                    if (item.Key.Equals(key))
                    {
                        temp = item;
                    }
                }
                temp.Value = value;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void Remove(K key)
        {
            try
            {
                int position = GetArrayPosition(key); 
                LinkedList<KeyValue<K, V>> linkedList = GetLinkedList(position); 
                bool itemFound = false;
                KeyValue<K, V> foundItem = default(KeyValue<K, V>);
                foreach (KeyValue<K, V> item in linkedList) 
                {
                    if (item.Key.Equals(key)) 
                    {
                        itemFound = true; 
                        foundItem = item;
                    }
                }
                if (itemFound)
                    linkedList.Remove(foundItem); 
                Console.WriteLine($"Successfully Remove Key {key} ");
                Display();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Display() 
        {
            try
            {
                Console.WriteLine("Frequency of Word and Count");
                foreach (var LinkedList in items) 
                {
                    if (LinkedList != null)
                    {
                        foreach (KeyValue<K, V> item in LinkedList) 
                        {
                            Console.WriteLine($"{item.Key}=> { item.Value}"); 
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
}



