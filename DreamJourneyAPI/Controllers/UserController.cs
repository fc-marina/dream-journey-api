using DreamJourneyAPI.Data.Dtos.UserDto;
using DreamJourneyAPI.Models;
using DreamJourneyAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DreamJourneyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        /// <summary>
        /// Retorna a lista de usuários
        /// </summary>
        /// <returns>ActionResult</returns>
        /// <response code="200">Caso a busca da lista tenha sido realizada com sucesso</response>
        /// <response code="500">Erro interno do servidor</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task <ActionResult<List<UserModel>>> GetAll([FromQuery] int skip = 0, [FromQuery] int take = 10) {
            List<UserModel> users = await _userRepository.GetAll(skip, take);
            return Ok(users);
        }

        /// <summary>
        /// Retorna o usuário cujo o id tenha sido informado
        /// </summary>
        /// <param name="id"> Para a busca de um usuário é obrigatório que seja necessariamente informado um id.</param>
        /// <returns>ActionResult</returns>
        /// <response code="200">Caso o id exista e a busca tenha sido realizada com sucesso</response>
        /// <response code="404">Caso o id usuário não tenha sido encontrado</response>
        /// <response code="500">Erro interno do servidor</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<UserModel>> GetById(int id)
        {
            UserModel user = await _userRepository.GetById(id);
            if (user == null)
            {
                return NotFound($"User id {id} not found");
            }
            return Ok(user);
        }

        /// <summary>
        /// Adiciona um usuário ao banco de dados
        /// </summary>
        /// <param name="userDto"> Para a criação de um usuário é obrigatório que sejam necessariamente informados os campos name e birthDate.</param>
        /// <returns>ActionResult</returns>
        /// <response code="201">Caso inserção seja feita com sucesso</response>
        /// <response code="500">Caso campo obrigatório esteja com valor nulo ou erro interno do servidor</response>
        /// <response code="400">Caso JSON ou informação em campo esteja no formato incorreto</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<UserModel>> Create([FromBody] CreateUserDto userDto)
        {
            UserModel user = new UserModel
            {
                Name = userDto.Name,
                BirthDate = userDto.BirthDate,
            };
            user = await _userRepository.Create(user);
            return CreatedAtAction(nameof(GetById), new { id = user.Id }, user);
        }

        /// <summary>
        /// Atualiza, no banco de dados, o usuário cujo o id tenha sido informado
        /// </summary>
        /// <param name="userModel"> Para a atualização de um usuário adicione as novas informações nos campos que deseja atualizar. </param>
        /// <returns>ActionResult</returns>
        /// <response code="200">Caso a alteração tenha sido realizada com sucesso</response>
        /// <response code="404">Caso o id usuário não tenha sido encontrado</response>
        /// <response code="400">Caso JSON ou informação em campo esteja no formato incorreto</response>
        /// <response code="500">Caso campo obrigatório esteja com valor nulo ou erro interno do servidor</response>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(UserModel), 200)]
        [ProducesResponseType(typeof(string), 404)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<UserModel>> Update([FromBody] UserModel userModel, int id)
        {
            userModel.Id = id;
            UserModel user = await _userRepository.Update(userModel, id);
            if (user == null)
            {
                return NotFound($"User id {id} not found");
            }
            return Ok(user);
        }

        /// <summary>
        /// Retorna "true" quando excluído o usuário cujo o id foi informado
        /// </summary>
        /// <param name="id"> Para a exclusão de um usuário é obrigatório que seja informado um id. </param>
        /// <returns>ActionResult</returns>
        /// <response code="200">Caso o id exista e a exclusão tenha sido realizada com sucesso</response>
        /// <response code="404">Caso o id do usuário não tenha sido encontrado</response>
        /// <response code="500">Erro interno do servidor</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<UserModel>> Delete(int id)
        {
            bool isUserDeleted = await _userRepository.Delete(id);
            if (!isUserDeleted)
            {
                return NotFound($"User id {id} not found");
            }
            return Ok($"User deleted: {isUserDeleted}");
        }
    }
}
