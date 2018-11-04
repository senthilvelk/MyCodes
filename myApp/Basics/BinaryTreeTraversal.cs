using System;
using System.Linq;

namespace BinaryTreeTraversal
{
    public class Node
    {
        public int value{get;set;}
        public Node left;
        public Node right;
        public Node(int value)
        {
            this.value=value;
            this.right=null;
            this.left=null;
        }

        public class BSTree
        {
            public Node rootNode;

            public Node Push(int value,Node root)
            {
                if (root==null) 
                {
                    root=new Node(value);
                    //return root;
                }
                else if(value < root.value)
                {
                    root.left=Push(value,root.left);
                }
                else //(value >=root.value)
                {
                    root.right=Push(value,root.right);
                }
                return root;
            }

            public void Traversal(Node root)
            {
                //This is preorder
                if (root ==null)
                   { return;}
                Traversal(root.left);
                Traversal(root.right);
                Console.WriteLine(root.value); 
            }

            public int MaxDepth(Node root)
            {
                if(root==null) return 0;
                int leftDepth=MaxDepth(root.left);
                int rightDept=MaxDepth(root.right);
                if(leftDepth>=rightDept)
                {
                    return (leftDepth+1);
                }
                else
                {
                    return (rightDept+1);
                }
            }

            public void TotalNodes(Node root,ref int count)
            {
                if (root==null) // Counts all nodes and ignores the invalid ones
                    return;
                if (root.left==null && root.right==null) //Counts internal nodes only, ie. with not atleast one child node
                    return;
                TotalNodes(root.left,ref count);
                TotalNodes(root.right,ref count);
                count=count+1;
            }
        }

        public class Program
        {
            public static void MainRun(string[] cmdargs)
            {
                BSTree tree=new BSTree();
                Node root=null;
                root=tree.Push(10,root);
                root=tree.Push(50,root);
                root=tree.Push(6,root);
                root=tree.Push(34,root);
                root=tree.Push(60,root);
                root=tree.Push(1,root);
                root=tree.Push(89,root);

                tree.Traversal(root);

                Console.WriteLine("Max depth: {0}",Convert.ToInt32(tree.MaxDepth(root)));

                int totnodes=0;
                tree.TotalNodes(root,ref totnodes);
                Console.WriteLine("Total nodes: {0}",totnodes);
            }
        }
    }
}