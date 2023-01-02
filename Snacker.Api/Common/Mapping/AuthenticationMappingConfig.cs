using System.Security.Cryptography;
using System.Reflection.Metadata.Ecma335;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Snacker.Api.Common.Mapping;

    public class AuthenticationMappingConfig : IRegister 
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<RegisterRequest,RegisterCommand>();
            config.NewConfig<LoginRequest,LoginQuery>();
             //these two above might be redundant, but it helps keep track of all various mappings

            config.NewConfig<AuthenticationResult,AuthenticationResponse>()
            //.Map(dest => dest.Token, src => src.Token) 
            .Map(dest => dest , src => src.User);
        }
    }
