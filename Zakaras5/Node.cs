/********************************************************************
*** NAME : Spencer Zakaras***
*** CLASS : CSc 346 ***
*** ASSIGNMENT : 5 ***
*** DUE DATE : 4/19/23***
*** INSTRUCTOR : GAMRADT ***
*********************************************************************
*** DESCRIPTION : This assignment is to create & test a series of classes relating to node objects & preforming depth first and breath first searches ***
********************************************************************/

namespace GraphNS; //shared namespace

public class Node : Graph //public node class which has inheritence from the graph class
{
    //All Feilds & auto Properties
    public int Id { get; set; }

    public bool WasVisited { get; set; }

    public List<bool> AdjacentNodes { get; set; } = new List<bool>(); //definition of a list of booleans containing adjacency info of nodes

}