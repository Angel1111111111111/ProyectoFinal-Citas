using AutoMapper;
using Citas_Backend.Dtos.Citas;
using Citas_Backend.Dtos.Consultas;
using Citas_Backend.Dtos.Doctores;
using Citas_Backend.Dtos.Especialidades;
using Citas_Backend.Dtos.pacientes;
using Citas_Backend.Dtos.Pacientes;
using Citas_Backend.Dtos.Turnos;
using Citas_Backend.Entities;

namespace Citas_Backend.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CitasDto, CitasEntity>();
            CreateMap<CitasEntity, CitasDto>();
            CreateMap<CitaCreateDto, CitasEntity>();

            CreateMap<ConsultaDto, ConsultaEntity>();
            CreateMap<ConsultaEntity, ConsultaDto>();
            CreateMap<ConsultaCreateDto, ConsultaEntity>();

            CreateMap<EspecialidadDto, EspecialidadEntity>();
            CreateMap<EspecialidadEntity, EspecialidadDto>();
            CreateMap<EspecialidadCreateDto, EspecialidadEntity>();

            CreateMap<PacienteDto, PacienteEntity>();
            CreateMap<PacienteEntity, PacienteDto>();
            CreateMap<PacienteCreateDto, PacienteEntity>();

            CreateMap<TurnoDto, TurnoEntity>();
            CreateMap<TurnoEntity, TurnoDto>();
            CreateMap<TurnoCreateDto, TurnoEntity>();
            
            CreateMap<DoctorDto, DoctorEntity>();
            CreateMap<DoctorEntity, DoctorDto>();
            CreateMap<DoctorCreateDto, DoctorEntity>();
        }
    }
}
