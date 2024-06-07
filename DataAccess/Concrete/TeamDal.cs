﻿using Core.DataAccess.Concrete;
using DataAccess.Abstract;
using DataAccess.Context;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;

namespace DataAccess.Concrete
{
    public class TeamDal : BaseRepository<Team, ApplicationDbContext>, ITeamDal
    {
        private readonly ApplicationDbContext _context;

        public TeamDal(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<TeamDto> GetTeamWithPositionCategories()
        {
            var result = from team in _context.Teams
                         where team.Deleted == 0
                         join position in _context.Positions
                         on team.PositionId equals position.Id
                         where position.Deleted == 0
                         select new TeamDto
                         {
                             Id = team.Id,
                             Name = team.Name,
                             PositionId = team.PositionId,
                             SurName = team.SurName,
                             FacebookUrl = team.FacebookLink,
                             TwitterUrl = team.TwitterLink,
                             PositionName=position.Name,
                             PhotoUrl=team.PhotoUrl
                         };
            return result.ToList();
        }
    }
}
