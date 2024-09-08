using System;
using System.Collections.Generic;

class Program
{
    //  database query result cache
    private static Dictionary<string, string> queryCache = new Dictionary<string, string>();

    static void Main(string[] args)
    {
        // Example of querying the database
        string query1 = "SELECT * FROM Users WHERE Id = 1";
        string result1 = GetQueryResult(query1);
        Console.WriteLine($"Result of query 1: {result1}");

        // Running the same query again, this time result will come from cache
        string result2 = GetQueryResult(query1);
        Console.WriteLine($"Result of query 1 (cached): {result2}");

        // Running a different query
        string query2 = "SELECT * FROM Users WHERE Id = 2";
        string result3 = GetQueryResult(query2);
        Console.WriteLine($"Result of query 2: {result3}");
    }

    // Method to get query result
    public static string GetQueryResult(string query)
    {

        // Check if the result is already in the cache
        if (queryCache.ContainsKey(query))
        {
            Console.WriteLine("Fetching result from cache...");
            return queryCache[query];
        }

        // Simulate a database query 
        string dbResult = SimulateDatabaseQuery(query);

        // Store the result in the cache
        queryCache[query] = dbResult;

        return dbResult;
    }

    //  database query
    public static string SimulateDatabaseQuery(string query)
    {
        Console.WriteLine("Executing query on the database...");
        // different results for different queries
        if (query == "SELECT * FROM Users WHERE Id = 1")
        {
            return "User 1: Mohamed ";
        }
        else if (query == "SELECT * FROM Users WHERE Id = 2")
        {
            return "User 2: Ahmed ";
        }
        else
        {
            return "No results found";
        }
    }
}
