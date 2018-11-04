using System;
using System.Collections.Generic;
using System.Linq;

namespace BST
{
    public class Node
    {
        public Node left;
        public Node right;
        public int value;
        public Node(int data)
        {
            this.value=data;
            this.right=null;
            this.left=null;
        }

        public Node()
        {
            this.right=null;
            this.left=null;
        }
    }

    public class Trees
    {
        public Node root;

        public Trees(int data)
        {
            root=new Node(data);
        }

        public Trees()
        {
            root=new Node();
        }
        //Insert a Node
        public void Insert(int data)
        {
            if(root.value <= 0 )
            {
                root.value=data;
                return;
            }
            Node current=root;
            Node newNode=null;
            do{

            //Value is greater
            if(data > current.value)
            {
                if(current.right==null)
                {
                    newNode=new Node(data);
                    current.right=newNode;
                    return;
                }
                else
                {
                    current=current.right;
                    continue;
                }
            }

            //Value is lesser
            if(data < current.value)
            {
                if(current.left==null)
                {
                    newNode=new Node(data);
                    current.left=newNode;
                    return;
                }
                else
                {
                    current=current.left;
                    continue;
                }
            }

            }while(1==1);
            
        }
        //Traverse the tree
        public void TraversePreOrder(Node traverseNode)
        {
            if(traverseNode==null)
            {
                return;
            }
             Console.Write(traverseNode.value+ ", ");

            TraversePreOrder(traverseNode.left);
            TraversePreOrder(traverseNode.right);
        }

        public void TraversePostOrder(Node traverseNode)
        {
            if(traverseNode==null)
            {
                return;
            }
            TraversePostOrder(traverseNode.left);
            TraversePostOrder(traverseNode.right);
            Console.Write(traverseNode.value+ ", ");

        }

        public void TraverseInOrder(Node traverseNode)
        {
            
            if(traverseNode==null)
            {
                return;
            }
            TraverseInOrder(traverseNode.left);
            Console.Write(traverseNode.value+ ", ");
            TraverseInOrder(traverseNode.right);
        }
    } 

    public class BST
    {
        public static void Program()
        {
            Trees tree =new Trees(10);

            //Add values
            tree.Insert(20);
            tree.Insert(50);
            tree.Insert(3);
            tree.Insert(89);
            tree.Insert(15);

            //Traverse a node-All three modes
            Console.WriteLine("Pre Order Traversal");
            tree.TraversePreOrder(tree.root);
            Console.WriteLine("Post Order Traversal");
            tree.TraversePostOrder(tree.root);
            Console.WriteLine("In Order Traversal");
            tree.TraverseInOrder(tree.root);
        }
    }
}