using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Server;
using System.Globalization;

namespace AppCima.Controllers
{
    public class RemoteMessagesController : Controller
    {
        private readonly MasterContext _context;

        public RemoteMessagesController()
        {
            _context = new MasterContext();
        }
       
        // GET: RemoteMessages
        public async Task<IActionResult> Index()
        {         

            return View(await _context.RemoteMessages.Include(d => d.Details).OrderByDescending(x => x.Date).ToListAsync());
        }

        // GET: RemoteMessages/Transacoes/5
        public async Task<IActionResult> Transacoes(int? id, String dataInicial, String dataFinal)
        {
            ViewData["DataInicial"] = dataInicial;
            ViewData["DataFinal"] = dataFinal;


            if (id == null)
            {
                //return NotFound();
            }

            Equipamento  equipamento = _context.Equipamentos.FirstOrDefault(e => e.Id == id);
            ViewBag.Equipamento = equipamento;


            var linguagens = _context.Linguagens.ToList();
            ViewBag.linguagens = linguagens;


            var remoteMessage = await _context.RemoteMessages.Include(d => d.Details).ThenInclude(c => c.Countings).ThenInclude(e => e.Counted).OrderByDescending(x =>  x.Date.Date).ThenByDescending(h => h.Time.TimeOfDay).ToListAsync();
            if (remoteMessage == null)
            {
                return NotFound();
            }

            remoteMessage = remoteMessage.Where(c => (c.Operation == "Deposit" || c.Operation == "Cash removal")).ToList();
            remoteMessage = remoteMessage.Where(c => (c.DeviceID == equipamento.Descricao)).ToList();

            //var dataInicial = DateTime.Parse("22/06/2022");
            //var dataFinal = DateTime.Parse("25/06/2022");
            
            if (!String.IsNullOrEmpty(dataInicial))
            {

                remoteMessage = remoteMessage.Where(c => (c.Date >= DateTime.Parse(dataInicial) && c.Date <= DateTime.Parse(dataFinal))).ToList();
            }


            //Traduzindo Operacao
            remoteMessage.ToList().ForEach(c => c.Operacao = (from l in linguagens where l.En == c.Operation select l.Pt).FirstOrDefault());
            return View(remoteMessage);



        }

        // GET: RemoteMessages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var remoteMessage = await _context.RemoteMessages
                .Include(e => e.Details).ThenInclude(d => d.Countings).ThenInclude(c=>c.Counted)
                .FirstOrDefaultAsync(m => m.Id == id);
                
            if (remoteMessage == null)
            {
                return NotFound();
            }




            //Traduzindo operacao
            var linguagens = _context.Linguagens.ToList();
            remoteMessage.Operacao = (from l in linguagens where l.En == remoteMessage.Operation select l.Pt).FirstOrDefault();


            return View(remoteMessage);
            
        }

        // GET: RemoteMessages/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RemoteMessages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TransactionID,User,UserName,UserLevel,UserAlternateID,UserOrganization,UserInfo,TransactionRef,TransactionInfo,AccountingDate,IsKit,Conciliation,Operation,DeviceID,CustomerCode,Date,Time,NOP,Text,EnvelopeID,SealID,MachineId,ExecutedBy,ChannelID,ChannelName,UserID")] RemoteMessage remoteMessage)
        {
            if (ModelState.IsValid)
            {
                _context.Add(remoteMessage);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(remoteMessage);
            
        }

        // GET: RemoteMessages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var remoteMessage = await _context.RemoteMessages.FindAsync(id);
            if (remoteMessage == null)
            {
                return NotFound();
            }
            return View(remoteMessage);
            
        }

        // POST: RemoteMessages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TransactionID,User,UserName,UserLevel,UserAlternateID,UserOrganization,UserInfo,TransactionRef,TransactionInfo,AccountingDate,IsKit,Conciliation,Operation,DeviceID,CustomerCode,Date,Time,NOP,Text,EnvelopeID,SealID,MachineId,ExecutedBy,ChannelID,ChannelName,UserID")] RemoteMessage remoteMessage)
        {
            if (id != remoteMessage.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(remoteMessage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RemoteMessageExists(remoteMessage.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(remoteMessage);
               
            }

        // GET: RemoteMessages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var remoteMessage = await _context.RemoteMessages
                .FirstOrDefaultAsync(m => m.Id == id);
            if (remoteMessage == null)
            {
                return NotFound();
            }

            return View(remoteMessage);
               
            }

        // POST: RemoteMessages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var remoteMessage = await _context.RemoteMessages.FindAsync(id);
            _context.RemoteMessages.Remove(remoteMessage);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
               
            }

        private bool RemoteMessageExists(int id)
        {
            return _context.RemoteMessages.Any(e => e.Id == id);
            
        }
    }
}
