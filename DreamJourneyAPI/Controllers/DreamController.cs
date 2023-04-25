using DreamJourneyAPI.Data.Dtos.DreamDto;
using DreamJourneyAPI.Models;
using DreamJourneyAPI.Repositories;
using DreamJourneyAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DreamJourneyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DreamController : ControllerBase
    {
        private readonly IDreamRepository _dreamRepository;
        public DreamController(IDreamRepository dreamRepository)
        {
            _dreamRepository = dreamRepository;
        }

        /// <summary>
        /// Retorna a lista de sonhos
        /// </summary>
        /// <returns>ActionResult</returns>
        /// <response code="200">Caso a busca da lista tenha sido realizada com sucesso</response>
        /// <response code="500">Erro interno do servidor</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<DreamModel>>> GetAll([FromQuery] int skip = 0, [FromQuery] int take = 10)
        {
            List<DreamModel> dreams = await _dreamRepository.GetAll(skip, take);
            return Ok(dreams);
        }

        /// <summary>
        /// Retorna o sonho cujo o id tenha sido informado
        /// </summary>
        /// <param name="id"> Para a busca de um sonho é obrigatório que seja necessariamente informado um id.</param>
        /// <returns>ActionResult</returns>
        /// <response code="200">Caso o id exista e a busca tenha sido realizada com sucesso</response>
        /// <response code="404">Caso o id do sonho não tenha sido encontrado</response>
        /// <response code="500">Erro interno do servidor</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<DreamModel>> GetById(int id)
        {
            DreamModel dream = await _dreamRepository.GetById(id);
            if (dream == null)
            {
                return NotFound($"Dream id {id} not found");
            }
            return Ok(dream);

        }

        /// <summary>
        /// Adiciona um sonho ao banco de dados
        /// </summary>
        /// <param name="dreamModel"> Para a criação de um sonho é obrigatório que sejam necessariamente informados os campos name e description.
        /// Quando informado, o campo userId deve conter valor válido. Enums "lifeArea" e "status" aceitam numeros inteiros de 0-3</param>
        /// <returns>ActionResult</returns>
        /// <response code="201">Caso inserção seja feita com sucesso</response>
        /// <response code="500">Caso campo esteja com valor incorreto ou erro interno do servidor</response>
        /// <response code="400">Caso JSON ou informação em campo esteja no formato incorreto</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<DreamModel>> Create([FromBody] CreateDreamDto dreamModel)
        {
            DreamModel dream = new DreamModel
            {
                Name = dreamModel.Name,
                Description = dreamModel.Description,
                LifeArea = dreamModel.LifeArea,
                Status = dreamModel.Status,
                UserId = dreamModel.UserId,
            };
            dream = await _dreamRepository.Create(dream);
            return CreatedAtAction(nameof(GetById), new { id = dream.Id }, dream);
        }

        /// <summary>
        /// Atualiza, no banco de dados, o sonho cujo o id tenha sido informado
        /// </summary>
        /// <param name="dreamModel"> Para a atualização de um sonho adicione as novas informações nos campos que deseja atualizar. </param>
        /// <returns>ActionResult</returns>
        /// <response code="200">Caso a alteração tenha sido realizada com sucesso</response>
        /// <response code="404">Caso o id do sonho não tenha sido encontrado</response>
        /// <response code="400">Caso JSON ou informação em campo esteja no formato incorreto</response>
        /// <response code="500">Caso campo obrigatório esteja com valor nulo ou erro interno do servidor</response>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(DreamModel), 200)]
        [ProducesResponseType(typeof(string), 404)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<DreamModel>> Update([FromBody] UpdateDreamDto dreamModel, int id)
        {
            dreamModel.Id = id;
            DreamModel dream = new DreamModel
            {
                Name = dreamModel.Name,
                Description = dreamModel.Description,
                LifeArea = dreamModel.LifeArea,
                Status = dreamModel.Status,
                UserId = dreamModel.UserId,
            };
            dream = await _dreamRepository.Update(dream, id);
            if (dream == null)
            {
                return NotFound($"Dream id {id} not found");
            }
            return Ok(dream);
        }

        /// <summary>
        /// Retorna um booleano "true" quando excluído o sonho cujo o id foi informado
        /// </summary>
        /// <param name="id"> Para a exclusão de um sonho é obrigatório que seja informado um id. </param>
        /// <returns>ActionResult</returns>
        /// <response code="200">Caso o id exista e a exclusão tenha sido realizada com sucesso</response>
        /// <response code="404">Caso o id do sonho não tenha sido encontrado</response>
        /// <response code="500">Erro interno do servidor</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<DreamModel>> Delete(int id)
        {
            bool isDreamDeleted = await _dreamRepository.Delete(id);
            if (!isDreamDeleted)
            {
                return NotFound($"Dream id {id} not found");
            }
            return Ok($"Dream deleted: {isDreamDeleted}");
        }
    }
}
