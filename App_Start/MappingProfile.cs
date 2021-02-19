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
            Mapper.CreateMap<TicketType, TicketTypeDTO>();
            Mapper.CreateMap<TicketTypeDTO, TicketType>();
            Mapper.CreateMap<TicketStatus, TicketStatusDTO>();
            Mapper.CreateMap<TicketStatusDTO, TicketStatus>();
            Mapper.CreateMap<TicketPriority, TicketPriorityDTO>();
            Mapper.CreateMap<TicketPriorityDTO, TicketPriority>();
            Mapper.CreateMap<Project, ProjectDTO>();
            Mapper.CreateMap<ProjectDTO, Project>();
        }
    }
}