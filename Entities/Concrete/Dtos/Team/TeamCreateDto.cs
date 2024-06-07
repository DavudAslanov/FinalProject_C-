﻿using Entities.Concrete.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Dtos
{
    public class TeamCreateDto
    {
        public string Name { get; set; }
        public string SurName { get; set; }

        public  string FacebookUrl  { get; set; }

        public string TwitterUrl { get; set; }

        public string PhotoUrl { get; set; }
        public string TeamPositionName {  get; set; }

        public int PositionId { get; set; }

        public static Team ToTeam(TeamCreateDto dto)
        {
            Team team = new()
            {

              Name = dto.Name,

              SurName = dto.SurName,

              FacebookLink=dto.FacebookUrl,

              TwitterLink=dto.TwitterUrl,

              PositionId=dto.PositionId,

              PhotoUrl=dto.PhotoUrl,
            };
            return team;
        }
    }
}
