   /********************************************************************
    *** METHOD ResetVisitedSet ***
    *********************************************************************
    *** DESCRIPTION : this method takes the list of nodes and sets all visited bool charecteristics to false***
    *** INPUT ARGS : n/a ***
    *** OUTPUT ARGS : n/a ***
    *** IN/OUT ARGS : n/a ***
    *** RETURN : n/a ***
    ********************************************************************/

using GraphNS; //use shared namespace

Graph graph = new Graph(@"C:\Users\SZak1\OneDrive\Desktop\Assign5JsonData.json"); //create test object with test file

graph.BreadthFS(0); //test breadth first
graph.DepthFS(0); //test depth first