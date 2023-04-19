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

public interface ISearchAlgorithms //ISearchAlgorithms interface definition
{
    
    //stack & queue objects for search use later
    public Queue<Node> queue {set;get;}

    public Stack<Node> Stack {set;get;}

    /********************************************************************
    *** METHOD BreadthFS ***
    *********************************************************************
    *** DESCRIPTION : this method is the abstract definition of a breath first search algorithm method that takes a list of nodes and preforms a searh to traverse them & print them***
    *** INPUT ARGS : start ***
    *** OUTPUT ARGS : n/a ***
    *** IN/OUT ARGS : start ***
    *** RETURN : void ***
    ********************************************************************/
    public abstract void BreadthFS(int start);

    /********************************************************************
    *** METHOD DepthFS ***
    *********************************************************************
    *** DESCRIPTION : this method is the abstract definition of a depth first search algorithm method that takes a list of nodes and preforms a searh to traverse them & print them***
    *** INPUT ARGS : start ***
    *** OUTPUT ARGS : n/a ***
    *** IN/OUT ARGS : start ***
    *** RETURN : void ***
    ********************************************************************/
    public abstract void DepthFS(int start);
}