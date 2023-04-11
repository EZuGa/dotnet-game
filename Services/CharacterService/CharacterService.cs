using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_game.Services.CharacterService
{
    public class CharacterService : ICharacterService
    {
        private static List<Character> characters = new List<Character>{
            new Character(),
            new Character(){Id = 1, Name = "Sam"}
        };
        private readonly IMapper _mapper;

        public CharacterService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto NewCharacter)
        {
            var serviceReseponse = new ServiceResponse<List<GetCharacterDto>>();
            var character = _mapper.Map<Character>(NewCharacter);
            character.Id = characters.Max(c=> c.Id) + 1;
            characters.Add(character);
            serviceReseponse.Data = characters.Select(c=> _mapper.Map<GetCharacterDto>(c)).ToList();
            return serviceReseponse;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacters()
        {
            var serviceReseponse = new ServiceResponse<List<GetCharacterDto>>();
            serviceReseponse.Data = characters.Select(c=> _mapper.Map<GetCharacterDto>(c)).ToList();
            return serviceReseponse;
        }

        public async Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int id)
        {
            var serviceReseponse = new ServiceResponse<GetCharacterDto>();
            var character = characters.FirstOrDefault(c => c.Id == id);
            serviceReseponse.Data = _mapper.Map<GetCharacterDto>(character);

            return serviceReseponse;
        }

        public async Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto updatedCharacter)
        {
            var serviceReseponse = new ServiceResponse<GetCharacterDto>();
            try{
                var character = characters.FirstOrDefault(v => v.Id == updatedCharacter.Id);

                if(character is null){
                    throw new Exception("Character with id " + updatedCharacter.Id + " Cant be found");
                }

                character.Name = updatedCharacter.Name;
                character.HitPoints = updatedCharacter.HitPoints;
                character.Strength = updatedCharacter.Strength;
                character.Defense = updatedCharacter.Defense;
                character.Inteligence = updatedCharacter.Inteligence;
                character.Class = updatedCharacter.Class;
                

                serviceReseponse.Data = _mapper.Map<GetCharacterDto>(character);
            }catch(Exception err){
                serviceReseponse.Success = false;
                serviceReseponse.Message = err.Message;
            }


            return serviceReseponse;
        }
    }
}