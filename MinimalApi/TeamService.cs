using Microsoft.AspNetCore.Mvc;
using MinimalApi.Models;

namespace MinimalApi
{
    public class TeamService : ITeamService
    {
        public ApplicationContext _context { get; set; }
        
        public TeamService(ApplicationContext context)
        {
            _context = context;
            
        }


        public  team Create(team team)
        {
           
            _context.Team.Add(team);
            _context.SaveChanges();
            
            return team;
        }

        public void Delete(int id)
        {
            team? t = _context.Team.Where(a => a.Id == id).FirstOrDefault();
            if(t != null)
            {
                _context.Team.Remove(t);
                _context.SaveChanges();
            }
        }

        public team Get(int id)
        {
            team? t = _context.Team.Where(a => a.Id == id).FirstOrDefault();
            if (t != null)
            {
                return t;
            }
            return null;
        }

        public team Update(team team, int id)
        {
            team? t = _context.Team.Where(a => a.Id == id).FirstOrDefault();
            if (t != null)
            {
                t.Name = team.Name;
                _context.SaveChanges();
            }

            return t;
        }
    }

       
}
