
//Graph represented with AdjacencyList
// public methods:
//          AddEdge(int v1, int v2)  to add edge between specific vertexes
//          GetEdges(int v)         to get all edges of specific vertex

public class GraphAdjacencyList{
    private readonly int VertexCount;
    private readonly List<int>[] Adj;
    
    public GraphAdjacencyList(int n){
        VertexCount = n;
        Adj = new List<int>[VertexCount];
        for(int i=0; i<VertexCount; i++){
            Adj[i] = new List<int>();
        }
    }
    
    public void AddEdge(int v1, int v2){
        Adj[v1].Add(v2);
        Adj[v2].Add(v1);
    }
    
    public List<int> GetEdges(int v){
        return Adj[v];
    }    
}


