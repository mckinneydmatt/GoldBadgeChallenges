using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeThreeRepos
{
    public enum DoorNames { A1, A2, A3, B1, B2, B3, C1, C2, C3}
    public class BadgesContent
    {
        public int BadgeID { get; set; }
        public List<DoorNames> DoorNameList { get; set; }

        public BadgesContent() { }  

        public BadgesContent(int badgeID, List<DoorNames> doorNameList)
        {
            BadgeID = badgeID;
            DoorNameList = doorNameList;
        }


    }

}
