using System;

namespace LinkedList_Addition
{
    public class Node
    {
        public int value;
        public Node right;
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
            if (head==null)
            {
                head=new Node(value);
                return;
            }
            Node newnode=new Node(value);
            newnode.right=head;
            head=newnode;
            return;
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

        public string ConvertToSequence()
        {
            Node current=head;
            string result="";

            while(current!=null)
            {
                result=Convert.ToString(current.value)+result;
                current=current.right;
            }
            return result;
        }

        public void Reverse()
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
    }

    public class Program
    {
        public static void MainRun(string[] cmdargs)
        {
            LinkedList llist1=new LinkedList();
            llist1.Push(4);
            llist1.Push(6);
            llist1.Push(2);
            Console.WriteLine("First linked list:");
            llist1.Display();

            LinkedList llist2=new LinkedList();
            llist2.Push(4);
            llist2.Push(6);
            llist2.Push(3);
            Console.WriteLine("Second linked list:");
            llist2.Display();

            //Convert list1 to sequence of number
            var seq1=llist1.ConvertToSequence();
            var seq2=llist2.ConvertToSequence();
            Console.WriteLine("Linked list 1 sequence: {0}",seq1);
            Console.WriteLine("Linked list 2 sequence: {0}",seq2);
            var seq3=(Convert.ToInt32(seq1)+Convert.ToInt32(seq2));

            LinkedList llist3=new LinkedList();
            Console.WriteLine("Linked list 3 resulting sequence: {0}",seq3);

            while(seq3>0)
            {
                llist3.Push(seq3%10);
                seq3=seq3/10;
            }

            Console.WriteLine("Resulting linked list:");
            //llist3.Reverse();
            llist3.Display();

        }
    }
}