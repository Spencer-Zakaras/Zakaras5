/********************************************************************
*** NAME : Spencer Zakaras***
*** CLASS : CSc 346 ***
*** ASSIGNMENT : 5 ***
*** DUE DATE : 4/19/23***
*** INSTRUCTOR : GAMRADT ***
*********************************************************************
*** DESCRIPTION : This assignment is to create & test a series of classes relating to node objects & preforming depth first and breath first searches ***
********************************************************************/

using System.Text.Json; //json using statement
using System.Collections.Generic; //generic collection using statement
namespace GraphNS; //using shared namespace

public class Graph //graph public class definition
{
    private List<Node> _nodes = new List<Node>(); //private list of nodes to hold graph data

    /********************************************************************
    *** METHOD Graph ***
    *********************************************************************
    *** DESCRIPTION : this is the default constructor for the graph class ***
    *** INPUT ARGS : n/a ***
    *** OUTPUT ARGS : n/a ***
    *** IN/OUT ARGS : n/a ***
    *** RETURN : n/a ***
    ********************************************************************/
    public Graph()
    {
        
    }

    /********************************************************************
    *** METHOD Graph ***
    *********************************************************************
    *** DESCRIPTION : this is the parametered constructor for the graph class taking in a string to hold the data filepath***
    *** INPUT ARGS : path ***
    *** OUTPUT ARGS : n/a ***
    *** IN/OUT ARGS : path ***
    *** RETURN : n/a ***
    ********************************************************************/
    public Graph(string path)
    {
        ReadData(@path); //call read data with exact path
    }

    /********************************************************************
    *** METHOD ResetVisitedSet ***
    *********************************************************************
    *** DESCRIPTION : this method takes the list of nodes and sets all visited bool charecteristics to false***
    *** INPUT ARGS : n/a ***
    *** OUTPUT ARGS : n/a ***
    *** IN/OUT ARGS : n/a ***
    *** RETURN : n/a ***
    ********************************************************************/
    private void ResetVisitedSet()
    {
        foreach(Node NodeItem in _nodes) //run through list of nodes
        {
            NodeItem.WasVisited = false; //set each node.wasvisited to false
        }
    }

    /********************************************************************
    *** METHOD FindAdjacentUnvisitedNode ***
    *********************************************************************
    *** DESCRIPTION : This method finds all adjacent nodes in the adjacent nodes list & return the first one***
    *** INPUT ARGS : node ***
    *** OUTPUT ARGS : ***
    *** IN/OUT ARGS : node ***
    *** RETURN : Node?
    ********************************************************************/
    private Node? FindAdjacentUnvisitedNode(Node node)
    {
        for(int i = 0; i < node.AdjacentNodes.Count; i++) //loop through adjacency list
        {
            if(node.AdjacentNodes[i]) //check if proper index
            {
                if(!_nodes[i].WasVisited) //check if unvisited
                {
                    return _nodes[i]; //if all conditions met return adjacent node
                }
            }
        }

        Console.WriteLine("There are no further adjacent nodes that are unvisited.\n"); //else print out no further nodes to visit
        return null; //return null
    }

    /********************************************************************
    *** METHOD ViewNode ***
    *********************************************************************
    *** DESCRIPTION : This method takes in a node object and prints out it's Id***
    *** INPUT ARGS : node ***
    *** OUTPUT ARGS : ***
    *** IN/OUT ARGS : node ***
    *** RETURN : n/a
    ********************************************************************/
    private static void ViewNode(Node node)
    {
        Console.WriteLine("{0} ", node.Id); //print out specific node id
    }

    /********************************************************************
    *** METHOD ReadData ***
    *********************************************************************
    *** DESCRIPTION : this read data method reads in data from a file and serializes it using json into a list***
    *** INPUT ARGS : path ***
    *** OUTPUT ARGS : n/a ***
    *** IN/OUT ARGS : path ***
    *** RETURN : void ***
    ********************************************************************/
    public void ReadData(string path)
    {
        try //try block to catch exceptions
        {
            var graphJsonData = File.ReadAllText(@path); //read in data from file to temp var

            //Console.WriteLine("{0}\n", graphJsonData);

            _nodes = JsonSerializer.Deserialize<List<Node>>(graphJsonData)!; //serialize temp var into list

            //foreach(Node nodeitem in _nodes)
            //{
            //    Console.WriteLine("{0} NodeID", nodeitem.Id);
            //    Console.WriteLine("{0} NodeID", nodeitem.WasVisited);
            //    
            //}
        }        
        catch (ArgumentException e) when (!File.Exists(path)) //catch exception if filepath doesnt exist
        {
            Console.WriteLine($"EXCEPTION! File Path {0} Does Not Exist. {e.GetType().Name} \n", path); //prompt user with info
        }
        catch (ArgumentException e) //catch generic exception
        {
            Console.WriteLine($"EXCEPTION! {e.GetType().Name} - {e.Message} \n"); //prompt user with data
        }
        catch (JsonException) //catch generic json exception
        {
                        Console.WriteLine($"EXCEPTION! invalid JSON data\n"); //prompt user with error readout

        }
    }
    

    /********************************************************************
    *** METHOD BreadthFS ***
    *********************************************************************
    *** DESCRIPTION : this method is the definition of a breath first search algorithm method that takes a list of nodes and preforms a searh to traverse them & print them***
    *** INPUT ARGS : start ***
    *** OUTPUT ARGS : n/a ***
    *** IN/OUT ARGS : start ***
    *** RETURN : void ***
    ********************************************************************/
    public void BreadthFS(int start)
    {
        ResetVisitedSet(); //reset all visited values in list

        Node CurrentNode = _nodes[start]; //set start to current node
        CurrentNode.WasVisited = true; //set wasvisited of start to true
        Queue<Node> Queue = new Queue<Node>(); //instasiate previously declared queue

        Queue.Enqueue(CurrentNode); //enqueue start node

        while(Queue.Count > 0) //while queue not empty
        {
            CurrentNode = Queue.Dequeue(); //read in an depqueue node
            Console.WriteLine("{0}", CurrentNode.Id); //prompt with node Id
            
            for(int i = 0; i < CurrentNode.AdjacentNodes.Count; i++) //loop though adjacent nodes
            {
                if(CurrentNode.AdjacentNodes[i] && i < _nodes.Count && !_nodes[i].WasVisited)  //check if visited
                {
                        _nodes[i].WasVisited = true; //set wasvisited true for next visited node
                        Queue.Enqueue(_nodes[i]); //enqueue next visited
                }
            

            }
        }
        
    }


    /********************************************************************
    *** METHOD DepthFS ***
    *********************************************************************
    *** DESCRIPTION : this method is the definition of a depth first search algorithm method that takes a list of nodes and preforms a searh to traverse them & print them***
    *** INPUT ARGS : start ***
    *** OUTPUT ARGS : n/a ***
    *** IN/OUT ARGS : start ***
    *** RETURN : void ***
    ********************************************************************/
    public void DepthFS(int start)
    {
        ResetVisitedSet(); //reset all visited values in list

        Node CurrentNode = _nodes[start]; //set start to current node
        CurrentNode.WasVisited = true; //set wasvisited of start to true
        Stack<Node> Stack = new Stack<Node>(); //instasiate previously declared stack

        Stack.Push(CurrentNode); //push start node

        while(Stack.Count > 0) //while stack not empty
        {
            CurrentNode = Stack.Pop(); //pop current node
            Console.WriteLine("{0}", CurrentNode.Id); //prompt with node Id
            
            for(int i = CurrentNode.AdjacentNodes.Count - 1; i >= 0; i--) //work backward from list of adjacency
            {
                if(CurrentNode.AdjacentNodes[i] && i < _nodes.Count && !_nodes[i].WasVisited) //check if visited & valid node
                {
                        _nodes[i].WasVisited = true; //set wasvisited true
                        Stack.Push(_nodes[i]);  //push current node to stack
                }

            }
        }
        
    }
}