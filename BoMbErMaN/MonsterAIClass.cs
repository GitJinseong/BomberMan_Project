using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoMbErMaN
{
    public class MonsterAIClass
    { 
    
    }


    // 노드
    public class Node
    {
        public int X { get; }
        public int Y { get; }
        public List<Node> Neighbors { get; set; }
        public double Cost { get; set; }
        public double Heuristic { get; set; }
        // Node 클래스에 대한 참조 설정
        public Node Parent { get; set; }

        public Node(int x, int y)
        {
            X = x;
            Y = y;
            Neighbors = new List<Node>();
            Cost = double.PositiveInfinity;
            Heuristic = 0;
            Parent = null;
        }
    }

    // A star 알고리즘
    public class AStar
    {
        public List<Node> FindPath(Node start, Node goal)
        {
            // 초기화
            start.Cost = 0;
            start.Heuristic = CalculateHeuristic(start, goal);
            var openSet = new List<Node> { start };
            var closedSet = new List<Node>();

            while (openSet.Count > 0)
            {
                // 현재까지의 최소 비용 노드 선택
                Node current = openSet[0];
                for (int i = 1; i < openSet.Count; i++)
                {
                    if (openSet[i].Cost + openSet[i].Heuristic < current.Cost + current.Heuristic)
                    {
                        current = openSet[i];
                    }
                }

                // 목표 도달
                if (current == goal)
                {
                    return ReconstructPath(current);
                }

                openSet.Remove(current);
                closedSet.Add(current);

                // 이웃 노드 탐색
                foreach (Node neighbor in current.Neighbors)
                {
                    if (closedSet.Contains(neighbor))
                    {
                        continue;
                    }

                    double tentativeCost = current.Cost + CalculateDistance(current, neighbor);
                    if (tentativeCost < neighbor.Cost)
                    {
                        neighbor.Parent = current;
                        neighbor.Cost = tentativeCost;
                        neighbor.Heuristic = CalculateHeuristic(neighbor, goal);

                        if (!openSet.Contains(neighbor))
                        {
                            openSet.Add(neighbor);
                        }
                    }
                }
            }

            // 경로를 찾을 수 없음
            return null;
        }

        private double CalculateDistance(Node node1, Node node2)
        {
            // 두 노드 사이의 실제 비용 계산
            // 예: 유클리디안 거리, 맨해튼 거리 등
            // 필요에 따라 적절한 거리 계산식을 사용하세요.
            // 아래는 유클리디안 거리입니다.
            double dx = Math.Abs(node1.X - node2.X);
            double dy = Math.Abs(node1.Y - node2.Y);
            return Math.Sqrt(dx * dx + dy * dy);
        }

        private double CalculateHeuristic(Node node, Node goal)
        {
            // 휴리스틱 함수를 사용하여 노드 간의 예상 비용 계산
            // 필요에 따라 적절한 휴리스틱 함수를 사용하세요.
            double dx = Math.Abs(node.X - goal.X);
            double dy = Math.Abs(node.Y - goal.Y);
            return Math.Sqrt(dx * dx + dy * dy);
        }

        private List<Node> ReconstructPath(Node node)
        {
            // 경로를 재구성하여 반환
            List<Node> path = new List<Node>();
            Node current = node;
            while (current != null)
            {
                path.Insert(0, current);
                current = current.Parent;
            }
            return path;
        }
    }
}

