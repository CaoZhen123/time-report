using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using TimeRecordSystem1.Dtos;
using TimeRecordSystem1.Models;

namespace TimeRecordSystem1.App_Start
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {

            Mapper.CreateMap<User, UserDto>();
            Mapper.CreateMap<UserDto, User>();

            Mapper.CreateMap<Project, ProjectDto>();
            Mapper.CreateMap<ProjectDto, Project>();

            Mapper.CreateMap<TimePeriod, TimePeriodDto>();
            Mapper.CreateMap<TimePeriodDto, TimePeriod>();

            Mapper.CreateMap<TimeEntry, TimeEntryDto>();
            Mapper.CreateMap<TimeEntryDto, TimeEntry>();
        }
    }
}