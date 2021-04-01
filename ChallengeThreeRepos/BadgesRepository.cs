using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeThreeRepos
{
    public class BadgesRepository
    {

        public readonly Dictionary<int, List<DoorNames>> badgeDictionary = new Dictionary<int, List<DoorNames>>();

        public bool AddNewBadgeToDictionary(BadgesContent badge)
        {
            int startingCount = badgeDictionary.Count;
            badgeDictionary.Add(badge.BadgeID, badge.DoorNameList);
            return badgeDictionary.Count > startingCount;
        }


        public Dictionary<int, List<DoorNames>> GetBadgeDictionary()
        {
            return badgeDictionary;
        }


        public List<DoorNames> GetDoorsByBadgeID(int badgeID)
        {
            if (badgeDictionary.ContainsKey(badgeID))
            {
                return badgeDictionary[badgeID];
            }
            else
            {
                return null;
            }
        }

        public bool UpdateDoorsOnBadge(int badgeID, List<DoorNames> newDoors)
        {
            List<DoorNames> oldDoors = GetDoorsByBadgeID(badgeID);


            if (oldDoors != null)
            {
                badgeDictionary[badgeID] = newDoors;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}