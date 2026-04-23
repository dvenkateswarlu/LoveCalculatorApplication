using LoveCalculatorApp.Models;
using LoveCalculatorApp.UserDTO;
using LoveCalculatorApp.CommunicationDTO;

namespace LoveCalculatorApp.Services
{
    public class MapperService : IMapperService
    {
        public UserEntity UserMapper(RegisterDTO dto)
        {
            var user = new UserEntity
            {
                Email = dto.Communicationdto?.Email,
                Password = dto.Password,
                Username = dto.Username
            };

            return user;
        }

        public RegisterDTO UserMapper(UserEntity userEntity)
        {
            var dto = new RegisterDTO
            {
                Password = userEntity.Password,
                Username = userEntity.Username,
                Communicationdto = new CommunicateDTO
                {
                    Email = userEntity.Email
                }
            };

            return dto;
        }
    }
}