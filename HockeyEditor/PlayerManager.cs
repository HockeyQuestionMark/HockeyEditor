using System;
using System.Collections.Generic;

namespace HockeyEditor
{
    public class PlayerManager
    {
        const int LOCAL_PLAYER_SLOT_ADDRESS = 0x080B62C4;
        const int NUM_PLAYERS = 30;

        /// <summary>
        /// An array of Player objects for every player in the server
        /// </summary>
        public static Player[] Players
        {
            get
            {
                List<Player> playerList = new List<Player>();
                for (int i = 0; i < NUM_PLAYERS; i++)
                {
                    Player player = new Player(i);
                    if (player.InServer)
                        playerList.Add(player);
                }

                return playerList.ToArray();
            }
        }

        /// <summary>
        /// An array of empty Player slots in the server
        /// </summary>
        public static Player[] EmptySlots
        {
            get
            {
                List<Player> playerList = new List<Player>();
                for (int i = 0; i < NUM_PLAYERS; i++)
                {
                    Player player = new Player(i);
                    if (!player.InServer)
                        playerList.Add(player);
                }

                return playerList.ToArray();
            }
        }

        /// <summary>
        /// Refers to the player on your client (the player that you control)
        /// </summary>
        public static Player LocalPlayer
        {
            get { return new Player(MemoryEditor.ReadInt(LOCAL_PLAYER_SLOT_ADDRESS)); }
        }

        /// <summary>
        /// Attempts to find a player by name
        /// </summary>
        /// <param name="name">The name of the player to search for</param>
        /// <returns>A Player class or null if no player with that name found</returns>
        public static Player GetPlayerFromName(string name)
        {
            foreach (Player player in Players)
            {
                if (player.Name == name)
                    return player;
            }

            // No player by that name
            return null;
        }
    }
}
