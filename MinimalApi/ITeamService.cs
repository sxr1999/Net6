using Microsoft.AspNetCore.Mvc;
using MinimalApi.Models;

namespace MinimalApi
{
    public interface ITeamService
    {
        public team Create(team team);
        public void Delete(int id);
        public team Update(team team,int id);

        public team? Get(int id);
       
    }
}
