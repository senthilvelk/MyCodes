using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace MyLinkedList
{
    public class Node
    {
        public string value;
        public Node nextNode;
        public Node(string value)
            {
                this.value=value;
                this.nextNode=null;
            }
    }

    public class MyLinkedList
    {
        public Node head;
        public void AddItem(string value)
        {
            if (head==null)
            {
                head=new Node(value);
                return;
            }
            
            Node current=head;
            Node newNode=new Node(value);
            newNode.nextNode=null;
            while(current.nextNode!=null)
            {
                current=current.nextNode;
            }
            current.nextNode=newNode;
        }

        public void Display()
        {
            if (head!=null)
            {
                Node current = head;
                while(current.nextNode!=null)
                {
                    Console.Write("{0}-->",current.value);
                    current=current.nextNode;
                }
                Console.Write("{0}-->",current.value);
                Console.Write("NULL\n");
            }
            
        }
    }
    class Program
    {
        public static void MainRun(string[] args)
        {
            //LinkedListGenerics();
            MyLinkedList llist=new MyLinkedList();
            for(int i=1;i<=5;i++)
            {
                llist.AddItem("one");
                llist.AddItem("two");
                llist.AddItem("three");
                llist.AddItem("four");
            }
            llist.Display();
        }

        static void LinkedListGenerics()
        {
            LinkedList<string> llist=new LinkedList<string>();
            var s1=Stopwatch.StartNew();
            llist.AddLast("two");
            llist.AddLast("three");
            llist.AddFirst("one");
            llist.Remove("two");
            LinkedListNode<string> node=llist.Find("three");
            llist.AddBefore(node,"two");
            foreach(string content in llist)
            {
                Console.WriteLine("value: {0}",content);
            }
            s1.Stop();
            Console.WriteLine(s1.ElapsedMilliseconds/1000);
        }
    }
}