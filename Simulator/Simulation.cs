using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Simulator.Maps;

namespace Simulator;

public class Simulation
{
    private int currentCreatureIndex = 0;
    private int currentMoveIndex = 0;
    private readonly List<Direction> parsedMoves;

    /// <summary>
    /// Simulation's map.
    /// </summary>
    public Map Map { get; }

    /// <summary>
    /// Creatures moving on the map.
    /// </summary>
    public List<Creature> Creatures { get; }

    /// <summary>
    /// Starting positions of creatures.
    /// </summary>
    public List<Point> Positions { get; }

    /// <summary>
    /// Cyclic list of creatures moves.
    /// Bad moves are ignored - use DirectionParser.
    /// First move is for first creature, second for second and so on.
    /// When all creatures make moves,
    /// next move is again for first creature and so on.
    /// </summary>
    public string Moves { get; }

    /// <summary>
    /// Has all moves been done?
    /// </summary>
    public bool Finished { get; private set; } = false;

    /// <summary>
    /// Creature which will be moving current turn.
    /// </summary>
    public Creature CurrentCreature => Creatures[currentCreatureIndex];

    /// <summary>
    /// Lowercase name of direction which will be used in current turn.
    /// </summary>
    public string CurrentMoveName => parsedMoves[currentMoveIndex].ToString().ToLower();

    /// <summary>
    /// Simulation constructor.
    /// Throw errors:
    /// if creatures' list is empty,
    /// if number of creatures differs from
    /// number of starting positions.
    /// </summary>
    public Simulation(Map map, List<Creature> creatures, List<Point> positions, string moves)
    {
        if (creatures.Count == 0)
            throw new ArgumentException("Creatures list cannot be empty");

        if (creatures.Count != positions.Count)
            throw new ArgumentException("Number of creatures must match number of positions");

        Map = map;
        Creatures = new List<Creature>(creatures);
        Positions = new List<Point>(positions);
        Moves = moves;

        // Parse moves once at initialization
        parsedMoves = DirectionParser.Parse(moves);
        if (parsedMoves.Count == 0)
            throw new ArgumentException("No valid moves provided");

        // Place creatures on their starting positions
        for (int i = 0; i < creatures.Count; i++)
        {
            if (Map.Exist(positions[i]))
                Map.Add(creatures[i], positions[i]);
            else
                throw new ArgumentException($"Invalid starting position for creature {i}");
        }
    }

    /// <summary>
    /// Makes one move of current creature in current direction.
    /// Throw error if simulation is finished.
    /// </summary>
    public void Turn()
    {
        if (Finished)
            throw new InvalidOperationException("Simulation is already finished");

        // Make the move
        CurrentCreature.Go(parsedMoves[currentMoveIndex]);

        // Update indices for next turn
        currentMoveIndex = (currentMoveIndex + 1) % parsedMoves.Count;

        // If we've used all moves for current creature, move to next creature
        if (currentMoveIndex == 0)
        {
            currentCreatureIndex = (currentCreatureIndex + 1) % Creatures.Count;

            // If we're back to first creature and first move, simulation is finished
            if (currentCreatureIndex == 0)
            {
                Finished = true;
            }
        }
    }
}