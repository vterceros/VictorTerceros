using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VictorTerceros.DBModel;

namespace VictorTerceros.Logic
{
    class FilterLogic
    {
        #region Const
        #endregion

        #region Props

        #endregion

        #region Ctor

        public FilterLogic()
        {}

        static FilterLogic()
        { }

        #endregion

        #region Public Voids

        public static List<People> GetPeople(List<string> TargetCountries, List<string> TargetRoles, List<string> KeyRoles, List<string> ExcludedRoles, List<string> TargetIndustries
        ,List<int> ListOfCurrentClients,int MinNumberOfConnections,int MinNumberOfRecommendations, int Top = 100)
        {
            using (var context = new LinkedInModel())
            {
                var result = context.People.Where(p=> TargetCountries.Contains(p.Country)
                && TargetRoles.Any(r => p.CurrentRole.Contains(r))
                && KeyRoles.Any(r => p.CurrentRole.Contains(r))
                && !ExcludedRoles.Any(r => p.CurrentRole.Contains(r))
                //&& TargetIndustries.Contains(p.Industry)
                //&& !ListOfCurrentClients.Contains(p.PersonId)
                && p.NumberOfConnections >= MinNumberOfConnections
                && p.NumberOfRecommendations >= MinNumberOfRecommendations).Take(Top).ToList();

                return result;
            }
        }

        #endregion

    }
}
