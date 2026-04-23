using LoveCalculatorApp.Models;
using LoveCalculatorApp.UserDTO;

namespace LoveCalculatorApp.Services
{
    public interface IMapperService
    {
        UserEntity UserMapper(RegisterDTO dto);
        RegisterDTO UserMapper(UserEntity userEntity);
    }
}