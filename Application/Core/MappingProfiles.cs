using AutoMapper;
using Domain;

namespace Application.Core
{
    /// <summary>
    /// This class is used to map the properties of the Activity class to the ActivityDto class.
    /// It is useful for updating firlds of activities using a built in mapper so we don't have to 
    /// individually write the update code for each field
    /// </summary>
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Activity, Activity>();
        }
    }
}