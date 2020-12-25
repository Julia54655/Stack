using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp21
{ 
    class Program
    {    public class Node<T>
        {
           public T Data;
          public  Node<T> Next;
            public Node(T data)
            {
                Data = data;
            }
        }

        public class Stack<T> : IEnumerable<T>
        {
            Node<T> head;
            int count;

            public bool IsEmpty
            {
                get { return count == 0; }

            }
            public int Count
            {
                get { return count; }
            }

            //добавление
            public void Push(T data)
            {
                Node<T> node = new Node<T>(data);
                node.Next = head;
                head = node;
                count++;

            }

            //удаление
            public void Pop()
            {
                if (IsEmpty)
                {
                    throw new  InvalidOperationException();
                }
                head = head.Next;
                count--;

            }

            IEnumerator<T> IEnumerable<T>.GetEnumerator()
            {
                Node<T> current = head;
                while (current != null)
                {
                    yield return current.Data;
                    current = current.Next;
                }
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return ((IEnumerable)this).GetEnumerator();
            }
        }

        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            foreach(var i in stack)
            {
                Console.WriteLine(i);
            }

            stack.Pop();
            foreach (var i in stack)
            {
                Console.WriteLine(i);
            }

            Console.ReadKey();
        }
    }
}
