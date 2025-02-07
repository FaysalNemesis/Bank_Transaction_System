using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BankTransaction_App.Models;

namespace BankTransaction_App.Controllers
{
    public class BankTransactionController : Controller
    {
        private readonly TransactionDbContext _context;

        public BankTransactionController(TransactionDbContext context)
        {
            _context = context;
        }

        // GET: BankTransaction
        public async Task<IActionResult> Index()
        {
            return View(await _context.Transactions.ToListAsync());
        }

        // GET: BankTransaction/AddOrEdit
        public IActionResult AddOrEdit(int id=0)
        {
            if (id == 0)
                return View(new BankTransaction());
            else
                return View(_context.Transactions.Find(id));
        }

        // POST: BankTransaction/AddOrEdit
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit([Bind("TransactionId,AccountNumber,BenificiaryName,BankName,SWIFTCode,Amount,TransactionDate")] BankTransaction bankTransaction)
        {
            if (ModelState.IsValid)
            {
                if (bankTransaction.TransactionId ==0 )
                {
                    bankTransaction.TransactionDate = DateTime.Now;
                    _context.Add(bankTransaction);
                }
                else
                    _context.Update(bankTransaction);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bankTransaction);
        }

        // POST: BankTransaction/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bankTransaction = await _context.Transactions.FindAsync(id);
            if (bankTransaction != null)
            {
                _context.Transactions.Remove(bankTransaction);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
      
    }
}
