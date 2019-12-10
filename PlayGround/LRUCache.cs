using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace PlayGround
{
    class LRUCacheProgram
    {
        public static void Main()
        {
            Console.WriteLine("LRU Cache");

            var cache = LRUCache<int, int>.Instance;

            for (int i = 0; i < 16; i++)
            {
                cache.Put(i, i);
            }
            cache.Display();
            var get = cache.Get(15);
            Console.WriteLine("Get " + get);
            get = cache.Get(5);
            Console.WriteLine("Get " + get);
            cache.Display();

            cache.Put(16, 16);
            cache.Display();

            Console.ReadLine();
        }
    }

    class KVNode<K, V>
    {
        public K Key { get; }

        public V Value { get; set; }

        public KVNode<K, V> Next { get; set; }
        public KVNode<K, V> Previous { get; set; }

        public KVNode(K key, V value)
        {
            this.Key = key;
            this.Value = value;

            this.Next = this.Previous = null;
        }
    }
    sealed class LRUCache<K, V>
    {
        private static readonly Lazy<LRUCache<K, V>> lazy = new Lazy<LRUCache<K, V>>(() => new LRUCache<K, V>());
        private static Dictionary<K, KVNode<K, V>> map;
        private KVNode<K, V> front = null;
        private KVNode<K, V> back = null;
        int capacity = 0;
        readonly int max_capacity;

        private LRUCache()
        {
            map = new Dictionary<K, KVNode<K, V>>();
            max_capacity = 16;
        }

        public static LRUCache<K, V> Instance
        {
            get
            {
                return lazy.Value;
            }
        }

        public V Get(K key)
        {
            if (map.ContainsKey(key))
            {
                MoveFront(key);
                return map[key].Value;
            }
            else
            {
                return default(V);
            }
        }

        public void Put(K key, V value)
        {
            if (map.ContainsKey(key))
            {
                var val = map[key];
                val.Value = value;
            }
            else
            {
                Add(key, value);
            }
        }

        public void Display()
        {
            var str = string.Empty;
            var temp = front;
            while (temp != null)
            {
                str += temp.Value + "-";
                temp = temp.Next;
            }

            str = str.Substring(0, str.Length - 1);
            Console.WriteLine(str);
        }

        private void Add(K key, V value)
        {
            var node = new KVNode<K, V>(key, value);
            capacity++;
            if (front == null && back == null)
            {
                front = back = node;
                map[key] = node;
            }
            else
            {
                if (capacity > max_capacity)
                {
                    Remove();
                }

                map[key] = node;
                back.Next = node;
                node.Previous = back;
                back = node;

                //based on requirement new node can be added at front or back
                //node.Next = front;
                //front.Previous = node;
                //front = node;
            }
        }

        private void MoveFront(K key)
        {
            var node = map[key];

            if (node == front)
            {
                return;
            }
            else
            {
                var prev = node.Previous;
                var next = node.Next;
                prev.Next = next;
                if (next != null)
                {
                    next.Previous = prev;
                }
                else
                {
                    //last node 
                    back = prev;
                }

                //make front
                node.Previous = null;
                node.Next = front;
                front.Previous = node;
                front = node;
            }
        }

        private void Remove()
        {
            if (back != null)
            {
                var temp = back.Previous;
                temp.Next = null;
                back = temp;

                capacity--;
            }
        }
    }
}
