﻿using Microsoft.EntityFrameworkCore;
using PosReversalNIBBS_API.Data;
using PosReversalNIBBS_API.Models.Domain;
using PosReversalNIBBS_API.Models.DTO;
using PosReversalNIBBS_API.Repositories.IRepository;

namespace PosReversalNIBBS_API.Repositories.Repository
{
	public class ExcelResponseRepository : IExcelResponseRepository
	{
		private readonly PosNibbsDbContext context;

		public ExcelResponseRepository(PosNibbsDbContext context)
		{
			this.context = context;
		}
		public async Task<ExcelResponse> AddAsync(ExcelResponse excelResponse)
		{
			excelResponse.Id = Guid.NewGuid();



			await context.ExcelResponses.AddAsync(excelResponse);
			await context.SaveChangesAsync();
			return excelResponse;
		}


        public async Task<ExcelResponse> AddExcelAsync(AddExcelResponseVM excelResponse)
        {
			ExcelResponse excelModel = new ExcelResponse
			{
				Id=Guid.NewGuid(),
				TERMINAL_ID=excelResponse.TERMINAL_ID,
				STAN=excelResponse.STAN.Substring(1),
				RRN=excelResponse.RRN.Substring(1),
				AMOUNT=excelResponse.AMOUNT,
				BANK=excelResponse.BANK,	
				MERCHANT_ID=excelResponse.MERCHANT_ID,
				PAN=excelResponse.PAN,
				PROCESSOR=excelResponse.PROCESSOR,
				TRANSACTION_DATE=excelResponse.TRANSACTION_DATE,
				

			};
            await context.ExcelResponses.AddAsync(excelModel);
            await context.SaveChangesAsync();
            return excelModel;
        }

        public async Task<ExcelResponse?> CheckDuplicate(AddExcelResponseVM addExcelResponseVM)
		{
			string stan = !String.IsNullOrEmpty(addExcelResponseVM.STAN) ? addExcelResponseVM.STAN.Substring(1) : "";
			return await context.ExcelResponses.FirstOrDefaultAsync(x => x.STAN == stan && x.TERMINAL_ID == addExcelResponseVM.TERMINAL_ID);
		}

		public async Task<ExcelResponse> DeleteAsync(Guid id)
		{
			var excelResponse = await GetAsync(id);

			if (excelResponse != null) 
			{
				context.ExcelResponses.Remove(excelResponse);
				await context.SaveChangesAsync();
				return excelResponse;
			}

			return null;
		}

		public async Task<IEnumerable<ExcelResponse>> GetAllAsync()
		{
			return await context.ExcelResponses.ToListAsync();
		}

		public async Task<ExcelResponse> GetAsync(Guid id)
		{
			return await context.ExcelResponses.FirstOrDefaultAsync(x => x.Id == id);
		}

		public async Task<ExcelResponse> UpdateAsync(Guid id, ExcelResponse excelResponse)
		{
			var existingExcelResponse = await GetAsync(id);
			if (existingExcelResponse != null)
			{
				// I do not want to update the id, but want to update other properties
				existingExcelResponse.TERMINAL_ID = excelResponse.TERMINAL_ID;
				existingExcelResponse.MERCHANT_ID = excelResponse.MERCHANT_ID;
				existingExcelResponse.AMOUNT = excelResponse.AMOUNT;
				existingExcelResponse.STAN = excelResponse.STAN;
				existingExcelResponse.RRN = excelResponse.RRN;
				existingExcelResponse.PAN = excelResponse.PAN;
				existingExcelResponse.TRANSACTION_DATE = excelResponse.TRANSACTION_DATE;
				existingExcelResponse.PROCESSOR = excelResponse.PROCESSOR;
				existingExcelResponse.ACCOUNT_ID = excelResponse.ACCOUNT_ID;

				await context.SaveChangesAsync();
				return existingExcelResponse;

			}

			return null;
		}
	}
}
