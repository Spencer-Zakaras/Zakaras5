/********************************************************************
*** NAME : Spencer Zakaras***
*** CLASS : CSc 346 ***
*** ASSIGNMENT : 5 ***
*** DUE DATE : 4/19/23***
*** INSTRUCTOR : GAMRADT ***
*********************************************************************
*** DESCRIPTION : This assignment is to create & test a series of classes relating to node objects & preforming depth first and breath first searches ***
********************************************************************/

namespace GraphNS;//shared namespace

public interface IProcessData //IprocessData interface definition
{

    /********************************************************************
    *** METHOD ReadData ***
    *********************************************************************
    *** DESCRIPTION : this method is the abstract definition of a read data method that reads in data from a file and serializes it using json into a list***
    *** INPUT ARGS : path ***
    *** OUTPUT ARGS : n/a ***
    *** IN/OUT ARGS : path ***
    *** RETURN : void ***
    ********************************************************************/
    public abstract void ReadData(string path);
}