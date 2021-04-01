using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeTwoRepo
{
    public class ClaimRepository
    {
        protected readonly List<ClaimContent> _claimDirectory = new List<ClaimContent>();

        //add claim
        public bool AddClaimToQueue(ClaimContent claim)
        {
            int startingCount = _claimDirectory.Count;
            _claimDirectory.Add(claim);
            return _claimDirectory.Count > startingCount;
        }

        //view all claims
        public List<ClaimContent> GetClaims()
        {
            return _claimDirectory;
        }

        //delete claim
        public bool RemoveClaimFromQueue(ClaimContent existingClaim)
        {
            bool deleteClaim = _claimDirectory.Remove(existingClaim);
            return deleteClaim;
        }

        public ClaimContent GetClaimByID(int claimID)
        {
            foreach (ClaimContent claim in _claimDirectory)
            {
                if (claim.ClaimID == claimID)
                {
                    return claim;
                }
            }
            return null;
        }


        public bool UpdateExistingClaim(int originalClaimID, ClaimContent newClaim)
        {
            ClaimContent oldClaim = GetClaimByID(originalClaimID);
            if (oldClaim != null)
            {
                oldClaim.ClaimID = newClaim.ClaimID;
                oldClaim.ClaimType = oldClaim.ClaimType;
                oldClaim.Description = oldClaim.Description;
                oldClaim.ClaimAmount = oldClaim.ClaimAmount;
                oldClaim.DateOfIncident = oldClaim.DateOfIncident;
                oldClaim.DateOfClaim = oldClaim.DateOfClaim;
                return true;
            }
            else
            {
                return false;
            }
        }

        public ClaimContent GetClaimByType(ClaimType claimType)
        {
            foreach (ClaimContent claim in _claimDirectory)
            {
                if (claim.ClaimType == claimType)
                {
                    return claim;
                }
            }
            return null;
        }

    }
}
