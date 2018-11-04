using System;
using System.Collections;
using System.Collections.Generic;

namespace LCA_BST
{
    public class Node
    {
        public int value;
        public Node left;
        public Node right;
        public Node(int value)
        {
            this.value=value;
            this.left=this.right=null;
        }
    }

    public class BST
    {
        public Node head;
        public Node Insert(int value,Node root)
        {
            if(root==null)
            {
                root=new Node(value);
            }
            else if (value<root.value)
            {
                root.left=Insert(value,root.left);
            }
            else
            {
                root.right=Insert(value,root.right);
            }
            return root;
        }

        public void  Display(Node root)
        {
            //Pre order traversal
            if (root==null) return; 
            Display(root.left);
            Console.WriteLine(root.value);
            Display(root.right);
        }

        // public void BSTtoDLL(Node root)
        // {
        //     if (root==null) return;
        //     BSTtoDLL(root.right);
        //     root.right=head;
        //     if(head!=null) head.left=root;
        //     head=root;
        //     BSTtoDLL(root.left);
        // }

        // public void DisplayDLL()
        // {
        //     Node current=head;
        //     while(current!=null)
        //     {
        //         Console.Write("{0}<->",current.value);
        //         current=current.right;
        //     }
        //     Console.Write("END");
        // }

        public Node LCA(Node root,int n1,int n2)
        {
            if (root==null) return null;

            if(root.value==n1||root.value==n2) return root;

            Node left_node=LCA(root.left,n1,n2);
            Node right_node=LCA(root.right,n1,n2);

            if(left_node!=null &&  right_node!=null)
                return root;
            
            return (left_node!=null)?left_node:right_node;
        }

        public int LCA_Main(Node root,int n1,int n2)
        {
            Node result=LCA(root,n1,n2);
            return result.value;
        }

    }

    public class Program
    {
        public static void MainRun(string[] cmdargs)
        {
            BST tree=new BST();
            Node root=null;
            root=tree.Insert(10,root);
            root=tree.Insert(5,root);
            root=tree.Insert(78,root);
            root=tree.Insert(4,root);
            root=tree.Insert(55,root);
            root=tree.Insert(1,root);
            root=tree.Insert(67,root);
            Console.WriteLine("Tree values:");
            tree.Display(root);
            // tree.BSTtoDLL(root);
            // Console.WriteLine("DLL values:");
            // tree.DisplayDLL();
            Console.WriteLine("LCA({0},{1}): {2}",55,67,tree.LCA_Main(root,55,67));
            Console.WriteLine("LCA({0},{1}): {2}",5,78,tree.LCA_Main(root,5,78));
            Console.WriteLine("LCA({0},{1}): {2}",4,1,tree.LCA_Main(root,4,1));
        }
    }
}