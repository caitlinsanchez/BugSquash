using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using BugSquash.DTOs;
using BugSquash.Models;

namespace BugSquash.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Ticket, TicketDTO>();
            Mapper.CreateMap<TicketDTO, Ticket>();
        }
    }
}