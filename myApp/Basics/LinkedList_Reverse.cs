using System;

namespace LinkedList_Reverse
{
    public class Node
    {
        public Node right;
        public int value;
        public Node(int value)
        {
            this.value=value;
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
            //head.right=newnode;
            head=newnode;
        }

        public void Pop()
        {
            head=head.right;
        }

        public void RotateIterative()
        {
            Node current=head;
            Node prev=null;
            Node next=null;
            while(current!=null)
            {
                next=current.right;
                current.right=prev;
                prev=current;
                current=next;
            }
            head=prev;
        }

        public Node RotateRecursive(Node curr,Node prev)
        {
            if(curr.right==null)
            {
                head=curr;
                curr.right=prev;
                return head;
            }

            Node next=curr.right;
            curr.right=prev;
            RotateRecursive(next,curr);
            return head;
        }
        public void Display()
        {
            Node current=head;
            while(current!=null)
            {
                Console.Write("{0}-->",current.value);
                current=current.right;
            }
            Console.Write("END\n");
        }
    }

    public class Program
    {
        public static void MainRun(string[] cmdargs)
        {
            LinkedList llist=new LinkedList();
            
            //Add elements to linked list
            llist.Push(10);
            llist.Push(30);
            llist.Push(45);
            llist.Push(56);

            //Pop the head and move to the next node
            //llist.Pop();

            //Display linked list
            llist.Display();

            //llist.RotateIterative();

            llist.RotateRecursive(llist.head,null);
            llist.Display();
        }
    }
}