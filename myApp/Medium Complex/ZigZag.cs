// # Given a Balanced Binary Tree (BBT)
// # (non-sorted, non-search, containing non-duplicative elements)

//                    42
//                   /  \
//                  /    \
//                 /      \
//                /        \
//               81        99
//              /  \      /  \
//            17    1    25   19
//            / \   / \  / \ / \
//           8 -1  2  9 5  6 3  31

// and its familiar array representation:

// [42, 81, 99, 17, 1, 25, 19, 8, -1, 2, 9, 5, 6, 3, 31]

//even-zag
//odd-zig

// Write a function that will take any BBT array of integers
// (structured in the manner above), and an integer in that array,
// and return a list of "zigzag" directions to get to that destination,
// starting from the root.

// To go right, print "zig"
// To go left, print "zag"

// Example:

// tree = [42, 81, 99, 17, 1, 25, 19, 8, -1, 2, 9, 5, 6, 3, 31]

// zigzag_directions(tree, 42) -> []
// zigzag_directions(tree, 31) -> ['zig', 'zig', 'zig']
// zigzag_directions(tree, 1) -> ['zag', 'zig']
// zigzag_directions(tree, -1) -> ['zag', 'zag', 'zig']
// zigzag_directions(tree, 6) -> ['zig', 'zag', 'zig']
// zigzag_directions(tree, 100) -> None

// Bonus:
// Given a BBT array, and another array of "zigzag" directions,
// return the integer that it leads do.

// walk(tree, []) -> 42
// walk(tree, ['zig', 'zig', 'zig']) -> 31
// walk(tree, ['zag', 'zig']) -> 1
// walk(tree, ['zag', 'zag', 'zig']) -> -1
// walk(tree, ['zig', 'zag', 'zig']) -> 6
// walk(tree, ['zig', 'zig', 'zig', 'zig']) -> None

using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
namespace zigzag
{
  public class Program
  {
    // To go right, print "zig"
  // To go left, print "zag"

    public static void MainRun(string[] cmdArgs){
      int[] tree=new int[]{42, 81, 99, 17, 1, 25, 19, 8, -1, 2, 9, 5, 6, 3, 31};
      List<string> result=zigzag_direction(tree,31);
      Console.WriteLine("ZIGZAG direction:");
      foreach(string value in result)
      {
        Console.Write("{0}--",value);
      }
      Console.Write("Result\n");
      //Console.WriteLine("Walk direction:");
      //int value=walk(tree,new string("zig","zag","zig"));
      //Console.WriteLine(value);
      
    }
    
    //Time complexity: O(logn+k)
    //Space complexity: O(k)
    public static List<string> zigzag_direction(int[] tree,int searchElement)
    {
      List<string> result=new List<string>();
      int position=0,iter=0;
      //To determine the number of levels in the given tree
      int levels=(tree.Length-1)/4;
      //Iterate by level and from last
      for(int count=levels;count>0;count--) //Define the window
      {
        for(int item=(count*(count-1)+1);item<((count+1)*4)-1;item++)
        {
          if (tree[item]==searchElement) //search case
          {
            if(item%2==0) result.Add("zig");
            else result.Add("zag");
              position=item;
            iter++;
            break;
          }
          //To backtrack to the previous window
          if(position != 0)
          {
            if (position%2==0) result.Add("zig");
            else result.Add("zag");
            position=item+1;
            iter++;
            break;
          }
        }
      }
      
      //Reverse the output
      result.Reverse();
      return result;
    }
    
  }
}











