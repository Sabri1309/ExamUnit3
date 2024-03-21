using System;
using System.IO;
using System.Text.Json;

namespace JSONTreeOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = "nodes.json";
            string jsonString = File.ReadAllText(filePath);

            JsonDocument jsonDocument = JsonDocument.Parse(jsonString);
            JsonElement root = jsonDocument.RootElement;

            int sum = CalculateSum(root);
            int deepestLevel = FindDeepestLevel(root);
            int nodeCount = CountNodes(root);

            Console.WriteLine("Sum of all values: " + sum);
            Console.WriteLine("Deepest level of the structure: " + deepestLevel);
            Console.WriteLine("Number of nodes: " + nodeCount);
        }

        static int CalculateSum(JsonElement node)
        {
            if (node.ValueKind == JsonValueKind.Null)
                return 0;

            int value = node.GetProperty("value").GetInt32();
            JsonElement left = node.GetProperty("left");
            JsonElement right = node.GetProperty("right");

            return value + CalculateSum(left) + CalculateSum(right);
        }

        static int FindDeepestLevel(JsonElement node)
        {
            if (node.ValueKind == JsonValueKind.Null)
                return 0;

            int leftDepth = FindDeepestLevel(node.GetProperty("left"));
            int rightDepth = FindDeepestLevel(node.GetProperty("right"));

            return Math.Max(leftDepth, rightDepth) + 1;
        }

        static int CountNodes(JsonElement node)
        {
            if (node.ValueKind == JsonValueKind.Null)
                return 0;

            int leftCount = CountNodes(node.GetProperty("left"));
            int rightCount = CountNodes(node.GetProperty("right"));

            return leftCount + rightCount + 1;
        }
    }
}
