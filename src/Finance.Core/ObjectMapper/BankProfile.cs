using System;
using System.Data;
using AutoMapper;
using Finance.Core.Entities;
using Nameless.WinFormsApplication.Data;

namespace Finance.Core.ObjectMapper {

    public sealed class BankProfile : Profile {

        #region Public Constructors

        public BankProfile() {
            CreateMap<IDataReader, Bank>()
                .ForMember(dest => dest.ID, opts => opts.MapFrom(src => src.GetInt32OrDefault(nameof(Bank.ID), 0)))
                .ForMember(dest => dest.Name, opts => opts.MapFrom(src => src.GetStringOrDefault(nameof(Bank.Name), string.Empty)))
                .ForMember(dest => dest.CreationDate, opts => opts.MapFrom(src => src.GetDateTimeOrDefault(nameof(Bank.CreationDate), DateTime.MinValue)))
                .ForMember(dest => dest.ModificationDate, opts => opts.MapFrom(src => src.GetDateTimeOrDefault(nameof(Bank.ModificationDate), DateTime.MinValue)));
        }

        #endregion Public Constructors
    }
}