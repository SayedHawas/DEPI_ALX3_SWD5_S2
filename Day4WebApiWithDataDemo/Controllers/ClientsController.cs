namespace Day4WebApiWithDataDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ClientsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Clients
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Client>>> GetClients()
        {
            var result = await _context.Clients.ToListAsync();
            if (result == null) return NotFound();
            return Ok(result);
        }

        // GET: api/Clients/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Client>> GetClient(int id)
        {
            var client = await _context.Clients.FindAsync(id);

            if (client == null)
            {
                return NotFound();
            }
            return Ok(client);
        }

        // PUT: api/Clients/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClient(int id, Client client)
        {
            if (id != client.ClientId)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid) return BadRequest(client);
            _context.Entry(client).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }

        // POST: api/Clients
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Client>> PostClient([FromForm] Client client)
        {
            if (!ModelState.IsValid) return BadRequest(client);
            _context.Clients.Add(client);
            await _context.SaveChangesAsync();
            //Location
            return Created();
            //return CreatedAtAction("GetClient", new { id = client.ClientId }, client);
        }

        // DELETE: api/Clients/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClient(int id)
        {
            var client = await _context.Clients.FindAsync(id);
            if (client == null)
            {
                return NotFound();
            }

            _context.Clients.Remove(client);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClientExists(int id)
        {
            return _context.Clients.Any(e => e.ClientId == id);
        }

        [HttpGet("Pagination")]
        public async Task<ActionResult<IEnumerable<Client>>> GetWithPagination([FromQuery] int page = 1, [FromQuery] int pageSize = 5)
        {
            var ClientCount = _context.Clients.Count(); //22   Page size 4  20/4 = 5.2 ~ 6
            //Pagination
            var totalCount = ClientCount;
            var totalPage = (int)Math.Ceiling((double)totalCount / pageSize);

            // IEnumerable<Client>  Vs IQueryable<Client>
            //    In Memory                in SQL 


            var Clients = (_context.Clients as IQueryable<Client>).Skip((page - 1) * pageSize).Take(pageSize);//.ToListAsync();
            //Clients = Clients.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            return Ok(Clients.ToList());
        }
    }
}
