using System;

/*
 * Реализовать бинарное дерево: заполнение, поиск, удаление элемента - без использования стандартных деревьев
 */

namespace Task2 {
    public enum NodePosition {
        Left,
        Right,
        Center
    }

    public class Node {
        public Node Left { get; set; }
        public Node Right { get; set; }
        public int Data { get; set; }

        public Node(int data) {
            Data = data;
        }

        private void PrintValue(string value, NodePosition nodePostion) {
            switch (nodePostion) {
                case NodePosition.Left:
                    PrintLeftValue(value);
                    break;
                case NodePosition.Right:
                    PrintRightValue(value);
                    break;
                case NodePosition.Center:
                    Console.WriteLine(value);
                    break;
                default:
                    throw new NotImplementedException();
            }
        }

        private void PrintLeftValue(string value) {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("L:");
            Console.ForegroundColor = (value == "-") ? ConsoleColor.Red : ConsoleColor.Gray;
            Console.WriteLine(value);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        private void PrintRightValue(string value) {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("R:");
            Console.ForegroundColor = (value == "-") ? ConsoleColor.Red : ConsoleColor.Gray;
            Console.WriteLine(value);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public void PrintPretty(string indent, NodePosition nodePosition, bool last, bool empty) {

            Console.Write(indent);
            if (last) {
                Console.Write("└─");
                indent += "  ";
            } else {
                Console.Write("├─");
                indent += "| ";
            }

            var stringValue = empty ? "-" : Data.ToString();
            PrintValue(stringValue, nodePosition);

            if (!empty && (this.Left != null || this.Right != null)) {
                if (this.Left != null)
                    this.Left.PrintPretty(indent, NodePosition.Left, false, false);
                else
                    PrintPretty(indent, NodePosition.Left, false, true);

                if (this.Right != null)
                    this.Right.PrintPretty(indent, NodePosition.Right, true, false);
                else
                    PrintPretty(indent, NodePosition.Right, true, true);
            }
        }
    }

    public class BinaryTree {
        public Node Root { get; set; }

        // Вставка
        public void Insert(int value) {
            this.Root = this.Insert(this.Root, value);
        }

        private Node Insert(Node root, int value) {
            if (root == null) {
                Node node = new Node(value);
                return node;
            } else if (value < root.Data)
                root.Left = Insert(root.Left, value);
            else if (value > root.Data)
                root.Right = Insert(root.Right, value);
            return root;
        }

        public Node Find(int value) {
            return this.Find(value, this.Root);
        }

        public void Remove(int value) {
            Root = this.Remove(this.Root, value);
        }

        private Node Remove(Node parent, int key) {
            if (parent == null) return parent;

            if (key < parent.Data) parent.Left = Remove(parent.Left, key);
            else if (key > parent.Data)
                parent.Right = Remove(parent.Right, key);
            else {
                if (parent.Left == null)
                    return parent.Right;
                else if (parent.Right == null)
                    return parent.Left;

                parent.Data = MinValue(parent.Right);

                parent.Right = Remove(parent.Right, parent.Data);
            }

            return parent;
        }

        private int MinValue(Node node) {
            int minv = node.Data;

            while (node.Left != null) {
                minv = node.Left.Data;
                node = node.Left;
            }

            return minv;
        }

        private Node Find(int value, Node parent) {
            if (parent != null) {
                if (value == parent.Data) return parent;
                if (value < parent.Data)
                    return Find(value, parent.Left);
                else
                    return Find(value, parent.Right);
            }

            return null;
        }

        public void Print() {
            if (Root != null)
                Root.PrintPretty("", NodePosition.Center, true, false);
            else
                Console.WriteLine("Empty tree");
        }


    }

    class Program {
        static void Main(string[] args) {
            BinaryTree binaryTree = new BinaryTree();

            binaryTree.Insert(8);
            binaryTree.Insert(3);
            binaryTree.Insert(10);
            binaryTree.Insert(1);
            binaryTree.Insert(6);
            binaryTree.Insert(4);
            binaryTree.Insert(7);
            binaryTree.Insert(14);
            binaryTree.Insert(13);
            binaryTree.Insert(15);

            binaryTree.Print();

            Console.WriteLine("Найдем узел со значением 15");
            Node node = binaryTree.Find(15);
            Console.WriteLine("Найдем значение заданного узла: " + node.Data);


            Console.WriteLine("\nУдалим элемент со значением 8");
            binaryTree.Remove(8);
            binaryTree.Print();

            Console.WriteLine("Удалим элемент со значением 1");
            binaryTree.Remove(1);
            binaryTree.Print();

        }
    }
}
