using EloBuddy; 
 using LeagueSharp.Common; 
 namespace RethoughtLib.Algorithm.Pathfinding.Dijkstra
{
    #region Using Directives

    using System;
    using System.Collections.Generic;

    using LeagueSharp.Common;

    using RethoughtLib.Algorithm.Pathfinding.Dijkstra.ConnectionTypes;

    using SharpDX;

    #endregion

    internal class DijkstraTest
    {
        #region Fields

        /// <summary>
        ///     Different Implementations of "The connections".
        /// </summary>
        private readonly List<EdgeBase<Vector2>> connections =
            new List<EdgeBase<Vector2>>
                {
                // Manual Implementations
                    new SimpleEdge<Vector2>(Nodes[0], Nodes[1], 5),
                    new SimpleEdge<Vector2>(Nodes[1], Nodes[2], 10),
                    new SimpleEdge<Vector2>(Nodes[0], Nodes[2], 15),

                // Implementation with a preset (cost = distance of the vectors / overwritten)
                    new AutoVector2Edge(Nodes[0], Nodes[2]) { Cost = 10},
                    new AutoVector2Edge(Nodes[1], Nodes[2]),
                    new AutoVector2Edge(Nodes[0], Nodes[1]),

                // Function Implementation
                    new FuncEdge<Vector2>(Nodes[0], Nodes[1], MyFunc),
                    new FuncEdge<Vector2>(Nodes[1], Nodes[2], MyFunc),
                    new FuncEdge<Vector2>(Nodes[0], Nodes[2], MyFunc)
                };

        /// <summary>
        ///     My example function to determine the cost.
        /// </summary>
        /// <param name="vector2">The vector2.</param>
        /// <param name="vector3">The vector3.</param>
        /// <returns></returns>
        private static float MyFunc(Vector2 vector2, Vector2 vector3)
        {
            return vector2.Distance(vector3);
        }

        /// <summary>
        ///     The nodes.
        /// </summary>
        private static readonly List<Vector2> Nodes = new List<Vector2> { new Vector2(0,0), new Vector2(1,1), new Vector2(5,5)};

        #endregion

        #region Methods

        private void Calculate()
        {
            var calculator = new Dijkstra<Vector2, EdgeBase<Vector2>>(this.connections);

            calculator.SetStart(Nodes[0]);

            var path = calculator.GetNodesTo(Nodes[2]);

            foreach (var node in path)
            {
                Console.WriteLine(node);
            }
        }

        #endregion
    }
}