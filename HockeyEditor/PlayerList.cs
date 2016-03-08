using System;
using System.Collections.Generic;

namespace HockeyEditor
{
    /// <summary>
    /// The server's player list
    /// </summary>
    public static class PlayerList
    {
        /// <summary>
        /// An array of Player classes for every player in the server
        /// </summary>
        public static Player[] players
        {
            get
            {
                List<Player> playerList = new List<Player>();
                for (int i = 0; i < 30; i++)
                {
                    Player player = new Player(i);
                    if (player.inServer)
                        playerList.Add(player);
                }

                return playerList.ToArray();
            }
        }

        /// <summary>
        /// Attempts to find a player by name
        /// </summary>
        /// <param name="name">The name of the player to search for</param>
        /// <returns>A Player class or null if no player with that name found</returns>
        public static Player GetPlayerFromName(string name)
        {
            foreach (Player player in players)
                if (player.name == name)
                    return player;

            // No player by that name
            return null;
        }
    }
}
