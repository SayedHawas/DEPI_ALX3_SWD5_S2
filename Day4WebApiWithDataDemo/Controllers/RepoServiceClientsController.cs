namespace Day4WebApiWithDataDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RepoServiceClientsController : ControllerBase
    {
        private readonly IServiceClient _service;

        public RepoServiceClientsController(IServiceClient service)
        {
            _service = service;
        }

        // GET: api/RepoServiceClients
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Client>>> GetClients()
        {
            return _service.GetClients().ToList();
        }

        // GET: api/RepoServiceClients/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Client>> GetClient(int id)
        {
            var client = _service.GetClientByID(id);
            if (client == null)
            {
                return NotFound();
            }
            return client;
        }

        // PUT: api/RepoServiceClients/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClient(int id, Client client)
        {
            if (id != client.ClientId)
            {
                return BadRequest();
            }
            _service.UpdateClient(client);
            return NoContent();
        }

        // POST: api/RepoServiceClients
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Client>> PostClient(Client client)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            //_context.Clients.Add(client);
            //await _context.SaveChangesAsync();
            _service.AddClient(client);
            return CreatedAtAction("GetClient", new { id = client.ClientId }, client);
        }

        // DELETE: api/RepoServiceClients/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClient(int id)
        {
            var client = _service.GetClientByID(id);
            if (client == null)
            {
                return NotFound();
            }
            _service.DeleteClient(id);
            return NoContent();
        }


    }
}
