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
        public async Task<ServiceResponse<List<Character>>> AddCharacter(Character NewCharacter)
        {
            var serviceReseponse = new ServiceResponse<List<Character>>();
            serviceReseponse.Data = characters;;
            characters.Add(NewCharacter);
            return serviceReseponse;
        }

        public async Task<ServiceResponse<List<Character>>> GetAllCharacters()
        {
            var serviceReseponse = new ServiceResponse<List<Character>>();
            serviceReseponse.Data = characters;
            return serviceReseponse;
        }

        public async Task<ServiceResponse<Character>> GetCharacterById(int id)
        {
            var serviceReseponse = new ServiceResponse<Character>();
            var character = characters.FirstOrDefault(c => c.Id == id);
            serviceReseponse.Data = character;

            return serviceReseponse;
        }
    }
}