using System;

namespace LinkedListMiddle
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

        public void MiddleElement()
        {
            Node next=head;
            Node skipnext=head;
            while (skipnext!=null && skipnext.right!=null)
            {
                next=next.right;
                skipnext=skipnext.right.right;
            }
            Console.WriteLine("Middle element->{0}",next.value);
        }

        public void DeleteMiddle()
        {
            Node next=head;
            Node skipnext=head;
            Node prev=head;
            while (skipnext!=null && skipnext.right!=null)
            {
                next=next.right;
                skipnext=skipnext.right.right;
                if(next!=head.right) prev=prev.right;
            }
            prev.right=next.right;
        }

        public void RemoveDups()
        {
            Node a=head;
            Node b=head;
            while (b.right!=null)
            {
                b=b.right;
                if(a.value==b.value)
                {
                    a.right=b.right;
                    //b=b.right;
                }
                else
                {
                    a=a.right;
                    //b=b.right;
                }
            }
        }

        public void Reverse()
        {
            Node curr=head;
            while(curr!=null)
            {
                head.right=curr.right;
                curr.right=head;
                head=curr;
                curr=curr.right.right;
            }
        }
    }

    public class Program
    {
        public static void MainRun(string[] values)
        {
            LinkedList linklist=new LinkedList();
            linklist.Push(9);
            linklist.Push(6);
            linklist.Push(6);
            linklist.Push(5);
            linklist.Push(1);
            linklist.Push(1);
            linklist.Display();
            // linklist.MiddleElement();
            // linklist.DeleteMiddle();
            // Console.WriteLine("Middle item deleted and list as follows");
            // linklist.Display();
            //linklist.RemoveDups();
            //linklist.Display();
            linklist.Reverse();
            linklist.Display();
        }
    }
}