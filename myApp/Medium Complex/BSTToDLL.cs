using System;

namespace BSTToDLL
{
    public class Node
    {
        public int value;
        public Node left;
        public Node right;

        public Node(int value)
        {
            this.value=value;
            this.left=null;
            this.right=null;
        }
    }

    public class BST
    {
        public Node head;
        public Node Insert(Node root,int value)
        {
            if(root==null) 
            {
                root=new Node(value);
            }
            else if (value < root.value)
            {
                root.left=Insert(root.left,value);
            }
            else
            {
                root.right=Insert(root.right,value);
            }
            return root;
        }

        public void DisplayTree(Node root)
        {
            if (root==null) return;
            DisplayTree(root.left);
            Console.Write("{0}--",Convert.ToString(root.value));
            DisplayTree(root.right);
        }

         public void BToDLL(Node root) 
        {
            // Base cases
            if (root == null)
                return;
    
            // Recursively convert right subtree
            BToDLL(root.right);
    
            // insert root into DLL
            root.right = head;
    
            // Change left pointer of previous head 
            if (head != null)
                (head).left = root;
    
            // Change head of Doubly linked list
            head = root;
    
            // Recursively convert left subtree
            BToDLL(root.left);
        }

        public void DisplayDLL()
        {
            Node current=head;
            while(current !=null)
            {
                Console.Write("{0}<-->",current.value);
                current=current.right;
            }
            Console.Write("END");
        }

    }

    public class Program
    {
        public static void MainRun(string[] cmdargs)
        {
            BST tree=new BST();
            Node root=null;
            root=tree.Insert(root,10);
            root=tree.Insert(root,56);
            root=tree.Insert(root,2);
            root=tree.Insert(root,4);
            root=tree.Insert(root,89);
            root=tree.Insert(root,56);
            root=tree.Insert(root,9);

            Console.WriteLine("Values in Tree-Inorder traversal:");
            tree.DisplayTree(root);
            tree.BToDLL(root);
            Console.WriteLine("\nValues in DLL:");
            tree.DisplayDLL();

        }
    }
}