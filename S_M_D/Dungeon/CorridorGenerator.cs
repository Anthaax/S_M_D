using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
namespace S_M_D.Dungeon
{

    [Serializable]
    public struct WeightedEdge
    {
        public Room Room1 { get; set; }
        public Room Room2 { get; set; }
        public double Weight { get; set; }

        public WeightedEdge(Room r1, Room r2, double weight)
        {
            this.Room1 = r1;
            this.Room2 = r2;
            this.Weight = weight;
        }    
    };

    public struct Edge
    {
        public Room Room1 { get; set; }
        public Room Room2 { get; set; }

        public Edge(Room r1, Room r2)
        {
            this.Room1 = r1;
            this.Room2 = r2;
        }
    };

    public class CorridorGenerator : ICorridorGenerator
    {

        /// <summary>
        /// Checks whether the edge formed by two given rooms is already in the given list of edges.
        /// </summary>
        /// <param name="edges">List of edges we will look through.</param>
        /// <param name="r1">First room of the tested edge.</param>
        /// <param name="r2">Second room of the tested edge.</param>
        /// <returns>True if the edge is already in the edges list, False otherwise.</returns>
        public bool edgeExists(List<WeightedEdge> edges, Room r1, Room r2)
        {
            for (int i = 0; i < edges.Count; i++)
            {
                WeightedEdge e = edges[i];
                if ((e.Room1 == r1 && e.Room2 == r2) || (e.Room1 == r2 && e.Room2 == r1))
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Connects every node of the graph (the rooms), creating a clique. The edges have a weight (distance between two rooms).
        /// </summary>
        /// <param name="rooms">Nodes of the graph.</param>
        /// <returns>List containing the edges of the graph.</returns>
        public List<WeightedEdge> connectEverySummit(List<Room> rooms)
        {
            List<WeightedEdge> edges = new List<WeightedEdge>();

            for (int i = 0; i < rooms.Count; i++)
            {
                for (int j = 0; j < rooms.Count; j++)
                {
                    if (i != j && !edgeExists(edges, rooms[i], rooms[j]))
                    {
                        float deltaX = rooms[i].Center.X - rooms[j].Center.X;
                        float deltaY = rooms[i].Center.Y - rooms[j].Center.Y;
                        edges.Add(new WeightedEdge(rooms[i], rooms[j], Math.Sqrt(((deltaX * deltaX) + (deltaY * deltaY)))));
                    }
                }
            }
            return edges;
        }

        /// <summary>
        /// Checks whether an edge is connected to an already visited node.
        /// </summary>
        /// <param name="visited">List of the visited nodes of the graph.</param>
        /// <param name="e">Edge we want to check.</param>
        /// <param name="r">Room we want to exclude from the check.</param>
        /// <returns>Returns true if the edge is connected to a visited node, false otherwise.</returns>
        public bool isConnectedToVisitedEdge(List<Room> visited, WeightedEdge e, Room r)
        {
            for (int i = 0; i < visited.Count; i++)
            {
                if (r != (visited[i])) // Excluding the current room
                {
                    if (e.Room1 == visited[i] || e.Room2 == visited[i])
                        return true;
                }
            }
            return false;
        }

        public List<Edge> primAlgorithm(List<Room> rooms, List<WeightedEdge> wEdges)
        {
            List<Edge> edges = new List<Edge>();
            List<Room> visited = new List<Room>();
            List<WeightedEdge> possibleEdges = new List<WeightedEdge>();
            visited.Add(rooms[0]);

            int lowestWeightIdx; double lowestWeight;
            while (visited.Count < rooms.Count)
            {
                // cleaning previous possible edges
                possibleEdges.Clear();
                // finding possible edges. A possible edge is an edge adjacent to one of the visited rooms
                // However, it mustn't be connected to another visited summit, otherwise we're going to visit the same room
                for (int i = 0; i < visited.Count; i++)
                {
                    Room r = visited[i];
                    for (int j = 0; j < wEdges.Count; j++)
                    {
                        WeightedEdge e = wEdges[j];
                        if ((e.Room1 == r || e.Room2 == r) && !isConnectedToVisitedEdge(visited, e, r))
                            possibleEdges.Add(e);
                    }
                }
                // now we select the edge with the lowest weight and add it to the final edge list
                lowestWeight = (possibleEdges[0]).Weight;
                lowestWeightIdx = 0;
                for (int i = 0; i < possibleEdges.Count; i++)
                {
                    if ((possibleEdges[i]).Weight < lowestWeight)
                    {
                        lowestWeight = (possibleEdges[i]).Weight;
                        lowestWeightIdx = i;
                    }
                }
                WeightedEdge selectedWEdge = (WeightedEdge)possibleEdges[lowestWeightIdx];
                edges.Add(new Edge(selectedWEdge.Room1, selectedWEdge.Room2));

                // adding the new room to the list of visited
                bool r1IsVisited = false;
                for (int i = 0; i < visited.Count; i++)
                {
                    if (selectedWEdge.Room1 == visited[i])
                        r1IsVisited = true;
                }
                if (r1IsVisited == true)
                    visited.Add(selectedWEdge.Room2);
                else
                    visited.Add(selectedWEdge.Room1);
            }
            return edges;
        }

        public void drawCorridors(Map map, List<Corridor> corridors)
        {
            bool insideRoom;
            List<Point> corridorHistory = new List<Point>();
            Point currentRoom;
            // now drawing the corridors
            for (int i = 0; i < corridors.Count; i++)
            {
                corridorHistory.Clear();
                insideRoom = true;
                Room startRoom;
                // drawing vertical lane
                int deltaY = corridors[i].Path[1].Y - corridors[i].Path[0].Y;
                startRoom = (Room)map.Grid[corridors[i].Path[0].Y, corridors[i].Path[0].X];

                currentRoom = new Point(corridors[i].Path[0].X, corridors[i].Path[0].Y);

                MapItem curItem = startRoom;
                if (deltaY < 0) // the corridor goes north
                {
                    while (deltaY < 0)
                    {
                        if (insideRoom == true)
                        {
                            if (map.Grid[currentRoom.Y - 1, currentRoom.X] != curItem)
                            {
                                insideRoom = false;
                            }
                        }
                        else
                        {
                            corridorHistory.Add(currentRoom);
                            if (map.Grid[currentRoom.Y, currentRoom.X] == null)
                            {
                                map.Grid[currentRoom.Y, currentRoom.X] = corridors[i];
                            }
                            else if (!map.Grid[currentRoom.Y, currentRoom.X].IsCorridor) // we're inside another room
                            {
                                insideRoom = true;
                                corridorHistory.Clear();
                            }
                            else if (map.Grid[currentRoom.Y, currentRoom.X].IsCorridor)
                            {
                                curItem = map.Grid[currentRoom.Y, currentRoom.X];
                                for (int k = 0; k < corridorHistory.Count; k++)
                                {
                                    map.Grid[corridorHistory[k].Y, corridorHistory[k].X] = curItem;
                                }
                            }
                        }
                        currentRoom.Y = currentRoom.Y - 1;
                        deltaY++;
                    }
                }
                else // the corridor goes south
                {
                    while (deltaY > 0)
                    {
                        if (insideRoom == true)
                        {
                            if (map.Grid[currentRoom.Y + 1, currentRoom.X] != curItem)
                            {
                                insideRoom = false;
                            }
                        }
                        else
                        {
                            corridorHistory.Add(currentRoom);
                            if (map.Grid[currentRoom.Y, currentRoom.X] == null)
                            {
                                map.Grid[currentRoom.Y, currentRoom.X] = corridors[i];
                            }
                            else if (!map.Grid[currentRoom.Y, currentRoom.X].IsCorridor) // we're inside another room
                            {
                                insideRoom = true;
                                corridorHistory.Clear();
                            }
                            else if (map.Grid[currentRoom.Y, currentRoom.X].IsCorridor)
                            {
                                curItem = map.Grid[currentRoom.Y, currentRoom.X];
                                for (int k = 0; k < corridorHistory.Count; k++)
                                {
                                    map.Grid[corridorHistory[k].Y, corridorHistory[k].X] = curItem;
                                }
                            }
                        }
                        currentRoom.Y = currentRoom.Y + 1;
                        deltaY--;
                    }
                }
                // drawing horizontal lane
                int deltaX = corridors[i].Path[1].X - corridors[i].Path[0].X;
                if (deltaX < 0) // the corridor goes west
                {
                    while (deltaX < 0)
                    {
                        if (insideRoom == true)
                        {
                            if (map.Grid[currentRoom.Y, currentRoom.X - 1] != curItem)
                            {
                                insideRoom = false;
                            }
                        }
                        else
                        {
                            corridorHistory.Add(currentRoom);
                            if (map.Grid[currentRoom.Y, currentRoom.X] == null)
                            {
                                map.Grid[currentRoom.Y, currentRoom.X] = corridors[i];
                            }
                            else if (!map.Grid[currentRoom.Y, currentRoom.X].IsCorridor) // we're inside another room
                            {
                                insideRoom = true;
                                corridorHistory.Clear();
                            }
                            else if (map.Grid[currentRoom.Y, currentRoom.X].IsCorridor)
                            {
                                curItem = map.Grid[currentRoom.Y, currentRoom.X];
                                for (int k = 0; k < corridorHistory.Count; k++)
                                {
                                    map.Grid[corridorHistory[k].Y, corridorHistory[k].X] = curItem;
                                }
                            }
                        }
                        currentRoom.X = currentRoom.X - 1;
                        deltaX++;
                    }
                }
                else // the corridor goes east
                {
                    while (deltaX > 0)
                    {
                        if (insideRoom == true)
                        {
                            if (map.Grid[currentRoom.Y, currentRoom.X + 1] != curItem)
                            {
                                insideRoom = false;
                            }
                        }
                        else
                        {
                            corridorHistory.Add(currentRoom);
                            if (map.Grid[currentRoom.Y, currentRoom.X] == null)
                            {
                                map.Grid[currentRoom.Y, currentRoom.X] = corridors[i];
                            }
                            else if (!map.Grid[currentRoom.Y, currentRoom.X].IsCorridor) // we're inside another room
                            {
                                insideRoom = true;
                                corridorHistory.Clear();
                            }
                            else if (map.Grid[currentRoom.Y, currentRoom.X].IsCorridor)
                            {
                                curItem = map.Grid[currentRoom.Y, currentRoom.X];
                                for (int k = 0; k < corridorHistory.Count; k++)
                                {
                                    map.Grid[corridorHistory[k].Y, corridorHistory[k].X] = curItem;
                                }
                            }
                        }
                        currentRoom.X = currentRoom.X + 1;
                        deltaX--;
                    }
                }
            }
        }


        public void Generate(Map map)
        {
            List<WeightedEdge> wEdges = connectEverySummit(map.Rooms);

            List<Edge> edges = primAlgorithm(map.Rooms, wEdges);

            for (int i = 0; i < edges.Count; i++)
            {
                map.Corridors.Add(new Corridor(edges[i].Room1, edges[i].Room2));
            }

            drawCorridors(map, map.Corridors);
        }
    }
}
