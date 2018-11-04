using System;

namespace LinkedListFlatten
{
    public class Node
    {
        public int value;
        public Node right;
        public Node(int value)
        {
            this.value=value;
            this.right=null;
        }
    }

    public class LinkedList
    {
        public Node head;
        public void Push(int value)
        {
            if(head==null)
            {
                head=new Node(value);
                return;
            }
            Node newnode=new Node(value);
            newnode.right=head;
            head=newnode;
        }

        public void Display()
        {
            Node curr=head;
            while(curr!=null)
            {
                Console.Write("{0}-->",curr.value);
                curr=curr.right;
            }
            Console.WriteLine("END");
        }

        public Node Merge(Node a,Node b)
        {
            if(a==null)  return b;
            if(b==null) return a;

            Node result;

            if(a.value<b.value)
            {
                result=a;
                result.right=Merge(a.right,b);
            }
            else
            {
                result=b;
                result.right=Merge(a,b.right);
            }
            return result;
        }
    }

    public class Program
    {
        public static void MainRun(string[] values)
        {
            LinkedList linklist1=new LinkedList();
            linklist1.Push(30);
            linklist1.Push(9);
            linklist1.Push(5);
            Console.WriteLine("Fist Linked list:");
            linklist1.Display();

            LinkedList linklist2=new LinkedList();
            linklist2.Push(21);
            linklist2.Push(20);
            linklist2.Push(4);
            Console.WriteLine("Second Linked List:");
            linklist2.Display();

            Console.WriteLine("Merged Linked list:");
            LinkedList result=new LinkedList();
            result.head=result.Merge(linklist1.head,linklist2.head);
            result.Display();
        }
    }
}