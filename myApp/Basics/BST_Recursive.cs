using System;

namespace MyApp
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

    public class BinaryTrees
    {
        public Node root;
        public Node Insert(Node root,int value)
        {
            if (root==null)
            {
                root=new Node(value);
                //root.value=value;
            }
            else if(value<root.value)
            {
                root.left=Insert(root.left,value);
            }
            else
            {
                root.right=Insert(root.right,value);
            }
            return root;
        }

        public void Traverse(Node root)
        {
            if (root==null) 
            {
                return;
            }
            else 
            {
                Console.WriteLine("Value: {0}",root.value);
            }
            Traverse(root.left);
            Traverse(root.right);
        }
    }
    class Program
    {
        //static void Main(string[] args)
        public Program()
        {
            Node root=null;
            BinaryTrees tree=new BinaryTrees();
            root=tree.Insert(root,20);
            root=tree.Insert(root,60);
            root=tree.Insert(root,10);
            root=tree.Insert(root,40);
            root=tree.Insert(root,90);
            root=tree.Insert(root,3);

            tree.Traverse(root);
        }
    }
}
