
//Graph represented with AdjacencyList
// public methods:
//          AddEdge(int v1, int v2)  to add edge between specific vertexes
//          GetEdges(int v)         to get all edges of specific vertex

public class GraphAdjacencyList
{
    private readonly int VertexCount;
    private readonly List<int>[] Adj;
    
    public GraphAdjacencyList(int n){
        VertexCount = n;
        Adj = new List<int>[VertexCount];
        for(int i=0; i < VertexCount; i++){
            Adj[i] = new List<int>();
        }
    }
    
    public void AddEdge(int v1, int v2){
        Adj[v1].Add(v2);
        Adj[v2].Add(v1);
    }
    
    public List<int> GetNeighbors(int v){
        return Adj[v];
    }
    
    public int GetVertexCount(){
        return VertexCount;
    }
}


//  O(n^2)
//  marked array used to show if vertex has already visited
//  edgeTo array contains path sequence e.g. edgeTo[2] = 3 
//  recursive
public class DepthFirstSearch
{
    private bool[] marked;
    private int[] edgeTo;
    private int rootVert;
    
    public DepthFirstSearch(GraphAdjacencyList graph, int rootVert){
        int vertexesCount = graph.GetVertexCount();
        marked = new bool[vertexesCount];
        edgeTo = new int[vertexesCount];
        this.rootVert = rootVert;
        DFS(graph, rootVert);
    }
    
    
    private void DFS(GraphAdjacencyList graph, int v){
        marked[v] = true;
        foreach(int w in graph.GetNeighbors(v)){
            if(!marked[w]){
                DFS(graph, w);
                edgeTo[w] = v;
            }
        }
    }
    
    public bool HasPathTo(int v){
        return marked[v];
    }
    
    public IEnumerable<int> GetPathTo(int v){
        if(!HasPathTo(v)){
            return null;
        }
        else{
            var stack = new Stack<int>();
            
            for(var i=v; i!= rootVert;i=edgeTo[i]){
                stack.Push(i);
            }
            stack.Push(rootVert);
            return stack;
        }       
    }       
}


// O(n+m)
// n - count of vertexes,
// m - count of edges,
// distTo array tells how many edges there is to v vertex stating from root vertex
public class BreadthFirstSearch
{
    public int[] edgeTo;
    public int[] distTo;
    public int rootVertex;
    
    public BreadthFirstSearch(GraphAdjacencyList graph, int root){
        int vertexesCount = graph.GetVertexCount();
        edgeTo = new int[vertexesCount];
        distTo = new int[vertexesCount];
                
        for(var i = 0; i < vertexesCount; i++){
            edgeTo[i] = -1;
            distTo[i] = -1;            
        }
        this.rootVertex = root;
        BFS(graph, root);
    }
    
    private void BFS(GraphAdjacencyList graph, int root){
        var queue = new Queue<int>();
        
        queue.Enqueue(root);
        distTo[root] = 0;
        
        while(queue.Count != 0){
            int v = queue.Dequeue();
            
            foreach(var w in graph.GetNeighbors(v)){
                if(distTo[w] == -1){
                    queue.Enqueue(w);
                    distTo[w] = distTo[v]+1;
                    edgeTo[w] = v;
                }
            }
        }
    } 

     public IEnumerable<int> GetPathTo(int v){
        if(!HasPathTo(v)){
            return null;
        }
        else{
            var stack = new Stack<int>();
            
            for(int i=v; i!=rootVert; i=edgeTo[i]){
                stack.Push(i);
            }
            stack.Push(rootVert);
            return stack;
        }       
    }   
}
