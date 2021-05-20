using System;
using System.Collections;
using System.Collections.Generic;

/*
 * Реализовать связный список: создание, удаление, добавление произвольных элементов,
 * реверс списка - без использования стандартных коллекций/LINQ (только IEnumerable)
 *
 */
namespace Task1 {
    public class Node<T> {
        public T Data { get; set; }
        public Node<T> Next { get; set; }

        public Node(T data) {
            Data = data;
        }
    }

    public class LinkedList<T> : IEnumerable<T> {

        public IEnumerator<T> GetEnumerator() {
            Node<T> current = first;
            while (current != null) {
                yield return current.Data;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return this.GetEnumerator();
        }

        private Node<T> first;
        private Node<T> last;
        private int length;

        // Добавление в конец списка
        public void AddLast(T data) {
            Node<T> node = new Node<T>(data);

            if (first == null) {
                first = node;
            } else {
                last.Next = node;
            }

            last = node;
            length++;
        }

        // Создание списка
        public void Create(params T[] p) {
            this.Delete();
            this.AddLast(p);
        }

        // Добавление нескольких элементов в конец списка
        public void AddLast(params T[] p) {
            foreach (var el in p) {
                this.AddLast(el);
            }
        }

        // Удаление всех элементов из списка
        public void Delete() {
            first = null;
            last = null;
            length = 0;
        }

        // Добавление в начало списка
        public void AddFirst(T data) {
            Node<T> node = new Node<T>(data);
            node.Next = first;
            first = node;

            if (length == 0) {
                last = first;
            }

            length++;
        }

        // Добавление по указанной позицию
        public bool Add(T data, int pos) {
            if (pos < 0 || pos > length)
                return false;
            else if (pos == 0)
                this.AddFirst(data);
            else if (pos == length)
                this.AddLast(data);
            else {
                Node<T> node = new Node<T>(data);
                Node<T> curr = first;
                Node<T> prev = null;

                for (int i = 0; i < pos; i++) {
                    prev = curr;
                    curr = curr.Next;
                }

                prev.Next = node;
                node.Next = curr;
                length++;

            }

            return true;
        }

        // Удаление первого элемента с указанными данными
        public bool RemoveData(T data) {
            Node<T> curr = first;
            Node<T> prev = null;

            while (curr != null) {
                if (curr.Data.Equals(data)) {
                    if (prev != null) {
                        prev.Next = curr.Next;
                        if (curr.Next == null)
                            last = prev;
                    } else {
                        first = first.Next;
                        if (first == null)
                            last = null;
                    }

                    length--;
                    return true;
                }

                prev = curr;
                curr = curr.Next;
            }

            return false;
        }

        // Удаление элемента по указанной позиции
        public bool RemovePos(int pos) {
            if (pos < 0 || pos > length - 1) {
                return false;
            } else {
                Node<T> curr = first;
                Node<T> prev = null;

                for (int i = 0; i < pos; i++) {
                    prev = curr;
                    curr = curr.Next;
                }

                if (prev != null) {
                    prev.Next = curr.Next;
                    if (curr.Next == null)
                        last = prev;
                } else {
                    first = first.Next;
                    if (first == null)
                        last = null;
                }

                length--;
                return true;
            }


        }

        // Реверс списка
        public void Reverse() {

            if (first != null) {
                Node<T> curr = first.Next;
                Node<T> prev = first;

                first.Next = null;
                last = first;

                while (curr != null) {
                    Node<T> next = curr.Next;
                    curr.Next = prev;
                    prev = curr;
                    curr = next;
                }

                first = prev;
            }



        }

    }

    class Program {
        static void Main(string[] args) {
            LinkedList<int> linkedList = new LinkedList<int>();

            linkedList.AddFirst(1);
            linkedList.AddLast(2);
            linkedList.AddLast(3);
            linkedList.AddLast(4);
            linkedList.AddLast(5);
            foreach (var el in linkedList) {
                Console.Write(el + " ");
            }
            Console.WriteLine("\n");

            linkedList.Create(1, 2, 3, 4, 5);
            foreach (var el in linkedList) {
                Console.Write(el + " ");
            }
            Console.WriteLine("\n");


            linkedList.AddFirst(6);
            linkedList.AddFirst(7);
            linkedList.AddLast(8);
            foreach (var el in linkedList) {
                Console.Write(el + " ");
            }
            Console.WriteLine("\n");


            linkedList.Add(9, 0);
            foreach (var el in linkedList) {
                Console.Write(el + " ");
            }
            Console.WriteLine("\n");
            linkedList.Add(10, 9);
            foreach (var el in linkedList) {
                Console.Write(el + " ");
            }
            Console.WriteLine("\n");
            linkedList.Add(11, 9);
            foreach (var el in linkedList) {
                Console.Write(el + " ");
            }
            Console.WriteLine("\n");

            linkedList.Reverse();
            foreach (var el in linkedList) {
                Console.Write(el + " ");
            }
            Console.WriteLine("\n");


            linkedList.AddFirst(20);
            linkedList.AddLast(30);
            foreach (var el in linkedList) {
                Console.Write(el + " ");
            }
            Console.WriteLine("\n");

            linkedList.RemoveData(30);
            foreach (var el in linkedList) {
                Console.Write(el + " ");
            }
            Console.WriteLine("\n");
            linkedList.RemoveData(20);
            foreach (var el in linkedList) {
                Console.Write(el + " ");
            }
            Console.WriteLine("\n");
            linkedList.RemoveData(4);
            foreach (var el in linkedList) {
                Console.Write(el + " ");
            }
            Console.WriteLine("\n");

            linkedList.RemovePos(0);
            foreach (var el in linkedList) {
                Console.Write(el + " ");
            }
            Console.WriteLine("\n");
            linkedList.RemovePos(8);
            foreach (var el in linkedList) {
                Console.Write(el + " ");
            }
            Console.WriteLine("\n");
            linkedList.RemovePos(3);
            foreach (var el in linkedList) {
                Console.Write(el + " ");
            }
            Console.WriteLine("\n");

            linkedList.AddFirst(20);
            linkedList.AddLast(30);
            linkedList.Add(40, 1);
            foreach (var el in linkedList) {
                Console.Write(el + " ");
            }
            Console.WriteLine("\n");

        }
    }
}
