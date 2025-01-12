using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Simulator.Maps;

namespace Simulator;

public class Simulation
{
    private int currentObjectIndex = 0;
    private int currentMoveIndex = 0;
    private readonly List<Direction> parsedMoves;

    public Map Map { get; }
    public List<IMappable> Objects { get; }
    public List<Point> Positions { get; }
    public string Moves { get; }
    public bool Finished { get; private set; } = false;
    public IMappable CurrentObject => Objects[currentObjectIndex];
    public string CurrentMoveName => parsedMoves[currentMoveIndex].ToString().ToLower();

    public Simulation(Map map, List<IMappable> objects, List<Point> positions, string moves)
    {
        if (objects.Count == 0)
            throw new ArgumentException("Objects list cannot be empty");

        if (objects.Count != positions.Count)
            throw new ArgumentException("Number of objects must match number of positions");

        Map = map;
        Objects = new List<IMappable>(objects);
        Positions = new List<Point>(positions);
        Moves = moves;

        parsedMoves = DirectionParser.Parse(moves);
        if (parsedMoves.Count == 0)
            throw new ArgumentException("No valid moves provided");

        for (int i = 0; i < objects.Count; i++)
        {
            if (Map.Exist(positions[i]))
                Map.Add(objects[i], positions[i]);
            else
                throw new ArgumentException($"Invalid starting position for object {i}");
        }
    }

    public void Turn()
    {
        if (Finished)
            throw new InvalidOperationException("Simulation is already finished");

        CurrentObject.Go(parsedMoves[currentMoveIndex]);

        currentMoveIndex = (currentMoveIndex + 1) % parsedMoves.Count;

        if (currentMoveIndex == 0)
        {
            currentObjectIndex = (currentObjectIndex + 1) % Objects.Count;

            if (currentObjectIndex == 0)
            {
                Finished = true;
            }
        }
    }
}