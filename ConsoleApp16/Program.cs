using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp16
{
    class Program
    {
        public class ListNode
        {
            public int key;
            public ListNode prev;
            public ListNode next;

            public ListNode(int key)
            {
                this.key = key;
            }

        }

        public class DoubleLinkNode
        {
            ListNode head;
            ListNode tail;
            int count;

            public void ListInsert(int key)
            {
                ListNode node = new ListNode(key);
                if (head == null)
                {
                    head = node;
                }
                else
                {
                    tail.next = node;
                    node.prev = tail;
                }
                tail = node;
                count++;
            }

            public ListNode SearchNode(int key)
            {
                ListNode currentNode = head;
                while (currentNode != null)
                {
                    if (currentNode.key == key)
                    {
                        return currentNode;
                    }
                    else
                    {
                        currentNode = currentNode.next;
                    }
                }
                return head;
            }

            public void ListDelete(int key)
            {
                ListNode node = new ListNode(key);
                ListNode currentNode;
                if (head == null && tail == null)
                {
                    throw new ArgumentException("Cписок пуст");
                }
                else
                {
                    currentNode = SearchNode(node.key);
                    if (currentNode != null)
                    {
                        if (currentNode.prev != null)
                        {
                            currentNode.prev.next = currentNode.next;
                        }
                        else
                        {
                            head = currentNode.next;
                            currentNode.next.prev = null;
                        }
                    }
                }
            }

            public void PrinNode(ListNode node)
            {
                string previous;
                string next;
                if (node.prev == null)
                {
                    previous = "null";
                }
                else
                {
                    previous = node.prev.key.ToString();
                }
                if (node.next == null)
                {
                    next = "null";
                }
                else
                {
                    next = node.next.key.ToString();
                }
                Console.WriteLine(previous + "-" + node.key + "-" + next);
            }

            public void PrintList()
            {
                var currentNode = head;
                while(currentNode != null)
                {
                    Console.Write(currentNode.key + "\t");
                    currentNode = currentNode.next;
                }
            }
        }

        static void Main(string[] args)
        {
            var myNode = new DoubleLinkNode();
            myNode.ListInsert(5);
            myNode.ListInsert(8);
            myNode.ListInsert(12);
            myNode.ListInsert(34);
            myNode.ListInsert(36);
            myNode.ListInsert(85);
            myNode.ListInsert(242);
            Console.WriteLine();
            myNode.ListDelete(5);
            myNode.ListDelete(8);
            myNode.PrintList();
            Console.WriteLine();
            myNode.ListDelete(5);
            myNode.PrintList();
            Console.ReadLine();
        }
    }
}
